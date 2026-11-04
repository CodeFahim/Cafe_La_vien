using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_La_Vien
{
    public partial class FormMenu : Form
    {
        private FormCashier parent;
        private string cashierId;
        private DataAccess Da { get; set; }
        public FormMenu(FormCashier parent ,string cashierId)
        {
            InitializeComponent();
 
            this.parent = parent;
            this.cashierId = cashierId;

            this.Da = new DataAccess();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            this.PopulateMenuGridView();
            this.PopulateOrderGridView(); // show items already in cart
            this.dgvMenuView.ClearSelection();

        }

        private void PopulateMenuGridView(string sql = "select * from MenuTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);
            
            this.dgvMenuView.AutoGenerateColumns = false;
            this.dgvMenuView.DataSource = ds.Tables[0];
            this.dgvMenuView.ClearSelection();
            this.dgvCartView.ClearSelection();

        }

        private void PopulateOrderGridView()
        {
            var ds = this.Da.ExecuteQuery("select * from OrderTable;");
            this.dgvCartView.AutoGenerateColumns = false;
            this.dgvCartView.DataSource = ds.Tables[0];
            this.dgvCartView.ClearSelection();
            this.UpdateBillSummary();
           

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {

            if (this.dgvMenuView.SelectedRows.Count <= 0)  
            {
                MessageBox.Show("Please select a row first");
                return;
            }
            if (!int.TryParse(this.txtQuantity.Text, out int cartQty) || cartQty <= 0)
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            string orderId = AutoOrderIdGenerate();   
            string name = this.dgvMenuView.SelectedRows[0].Cells[1].Value.ToString();
            int price = Convert.ToInt32(this.dgvMenuView.SelectedRows[0].Cells[2].Value);
            int menuQuantity = Convert.ToInt32(this.dgvMenuView.SelectedRows[0].Cells[3].Value);

            if (cartQty > menuQuantity)
            {
                MessageBox.Show("Not enough stock available!");
                return;
            }

            decimal totalBill = price * cartQty;

            string checkSql = "SELECT Quantity FROM OrderTable WHERE OrderName = '" + name + "';"; //item check kori
            var dtExisting = this.Da.ExecuteQueryTable(checkSql);

            if (dtExisting.Rows.Count > 0) //exist korle update kori cart
            {  
                
                int oldQty = Convert.ToInt32(dtExisting.Rows[0]["Quantity"]);
                int newQty = oldQty + cartQty;
                decimal newTotalBill = price * newQty;

                string updateSql = "UPDATE OrderTable SET Quantity = " + newQty + ", TotalBill = " + newTotalBill + " WHERE OrderName = '" + name + "';";
                this.Da.ExecuteDMLQuery(updateSql);
                MessageBox.Show("Cart updated");
            }
            else  //exist na korle notun item add kori cart e
            { 
                
                string cartId = AutoOrderIdGenerate();
                string insertSql = "INSERT INTO OrderTable (OrderID, OrderName, OrderPrice, Quantity, TotalBill) " +
                                   "VALUES ('" + cartId + "','" + name + "'," + price + "," + cartQty + "," + totalBill + ");";
                this.Da.ExecuteDMLQuery(insertSql);
                MessageBox.Show("Item added to cart.");
            }

            //menu table er quantity update kori
            string foodId = this.dgvMenuView.SelectedRows[0].Cells["ID"].Value.ToString();  
            int newMenuQty = menuQuantity - cartQty;    
            string updateMenuSql = "UPDATE MenuTable SET Quantity = " + newMenuQty + " WHERE FoodID = '" + foodId + "';";
            this.Da.ExecuteDMLQuery(updateMenuSql);
            this.PopulateMenuGridView();
            this.PopulateOrderGridView();
            this.txtQuantity.Clear();

        }

        private void FormMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private string AutoOrderIdGenerate()
        {
            string query = @"SELECT ISNULL( MAX(TRY_CAST(SUBSTRING(OrderID, 3, 100) AS INT)), 0 ) FROM OrderTable;";
            var dt = this.Da.ExecuteQueryTable(query);

            int lastNumber = 0;
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                int.TryParse(dt.Rows[0][0].ToString(), out lastNumber);
            }

            int newNumber = lastNumber + 1;
            string newId = "O-" + newNumber.ToString("D3");

            return newId; 
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {

            //cart er quantity menu te ferot dei
            string restoreSql = "UPDATE m SET m.Quantity = m.Quantity + o.Quantity FROM MenuTable m INNER JOIN OrderTable o ON m.FoodName = o.OrderName;";
            this.Da.ExecuteDMLQuery(restoreSql);

            string sql = "DELETE FROM OrderTable";
            int count = this.Da.ExecuteDMLQuery(sql);
            this.PopulateMenuGridView();

            if (count > 0)
                MessageBox.Show("Cart cleared successfully!");
            else
                MessageBox.Show("Cart is already empty.");

            dgvCartView.DataSource = null;  
            lblTotalPrice.Text = "0.00";
            lblSubtotal.Text = "0.00";

        }

        private void btnUpdateCart_Click(object sender, EventArgs e)
        {
            if (this.dgvCartView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a cart item first.");
                return;
            }

            if (!int.TryParse(this.txtQuantity.Text, out int newCartQty) || newCartQty <= 0)
            {
                MessageBox.Show("Enter a valid quantity.");
                return;
            }

            string orderId = this.dgvCartView.SelectedRows[0].Cells["OrderID"].Value.ToString();
            string foodName = this.dgvCartView.SelectedRows[0].Cells["OrderName"].Value.ToString();
            int orderPrice = Convert.ToInt32(this.dgvCartView.SelectedRows[0].Cells["OrderPrice"].Value);
            int oldCartQty = Convert.ToInt32(this.dgvCartView.SelectedRows[0].Cells["OrderQuantity"].Value);
            int oldTotalBill = Convert.ToInt32(this.dgvCartView.SelectedRows[0].Cells["TotalBill"].Value);

            string sqlMenuQty = "SELECT Quantity FROM MenuTable WHERE FoodName = '" + foodName + "';"; //current menu er quantity
            var dt = this.Da.ExecuteQueryTable(sqlMenuQty);
            if(dt.Rows.Count == 0)
            {
                MessageBox.Show("Food item not found in menu.");
                return;
            }
            int menuQty = Convert.ToInt32(dt.Rows[0][0]);
            int qtyDifference = newCartQty - oldCartQty;
            if (qtyDifference > menuQty)
            {
                MessageBox.Show("Not enough stock available!");
                return;
            }
            // update OrderTable
            int newTotalBill = orderPrice * newCartQty;
            string sqlUpdateCart = "UPDATE OrderTable SET Quantity = " + newCartQty + ", TotalBill = " + newTotalBill +
                         " WHERE OrderID = '" + orderId + "';";
            int count = this.Da.ExecuteDMLQuery(sqlUpdateCart);
            if (count != 1)
            {
                MessageBox.Show("Failed to update cart item.");
                return;
            }

            //menu table er quantity update
            int newMenuQty = menuQty -  qtyDifference;
            string sqlUpdateMenu = "UPDATE MenuTable SET Quantity = " + newMenuQty + " WHERE FoodName = '" + foodName + "';";
            this.Da.ExecuteDMLQuery(sqlUpdateMenu);
            this.PopulateMenuGridView();
            this.PopulateOrderGridView();
            this.txtQuantity.Clear();
            MessageBox.Show("Cart item updated successfully!");


        }

        private void UpdateBillSummary()
        {
            decimal totalBill = 0;

           
            foreach (DataGridViewRow row in dgvCartView.Rows) 
            {
                    if (row.Cells["TotalBill"].Value != null &&
                    decimal.TryParse(row.Cells["TotalBill"].Value.ToString(), out decimal val))
                {
                    totalBill += val;
                }
            }

            this.lblTotalPrice.Text = totalBill.ToString("0.00");
            decimal vat = totalBill * 0.015m;
            decimal discount = 0;
            decimal.TryParse(this.txtDiscount.Text, out discount);

            decimal subTotal = totalBill + vat - discount;
            if (subTotal < 0) subTotal = 0;   

            this.lblSubtotal.Text = subTotal.ToString("0.00");
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
           this.UpdateBillSummary();

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.dgvCartView.Rows.Count == 0)
            {
                MessageBox.Show("Cart is empty. Add items first.");
                return;
            }

            StringBuilder invoiceBuild = new StringBuilder();

            invoiceBuild.AppendLine("=====================================");
            invoiceBuild.AppendLine("                 CAFE LA VIE              ");
            invoiceBuild.AppendLine("                SALES INVOICE           ");
            invoiceBuild.AppendLine("=====================================");
            invoiceBuild.AppendLine($"Date: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            invoiceBuild.AppendLine("-------------------------------------");
            invoiceBuild.AppendLine("Order ID | Product Name | Unit Price | Qty | Total");
            invoiceBuild.AppendLine("-------------------------------------");
           
            foreach (DataGridViewRow row in dgvCartView.Rows)
            {
                string orderId = row.Cells["OrderID"].Value.ToString();
                string foodName = row.Cells["OrderName"].Value.ToString();
                decimal quantity = Convert.ToDecimal(row.Cells["OrderQuantity"].Value, CultureInfo.InvariantCulture);
                decimal total = Convert.ToDecimal(row.Cells["TotalBill"].Value, CultureInfo.InvariantCulture);
                string sellDate = dtpOrder.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                decimal price = total / quantity;              
                invoiceBuild.AppendLine($"{orderId} | {foodName} | {price:0.00} | {quantity:0.##} | {total:0.00}");

                string sql = $"INSERT INTO SellTable (OrderID, FoodName, Quantity, TotalBill, SellDate, CashierID) " +
                             $"VALUES ('{orderId}', '{foodName}', {quantity}, {total}, '{sellDate}', '{this.cashierId}')";


                int count = this.Da.ExecuteDMLQuery(sql);

                if (count == 1)
                {
                    MessageBox.Show("Sale for Order " + orderId + " added");
                   
                }
                else
                    MessageBox.Show("Sale for Order " + orderId + " not added");
            }
            invoiceBuild.AppendLine("-------------------------------------");
            invoiceBuild.AppendLine($"Total Amount: {lblTotalPrice.Text}");
            invoiceBuild.AppendLine($"Sub-Total (with VAT/Discount): {lblSubtotal.Text}");
             invoiceBuild.AppendLine("=====================================");

 
            string invoiceText = invoiceBuild.ToString();
            MessageBox.Show(invoiceText, "Invoice");
            MessageBox.Show("All sales have been saved successfully!");

            txtDiscount.Clear();
            lblTotalPrice.Text = "0.00";
            lblSubtotal.Text = "0.00";
            dgvCartView.DataSource = null;

            this.Da.ExecuteDMLQuery("DELETE FROM OrderTable");
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string sql;

            if (string.IsNullOrWhiteSpace(this.txtSearchProduct.Text))
            {
                
                sql = "SELECT * FROM MenuTable;";
            }
            else
            {
                sql = "SELECT * FROM MenuTable " +
                      "WHERE FoodName LIKE '" + this.txtSearchProduct.Text + "%';";
                
            }
            this.PopulateMenuGridView(sql);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (this.dgvCartView.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a cart item first.");
                return;
            }
            string orderId = this.dgvCartView.SelectedRows[0].Cells["OrderID"].Value.ToString();
            string foodName = this.dgvCartView.SelectedRows[0].Cells["OrderName"].Value.ToString();
            int cartQty = Convert.ToInt32(this.dgvCartView.SelectedRows[0].Cells["OrderQuantity"].Value);

            //  current MenuTable quantity
            string sqlMenuQty = "SELECT Quantity FROM MenuTable WHERE FoodName = '" + foodName + "';";
            var dt = this.Da.ExecuteQueryTable(sqlMenuQty);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Food item not found in menu.");
                return;
            }
            int menuQty = Convert.ToInt32(dt.Rows[0][0]);
            // Delete from OrderTable
            string sqlDelete = "DELETE FROM OrderTable WHERE OrderID = '" + orderId + "';";
            int count = this.Da.ExecuteDMLQuery(sqlDelete);
            if (count != 1)
            {
                MessageBox.Show("Failed to remove cart item.");
                return;
            }
            // Update MenuTable quantity
            int newMenuQty = menuQty + cartQty;
            string sqlUpdateMenu = "UPDATE MenuTable SET Quantity = " + newMenuQty + " WHERE FoodName = '" + foodName + "';";
            this.Da.ExecuteDMLQuery(sqlUpdateMenu);
            MessageBox.Show("Cart item removed successfully.");
            this.PopulateMenuGridView();
            this.PopulateOrderGridView();
            this.txtQuantity.Clear();

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.parent.Show();
            this.Hide();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_La_Vien
{
    public partial class FormManageMenu : Form
    {
        private FormAdminPanel parent;
        public string FoodID;
        private DataAccess Da { get; set; }
        public FormManageMenu(FormAdminPanel parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.Da = new DataAccess();
            this.PopulateGridView();

        }
       
        private void btnBack_Click(object sender, EventArgs e)
        {
            parent.Show(); 
            this.Hide();
        }
        private void txtFoodID_Enter(object sender, EventArgs e)
        {

            if (txtFoodID.Text == "Food ID")
            {
                txtFoodID.Text = "";
                txtFoodID.ForeColor = Color.Black;
            }
        }
        private void txtFoodID_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtFoodID.Text))
            {
                txtFoodID.Text = "Food ID";
                txtFoodID.ForeColor = Color.Gray;
            }
        }
        private void txtFoodName_Enter(object sender, EventArgs e)
        {
            if (txtFoodName.Text == "Food Name")
            {
                txtFoodName.Text = "";
                txtFoodName.ForeColor = Color.Black;
            }
        }

        private void txtFoodName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                txtFoodName.Text = "Food Name";
                txtFoodName.ForeColor = Color.Gray;
            }
        }

        private void txtFoodPrice_Enter_1(object sender, EventArgs e)
        {
            if (txtFoodPrice.Text == "Food Price")
            {
                txtFoodPrice.Text = "";
                txtFoodPrice.ForeColor = Color.Black;
            }
        }

        private void txtFoodPrice_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodPrice.Text))
            {
                txtFoodPrice.Text = "Food Price";
                txtFoodPrice.ForeColor = Color.Gray;
            }
        }

        private void txtQuantity_Enter_1(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "Quantity")
            {
                txtQuantity.Text = "";
                txtQuantity.ForeColor = Color.Black;
            }
        }

        private void txtQuantity_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                txtQuantity.Text = "Quantity";
                txtQuantity.ForeColor = Color.Gray;
            }
        }

        private bool IsValidToSave()
        {
            if (string.IsNullOrWhiteSpace(this.txtFoodID.Text) || this.txtFoodID.Text == "Food ID" ||
                string.IsNullOrWhiteSpace(this.txtFoodName.Text) || this.txtFoodName.Text == "Food Name" ||
                string.IsNullOrWhiteSpace(this.txtFoodPrice.Text) || this.txtFoodPrice.Text == "Food Price" ||
                string.IsNullOrWhiteSpace(this.txtQuantity.Text) || this.txtQuantity.Text == "Quantity")
                return false;
            else
                return true;
        }




        private void FormManageMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void FormManageMenu_Load(object sender, EventArgs e)
        {
           this.AutoIdGenerate();
        }

        private void btnEditMenu_Click(object sender, EventArgs e)
        {
        //    FormUpdateMenu em = new FormUpdateMenu(this);
        //    em.Show();
        //    this.Visible = false;
        }

        private void txtFoodName_TextChanged(object sender, EventArgs e)
        {

        }


        private void FormManageMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AddMenuForm_Load(object sender, EventArgs e)
        {
            this.AutoIdGenerate();
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the empty fields");
                    return;
                }

                // Prepare SQL for inserting a new menu item
                string sqlMenu = "INSERT INTO MenuTable (FoodID, FoodName, FoodPrice, Quantity) VALUES ('" + this.txtFoodID.Text + "', '" + this.txtFoodName.Text + "', '" + this.txtFoodPrice.Text + "', '" + this.txtQuantity.Text + "')";


                int menuResult = this.Da.ExecuteDMLQuery(sqlMenu);

                if (menuResult == 1)
                    MessageBox.Show("Menu item has been added successfully");
                else
                    MessageBox.Show("Failed to add menu item");
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
            this.PopulateGridView();
            this.ClearAll();
            this.AutoIdGenerate();
        }
        private void ClearAll()
        {
            this.txtFoodID.Text = "";
            this.txtFoodName.Text = "Food Name";
            this.txtFoodName.ForeColor = Color.Gray;

            this.txtFoodPrice.Text = "Food Price";
            this.txtFoodPrice.ForeColor = Color.Gray;

            this.txtQuantity.Text = "Quantity";
            this.txtQuantity.ForeColor = Color.Gray;

            
            this.AutoIdGenerate();
        }

        private void AutoIdGenerate()
        {
            var query = "SELECT ISNULL(MAX(TRY_CAST(SUBSTRING(FoodID, 3, 100) AS INT)), 0) FROM MenuTable;";
            var dt = this.Da.ExecuteQueryTable(query);

            int lastNumber = 0;
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                int.TryParse(dt.Rows[0][0].ToString(), out lastNumber);
            }

            int newNumber = lastNumber + 1;
            string newId = "F-" + newNumber.ToString("D3");

            this.txtFoodID.Text = newId;
            this.FoodID = newId;
        }

        private void PopulateGridView(string sql = "select * from MenuTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvMenuView.AutoGenerateColumns = false;
            this.dgvMenuView.DataSource = ds.Tables[0];

        }

        private void btnUpdateMenu_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the empty fields");
                    return;
                }

                // Check if this FoodID exists
                string checkSql = "SELECT * FROM MenuTable WHERE FoodID = '" + this.txtFoodID.Text + "';";
                DataTable dt = this.Da.ExecuteQueryTable(checkSql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No menu item found with this Food ID");
                    return;
                }

                // Update MenuTable
                string updateSql = @"UPDATE MenuTable
                                SET FoodPrice = '" + this.txtFoodPrice.Text + @"',
                                 Quantity  = '" + this.txtQuantity.Text + @"'
                             WHERE FoodID = '" + this.txtFoodID.Text + "';";

                int result = this.Da.ExecuteDMLQuery(updateSql);

                if (result == 1)
                    MessageBox.Show("Menu item has been updated successfully");
                else
                    MessageBox.Show("Failed to update menu item");
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }

            // Refresh grid and reset fields
            this.PopulateGridView();
            this.ClearAll();
        }

        private void dgvMenuView_DoubleClick(object sender, EventArgs e)
        {
            if (this.dgvMenuView.CurrentRow != null)
            {
                this.txtFoodID.Text = this.dgvMenuView.CurrentRow.Cells["ID"].Value.ToString();
                this.txtFoodName.Text = this.dgvMenuView.CurrentRow.Cells["FoodName"].Value.ToString();
                this.txtFoodPrice.Text = this.dgvMenuView.CurrentRow.Cells["FoodPrice"].Value.ToString();
                this.txtQuantity.Text = this.dgvMenuView.CurrentRow.Cells["Quantity"].Value.ToString();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(this.txtFoodID.Text) || this.txtFoodID.Text == "Food ID")
                {
                    MessageBox.Show("Please enter a valid Food ID to remove");
                    return;
                }
                // Check if this FoodID exists
                string checkSql = "SELECT * FROM MenuTable WHERE FoodID = '" + this.txtFoodID.Text + "';";
                DataTable dt = this.Da.ExecuteQueryTable(checkSql);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No menu item found with this Food ID");
                    return;
                }
                // Delete from MenuTable
                string deleteSql = "DELETE FROM MenuTable WHERE FoodID = '" + this.txtFoodID.Text + "';";
                int result = this.Da.ExecuteDMLQuery(deleteSql);
                if (result == 1)
                    MessageBox.Show("Menu item has been removed successfully");
                else
                    MessageBox.Show("Failed to remove menu item");
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
            // Refresh grid and reset fields
            this.PopulateGridView();
            this.ClearAll();

        }
    }
}


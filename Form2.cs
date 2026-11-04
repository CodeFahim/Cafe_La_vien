using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_La_Vien
{
    public partial class FormSalesRecord : Form
    {
        private Form parent;
        private DataAccess Da { get; set; }
        public FormSalesRecord(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.Da = new DataAccess();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parent.Show();  // show parent again
            this.Hide();
        }

        private void PopulateGridView(string sql = "select * from SellTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvUserView.AutoGenerateColumns = false;
            this.dgvUserView.DataSource = ds.Tables[0];

        }

        private void FormSalesRecord_Load(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == -1)  
            {
                MessageBox.Show("Please select a month first.");
                return;
            }
            int monthNum = comboBox1.SelectedIndex + 1;

            string sql = "select * from SellTable where MONTH(SellDate) = " + monthNum + ";";
            this.PopulateGridView(sql);
        }

        private void FormSalesRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;

            if (comboBox2.SelectedItem.ToString() == "Highest Sell")
            {
                // change Total column name if needed to match your SellTable
                sql = "SELECT * FROM SellTable ORDER BY TotalBill DESC;";
            }
            else // Sort by CashierID
            {
                sql = "SELECT * FROM SellTable ORDER BY CashierID ASC;";
            }

            this.PopulateGridView(sql);
        }
    }
}

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
    public partial class FormCashier : Form
    {
        private string cashierId;
        public FormCashier(string cashierId)
        {
            InitializeComponent();
            this.cashierId = cashierId;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btnSaleHistoryCashier_Click(object sender, EventArgs e)
        {
            FormSalesRecord sr = new FormSalesRecord(this);
            sr.Show();
            this.Visible = false;
        }

      
        private void btnProductManage_Click(object sender, EventArgs e)
        {

            FormMenu mm = new FormMenu(this,this.cashierId); //this inside parameter
            mm.Show();
            this.Visible = false;
        }

        private void btnLogOutCashier_Click(object sender, EventArgs e)
        {
            frmLoginPanel lp = new frmLoginPanel();
            lp.Show();
            this.Hide();
        }

        private void FormCashier_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnProfileCashier_Click(object sender, EventArgs e)
        {
            FormUserProfile up = new FormUserProfile(this, this.cashierId);//, this.cashierId);
            up.Show();
            this.Visible = false;
        }
    }
}

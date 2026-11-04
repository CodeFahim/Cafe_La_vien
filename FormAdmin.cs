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
    public partial class FormAdminPanel : Form
    {


        private frmLoginPanel parent;
        private string adminId;
        public FormAdminPanel(frmLoginPanel parent, string adminId)
        {
            InitializeComponent();
            this.parent = parent;
            this.adminId = adminId;
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            FormUserManage  um = new FormUserManage(this);//this

            um.Show();
            this.Visible = false;
        }

        private void btnProductManage_Click(object sender, EventArgs e)
        {
            FormManageMenu mm = new FormManageMenu(this);
            mm.Show();
            this.Visible = false;
        }

        private void btnSaleHistory_Click(object sender, EventArgs e)
        {
            FormSalesRecord sr = new FormSalesRecord(this);
            sr.Show();
            this.Visible = false;
        }

        private void FormAdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //private void btnCustomerManage_Click(object sender, EventArgs e)
        //{

        //    FormCustomerPanel cm = new FormCustomerPanel(this);
        //    cm.Show();
        //    this.Visible = false;

        //}

       

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOutAdmin_Click_1(object sender, EventArgs e)
        {
            parent.Show();  // show parent again
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {

            FormUserProfile up = new FormUserProfile(this, this.adminId);
            up.Show();
            this.Visible = false;
        }
    }
}

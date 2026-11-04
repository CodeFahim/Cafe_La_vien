using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Cafe_La_Vien
{
    public partial class FormUserProfile : Form
    {
        private DataAccess Da { get; set; }
        private FormAdminPanel adminParent;
        private FormCashier cashierParent;
        private string userId;
        public FormUserProfile(FormAdminPanel parent, string userId ) 
        {
            InitializeComponent();
            this.adminParent = parent;
            this.userId = userId;
            this.Da = new DataAccess();
        }

        public FormUserProfile(FormCashier parent, string userId)
        {
            InitializeComponent();
            this.cashierParent = parent;
            this.userId = userId;
            this.Da = new DataAccess();
        }
        private void btnBackUser_Click(object sender, EventArgs e)
        {
            if (adminParent != null)
            {
                adminParent.Show();      // came from Admin Panel
            }
            else if (cashierParent != null)
            {
                cashierParent.Show();    // came from Cashier
            }

            this.Hide();
        }

        private void FormUserProfile_Load(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrEmpty(this.userId))
            {
                try
                {
                    string sql = "SELECT * FROM UserTable WHERE UserId = '" + this.userId + "';";
                    DataSet ds = Da.ExecuteQuery(sql);

                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        DataRow row = ds.Tables[0].Rows[0];

                        txtUserID.Text = row["UserId"].ToString();
                        txtName.Text = row["Name"].ToString();
                        txtEmail.Text = row["Email"].ToString();
                        txtPhone.Text = row["PhoneNo"].ToString();
                        txtGender.Text = row["Gender"].ToString();
                        txtRole.Text = row["Role"].ToString();


                        string role = row["Role"].ToString();
                        btnEditProfile.Visible = role.Equals("Admin");
                    }
                    else
                    {
                        MessageBox.Show("User details not found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading profile.\n" + ex.Message);
                }

            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            
                FormUserManage um = new FormUserManage(adminParent);
                um.Show();
                this.Hide();     
           
        }

        private void FormUserProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cafe_La_Vien
{
    public partial class frmLoginPanel : Form
    {
        private DataAccess Da { get; set; }
        public frmLoginPanel()
        {
            InitializeComponent();
            Da = new DataAccess();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "User ID")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;              

            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = "User ID";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_Enter_1(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
               
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;

                txtPassword.UseSystemPasswordChar = !ckbPasswordShow.Checked;

            }
        }

        private void txtPassword_Leave_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;

                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                string sql = $"SELECT * FROM Login WHERE UserID = '{this.txtUsername.Text}' AND Password = '{this.txtPassword.Text}'";

                DataSet Ds = Da.ExecuteQuery(sql);

                if (Ds.Tables[0].Rows.Count == 1) 
                {
                    string role = Ds.Tables[0].Rows[0]["Role"].ToString();
                    string userId = Ds.Tables[0].Rows[0]["UserID"].ToString();

                    MessageBox.Show("Welcome " + userId);

                    if (role == "Admin")
                    {
                        FormAdminPanel admin = new FormAdminPanel(this, userId);
                        this.Hide();
                        admin.Show();
                    }
                    else if (role == "Cashier")
                    {
                        string cashierId = Ds.Tables[0].Rows[0]["UserID"].ToString();
                        FormCashier cashier = new FormCashier(cashierId);
                        this.Hide();
                        cashier.Show();
                    }
                    else
                    {
                        MessageBox.Show("Unknown role found. Contact system administrator.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User ID or Password!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error while logging in.\n" + exc.Message);
            }
            finally
            {
                
                this.txtUsername.Text = "User ID";
                this.txtUsername.ForeColor = Color.Gray;

                this.txtPassword.Text = "Password";
                this.txtPassword.ForeColor = Color.Gray;

                this.txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void frmLoginPanel_Load(object sender, EventArgs e)
        {
           this.txtPassword.UseSystemPasswordChar = false;
            this.ckbPasswordShow.Checked = false;
        }

        private void frmLoginPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ckbPasswordShow_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = false; // placeholder always readable
            }
            else if (ckbPasswordShow.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}


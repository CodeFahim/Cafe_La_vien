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
    public partial class FormUserManage : Form
    {
        private DataAccess Da { get; set; }
        private FormAdminPanel parent;
        public string userId;
        public FormUserManage(FormAdminPanel parent)
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.parent = parent;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBackUser_Click(object sender, EventArgs e)
        {
            parent.Show();  
            this.Hide();
        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            if (txtName.Text == "Name")
            {
                txtName.Text = "";
                txtName.ForeColor = Color.Black;
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.Text = "Name";
                txtName.ForeColor = Color.Gray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.Gray;
            }
        }

        private void textPhoneNo_Enter(object sender, EventArgs e)
        {
            if (txtPhoneNo.Text == "Phone Number")
            {
                txtPhoneNo.Text = "";
                txtPhoneNo.ForeColor = Color.Black;
            }
        }

        private void textPhoneNo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhoneNo.Text))
            {
                txtPhoneNo.Text = "Phone Number";
                txtPhoneNo.ForeColor = Color.Gray;
            }
        }

        private void txtPasswordUserManage_Enter(object sender, EventArgs e)
        {
            if (txtPasswordUserManage.Text == "Set Password")
            {
                txtPasswordUserManage.Text = "";
                txtPasswordUserManage.ForeColor = Color.Black;
            }
        }

        private void txtPasswordUserManage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordUserManage.Text))
            {
                txtPasswordUserManage.Text = "Set Password";
                txtPasswordUserManage.ForeColor = Color.Gray;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the empty fields");
                    return;
                }

                string gender = "";
                if (rbMale.Checked)
                    gender = "Male";
                else if (rbFemale.Checked)
                    gender = "Female";
                else
                    gender = "Not Selected";

                string role = this.cmbRole.SelectedItem.ToString();

                // ADD Login
                string sqlLogin = "insert into LogIn values('" + userId + "','" + this.txtPasswordUserManage.Text + "','" + this.cmbRole.Text + "')";

                int loginResult = this.Da.ExecuteDMLQuery(sqlLogin);

                if (loginResult == 1)
                {
                    //ADD Admin
                    string sqlAdmin = "insert into UserTable values('" + userId + "','" + this.txtName.Text + "','" + this.txtEmail.Text + "','" + this.txtPhoneNo.Text + "','" + gender + "','" + this.cmbRole.Text + "','" + this.txtPasswordUserManage.Text + "')";


                    int adminResult = this.Da.ExecuteDMLQuery(sqlAdmin);

                    if (adminResult == 1)
                        MessageBox.Show("User has been added successfully");
                    else
                        MessageBox.Show("User was added to Login but not to Admin");
                }
                else
                {
                    MessageBox.Show("Failed to add user to Login");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
            this.PopulateGridView();
            ClearAll();

        }
        private void ClearAll()
        {
            this.txtUserID.Text = "";
            this.txtName.Text = "Name";
            this.txtName.ForeColor = Color.Gray;

            this.txtEmail.Text = "Email";
            this.txtEmail.ForeColor = Color.Gray;

            this.txtPhoneNo.Text = "Phone Number";
            this.txtPhoneNo.ForeColor = Color.Gray;

            this.txtPasswordUserManage.Text = "Set Password";
            this.txtPasswordUserManage.ForeColor = Color.Gray;

            this.rbMale.Checked = false;
            this.rbFemale.Checked = false;

            this.cmbRole.SelectedIndex = -1;
            this.AutoIdGenerate();
        }

        private bool IsValidToSave()
        {
            if (string.IsNullOrEmpty(this.txtUserID.Text) ||
                string.IsNullOrEmpty(this.txtName.Text) || this.txtName.Text == "Name" ||
                string.IsNullOrEmpty(this.txtEmail.Text) || this.txtEmail.Text == "Email" ||
                string.IsNullOrEmpty(this.txtPhoneNo.Text) || this.txtPhoneNo.Text == "Phone Number" ||
                string.IsNullOrEmpty(this.txtPasswordUserManage.Text) || this.txtPasswordUserManage.Text == "Set Password" ||
                this.cmbRole.SelectedItem == null)
                return false;
            else
                return true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void FormUserManage_Load(object sender, EventArgs e)
        {
            this.AutoIdGenerate();
            this.dgvUserView.ClearSelection();
        }
        private void AutoIdGenerate()
        {
           
            var query = "SELECT ISNULL(MAX(TRY_CAST(SUBSTRING(UserID, 3, 100) AS INT)), 0) FROM Login;";
            var dt = this.Da.ExecuteQueryTable(query);

            int lastNumber = 0;
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                int.TryParse(dt.Rows[0][0].ToString(), out lastNumber);
            }

            int newNumber = lastNumber + 1;
            string newId = "A-" + newNumber.ToString("D3");

            this.txtUserID.Text = newId;
            this.userId = newId;
        }

        private void FormUserManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void PopulateGridView(string sql = "select * from UserTable;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.dgvUserView.AutoGenerateColumns = false;
            this.dgvUserView.DataSource = ds.Tables[0];

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the empty fields");
                    return;
                }

                var query = "select * from UserTable where UserId ='" + this.txtSearchID.Text + "';";
                var dt = this.Da.ExecuteQueryTable(query);
               
                string sqlLogin = @"update LogIn
                        set Password = '" + this.txtPasswordUserManage.Text + @"',
                            Role = '" + this.cmbRole.Text + @"'
                        where UserID= '" + this.txtUserID.Text + "';";

                int loginResult = this.Da.ExecuteDMLQuery(sqlLogin);

                if (loginResult == 1)
                {
                  
                    string gender = "";
                    if (rbMale.Checked)
                        gender = "Male";
                    else if (rbFemale.Checked)
                        gender = "Female";
                    else
                        gender = "Not Selected";

                    string sqlAdmin = @"update UserTable
                            set Name = '" + this.txtName.Text + @"',
                                Gender = '" + gender + @"',
                                Email = '" + this.txtEmail.Text + @"',
                                PhoneNo = '" + this.txtPhoneNo.Text + @"',
                                Role = '" + this.cmbRole.Text + @"',
                                Password = '" + this.txtPasswordUserManage.Text + @"'
                            where UserId = '" + this.txtUserID.Text + "';";

                    int adminResult = this.Da.ExecuteDMLQuery(sqlAdmin);

                    if (adminResult == 1)
                        MessageBox.Show("User has been updated successfully");
                    else
                        MessageBox.Show("User was updated in Login but not in Admin");
                }
                else
                {
                    MessageBox.Show("Failed to update user in Login");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
            this.PopulateGridView();
            ClearAll();
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {

            string sql = "select * from UserTable where Name = '" + this.txtSearchName.Text + "';";
            this.PopulateGridView(sql);
        }

        private void btnSearchID_Click(object sender, EventArgs e)
        {

            string sql = "select * from UserTable where UserId = '" + this.txtSearchID.Text + "';";
            this.PopulateGridView(sql);

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {

            this.PopulateGridView();
            this.txtSearchID.Text = "";
            this.txtSearchName.Text = "";
            this.dgvUserView.ClearSelection();
        }

        private void dgvUserView_DoubleClick(object sender, EventArgs e)
        {

           
    if (this.dgvUserView.CurrentRow != null)
    {
        this.txtUserID.Text = this.dgvUserView.CurrentRow.Cells["AdminID"].Value.ToString();
        this.txtName.Text = this.dgvUserView.CurrentRow.Cells["UserName"].Value.ToString();
        this.txtEmail.Text = this.dgvUserView.CurrentRow.Cells["Email"].Value.ToString();
        this.txtPhoneNo.Text = this.dgvUserView.CurrentRow.Cells["PhoneNo"].Value.ToString();
        this.cmbRole.Text = this.dgvUserView.CurrentRow.Cells["Role"].Value.ToString();
        this.txtPasswordUserManage.Text = this.dgvUserView.CurrentRow.Cells["Password"].Value.ToString();

        string gender = this.dgvUserView.CurrentRow.Cells["Gender"].Value.ToString();//Value?
                this.rbMale.Checked = (gender == "Male");
        this.rbFemale.Checked = (gender == "Female");
    }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUserView.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to delete.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                var id = this.dgvUserView.CurrentRow.Cells[0].Value.ToString();
                var query = "select * from UserTable where UserId ='" + id + "';";
                var dt = this.Da.ExecuteQueryTable(query);
                if (dt.Rows.Count == 1)
                {
                    string sqlLogin = "delete from LogIn where UserID = '" + id + "';";
                    int loginResult = this.Da.ExecuteDMLQuery(sqlLogin);
                    if (loginResult == 1)
                    {
                        string sqlAdmin = "delete from UserTable where UserId = '" + id + "';";
                        int adminResult = this.Da.ExecuteDMLQuery(sqlAdmin);
                        if (adminResult == 1)
                            MessageBox.Show("User has been deleted successfully");
                        else
                            MessageBox.Show("User was deleted from Login but not from Admin");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user from Login");
                    }
                }
                else
                {
                    MessageBox.Show("No such user found to delete.");
                }
                this.PopulateGridView();
                this.ClearAll();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred: " + exc.Message);
            }
        }
    }
}

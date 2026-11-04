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
    public partial class FormCustomerPanel : Form
    {
        private Form parent;
        public FormCustomerPanel(Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parent.Show();  // show parent again
            this.Close();
        }
    }
}

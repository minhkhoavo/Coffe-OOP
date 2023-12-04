using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Coffee.Form
{
    public partial class fManagerLogin : System.Windows.Forms.Form
    {
        public string name { get; set; }    
        public string password { get; set; }
        public fManagerLogin()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Nhập đầy đủ Name và Password!", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                name = txtName.Text;
                password = txtPass.Text;
                this.Close();
            }
        }
    }
}

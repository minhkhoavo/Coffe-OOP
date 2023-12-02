using OOP_Coffee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace OOP_CoffeeApp
{
    public partial class fLogin : System.Windows.Forms.Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                if (customerRadio.Checked)
                {
                    if (Customer.checkLogin(username, password))
                    {
                        MessageBox.Show("Success login");
                        Form1 customerForm = new Form1(int.Parse(username));
                        customerForm.Show();  
                        this.DialogResult = DialogResult.OK;
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng thử lại. Sai username hoặc Password");
                    }
                }
                else if (baristaRadio.Checked)
                {
                    if (Barista.checkLogin(username, password))
                    {
                        MessageBox.Show("Success login");

                        ParistaFrm baristaForm = new ParistaFrm();
                        baristaForm.Show();
                        this.DialogResult = DialogResult.OK;
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng thử lại. Sai username hoặc Password");
                    }
                }
                else
                {
                    if (Manager.checkLogin(username, password))
                    {
                        MessageBox.Show("Success login");

                        fAdmin fAminForm = new fAdmin();
                        fAminForm.Show();
                        this.DialogResult = DialogResult.OK;
                        //this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng thử lại. Sai username hoặc Password");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

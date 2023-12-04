using OOP_Coffee.Form.UserControlUI;
using OOP_CoffeeApp;
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
    public partial class fPayment : System.Windows.Forms.Form
    {
        private List<Order> orders = new List<Order>();
        int OrderID;
        Customer customer = null;
        public fPayment(List<Order> orders, int OrderID, Customer customer)
        {
            InitializeComponent();
            this.orders = orders;
            this.OrderID = OrderID;
            this.customer = customer;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            CardPayment cards = new CardPayment();
            panel2.Controls.Add(cards);

            PictureBox pictureBox4 = new PictureBox();
            pictureBox4.Image = Properties.Resources.OK;
            panel2.Controls.Add(pictureBox4);
            pictureBox4.Location = new System.Drawing.Point(100, 180);
            pictureBox4.Size = new System.Drawing.Size(107, 63);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

            pictureBox4.Click += CardPaymentHandler;
        }
        private void CardPaymentHandler(object sender, EventArgs e)
        {
            foreach (Control control in panel2.Controls)
            {
                if (control is CardPayment)
                {
                    CardPayment cardPayment = (CardPayment)control;
                    if(cardPayment.checkValid())
                    {
                        customer.Pays("Cards");
                        fFeedback fFeedbackForm = new fFeedback(orders, OrderID, customer);
                        fFeedbackForm.Show();
                        this.Close();
                    } else
                    {
                        MessageBox.Show("Thông tin không hợp lệ!");
                    }
                    break; 
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            PictureBox pictureBox = new PictureBox();
            pictureBox.BorderStyle = BorderStyle.None;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = panel2.Size;  
            panel2.Controls.Add(pictureBox);
            pictureBox.Location = new Point(0, 0);
            pictureBox.Image = Properties.Resources.promptpay___scan;

            PictureBox pictureBox4 = new PictureBox();
            pictureBox4.Image = Properties.Resources.OK;
            panel2.Controls.Add(pictureBox4);
            pictureBox4.Location = new System.Drawing.Point(100, 250);
            pictureBox4.Size = new System.Drawing.Size(107, 63);
            pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox4.Click += QR_Click;
        }
        private void QR_Click(object sender, EventArgs e)
        {
            customer.Pays("QR");
            fFeedback fFeedbackForm = new fFeedback(orders, OrderID, customer);
            fFeedbackForm.Show();
            this.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            customer.Pays("Tiền mặt");
            fFeedback fFeedbackForm = new fFeedback(orders, OrderID, customer);
            fFeedbackForm.Show();
            this.Close();
        }
    }
}

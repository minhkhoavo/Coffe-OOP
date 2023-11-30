using OOP_Coffee.Form.UserControlUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CoffeeApp
{
    public partial class fFeedback : System.Windows.Forms.Form
    {
        private List<Order> orders = new List<Order>();
        public fFeedback(List<Order> orders)
        {
            InitializeComponent();
            try
            {
                foreach (var order in orders)
                {
                    OrderPayment orderPayment = new OrderPayment(order.Img, order.Id, order.NameOrder, order.Quantity, order.Price * order.Quantity, "Note", "Chờ xử lý");
                    flowLayoutPanel1.Controls.Add(orderPayment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

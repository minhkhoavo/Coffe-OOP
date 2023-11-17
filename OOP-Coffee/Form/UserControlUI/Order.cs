using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CoffeeApp.Form.UserControlUI
{
    public partial class Order : UserControl
    {

        public Order()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Order
            // 
            this.Name = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.ResumeLayout(false);

        }

        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

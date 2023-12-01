using OOP_Coffee;
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
        decimal refundMoney = decimal.Zero;
        int lastRefundOrderItemId;
        public fFeedback(List<Order> orders)
        {
            //this.ControlBox = false;
            InitializeComponent();
            total_lbl.Text = Form1.total.ToString("0.00") + "$";
            try
            {
                foreach (var order in orders)
                {
                    OrderPayment orderPayment = new OrderPayment(order.Img, order.Id, order.OrderItemID ,order.NameOrder, order.Quantity, order.Price * order.Quantity, order.Note, "Chờ xử lý");
                    orderPayment.StatusRejected += HandleRejectedStatus;
                    flowLayoutPanel1.Controls.Add(orderPayment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        // Handler Rejected order
        private void HandleRejectedStatus(object sender, int refundOrderItemId)
        {
            if(refundOrderItemId != lastRefundOrderItemId)
            {
                CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
                var orderItem = db.OrderItemDBs.FirstOrDefault(item => item.OrderItemID == refundOrderItemId);

                if (orderItem != null)
                {
                    MessageBox.Show(orderItem.Quantity.ToString());
                    decimal refundAmount = orderItem.Price * orderItem.Quantity; 
                    refundMoney += refundAmount;
                }
                lastRefundOrderItemId = refundOrderItemId;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(refundMoney !=  0)
            {
                MessageBox.Show($"Số tiền {refundMoney}$ do các đơn hàng bị hủy sẽ được hoàn lại vào tài khoản của bạn sau 1 ngày");
            }
        }
    }
}

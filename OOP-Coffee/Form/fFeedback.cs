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
        int OrderID;
        int lastRefundOrderItemId;
        public fFeedback(List<Order> orders, int OrderID)
        {
            this.ControlBox = false;
            InitializeComponent();
            InitializeTimer();
            this.OrderID = OrderID;
            total_lbl.Text = Form1.total.ToString("0.00") + "$";
            try
            {
                foreach (var order in orders)
                {
                    OrderPayment orderPayment = new OrderPayment(order.Img, order.Id, order.OrderItemID ,order.NameOrder, order.Quantity, order.Price * order.Quantity, order.Note, "Chờ xử lý");
                    flowLayoutPanel1.Controls.Add(orderPayment);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private System.Windows.Forms.Timer statusUpdateTimer;
        private void InitializeTimer()
        {
            statusUpdateTimer = new Timer();
            statusUpdateTimer.Interval = 5000;
            statusUpdateTimer.Tick += StatusUpdateTimer_Tick;
            statusUpdateTimer.Start();
        }
        private void StatusUpdateTimer_Tick(object sender, EventArgs e)
        {
            CheckOrderItemStatus(OrderID);
        }
        private void CheckOrderItemStatus(int OrderID)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            bool allOrdersHaveStatus = db.OrderItemDBs
                .Where(item => item.OrderID == OrderID)
                .All(item => item.Status == "Completed" || item.Status == "Rejected");

            panel1.Enabled = allOrdersHaveStatus; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var orderItems = db.OrderItemDBs.Where(item => item.OrderID == OrderID).ToList();

            foreach (var orderItem in orderItems)
            {
                if (orderItem.Status == "Rejected")
                {
                    refundMoney += orderItem.Price * orderItem.Quantity; 
                }
            }

            if (refundMoney !=  0)
            {
                MessageBox.Show($"Số tiền {refundMoney}$ do các đơn hàng bị hủy sẽ được hoàn lại vào tài khoản của bạn sau 1 ngày");
            }
            Repositories.updateSaleSummaryDB(OrderID);
            Repositories.updateRevenueAndProfit(OrderID);
            MessageBox.Show("Cảm ơn bạn đã mua hàng!");
            this.Close();
        }
    }
}

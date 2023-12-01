using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Coffee.Form.UserControlUI
{
    public partial class OrderPayment : UserControl
    {
        int idProduct; // id san pham in DB
        string name;
        int quantity;
        string note;
        string status;
        Image image;
        int orderItemID;
        public Image Image { get => this.image; set => this.image = value; }
        public int IdProduct { get => idProduct; set => idProduct = value; }
        public string NameProduct { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Note { get => note; set => note = value; }
        public string Status { get => status; set => status = value; }
        public int OrderItemID { get => orderItemID; set => orderItemID = value; }

        public OrderPayment()
        {
            InitializeComponent();
        }
        public event EventHandler<int> StatusRejected;
        public OrderPayment(Image image, int idProduct, int orderItemID, string nameProduct, int quantity, decimal total, string note, string status)
        {
            InitializeComponent();
            InitializeTimer();
            //string message = $"Image: {image}\nId: {idProduct}\nNameProduct: {nameProduct}\nQuantity: {quantity}\nTotal: {total.ToString("0.00")}\nNote: {note}\nStatus: {status}";
            //MessageBox.Show(message);

            Image = image;
            IdProduct = idProduct;
            NameProduct = nameProduct;
            Quantity = quantity;
            Note = note;
            Status = status;
            OrderItemID = orderItemID;

            orderName_lbl.Text = NameProduct;
            quantity_lbl.Text = Quantity.ToString();
            orderTotal_lbl.Text = total.ToString("0.00") + "$";
            orderNote_lbl.Text = Note;
            orderImg.Image = image;
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
            CheckAndUpdateStatus();
        }

        public void CheckAndUpdateStatus()
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var orderItem = db.OrderItemDBs.FirstOrDefault(item => item.OrderItemID == OrderItemID);
            if (orderItem != null)
            {
                if (orderItem.Status != Status)
                {
                    Status = orderItem.Status;
                    status_lbl.Text = Status; 
                }
                if (Status == "Rejected")
                {
                    status_lbl.Text = "Đã hủy";
                    status_lbl.ForeColor = Color.Red; 
                    OnStatusRejected(orderItem.ItemId);
                    statusUpdateTimer.Stop();
                }
                else if (Status == "Completed")
                {
                    status_lbl.Text = "Đã hoàn thành";
                    status_lbl.ForeColor = Color.Blue; 
                    statusUpdateTimer.Stop(); 
                } else
                {
                    status_lbl.Text = "Đang xử lý";
                    status_lbl.ForeColor = Color.Yellow;
                }
            }
        }
        protected virtual void OnStatusRejected(int refundOrderItemId)
        {
            StatusRejected?.Invoke(this, refundOrderItemId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace OOP_Coffee.Form.UserControlUI
{
    public partial class Order : UserControl
    {
        public static decimal totalPriceOrder;
        private string nameOrder; // tên sản phẩm
        private decimal price;
        private int id;
        private int quantity;
        private string note;
        private int orderID;
        private int orderItemID;
        public decimal Price { get => price; set => price = value; }
        public string NameOrder { get => nameOrder; set => nameOrder = value; }
        public Image Img
        {
            get { return orderImg.Image; }
            set { orderImg.Image = value; }
        }
        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Note { get => note; set => note = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public int OrderItemID { get => orderItemID; set => orderItemID = value; }

        public Order()
        {
            InitializeComponent();
            string priceText = orderPrice_lbl.Text.Replace("$", "");
            orderTotal_lbl.Text = "$" + priceText;
        }
        public Order(int Id, string NameOrder, decimal Price, Image Img)
        {
            InitializeComponent();
            orderName_lbl.Text = NameOrder;
            orderImg.Image = Img;
            orderPrice_lbl.Text = "$" + Price.ToString("0.00");
            orderTotal_lbl.Text = "$" + Price.ToString("0.00");
            this.Price = Price;
            this.Id = Id;
            this.NameOrder = NameOrder;
            this.Img = Img;
            this.Quantity = 1;
        }
        public event EventHandler OrderDeleted; // Sự kiện khi nút xóa được nhấn
        public event EventHandler<NumericChangeValue> numericValueChange; // Numeric Event

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal oldPrice = decimal.Parse(orderTotal_lbl.Text.Replace("$", ""));
            decimal orderPrice = decimal.Parse(orderPrice_lbl.Text.Replace("$", ""));
            int quantity = (int)numericUpDown1.Value;
            this.Quantity = quantity;
            decimal newOrderTotal = orderPrice * quantity;

            numericValueChange?.Invoke(this, new NumericChangeValue(newOrderTotal - oldPrice));

            orderTotal_lbl.Text = "$" + newOrderTotal.ToString("0.00");
            totalPriceOrder = newOrderTotal; 
        }
        public void IncrementNumericUpDown()
        {
            numericUpDown1.Value += 1;
            decimal oldPrice = decimal.Parse(orderTotal_lbl.Text.Replace("$", ""));
            decimal orderPrice = decimal.Parse(orderPrice_lbl.Text.Replace("$", ""));
            int quantity = (int)numericUpDown1.Value;
            this.Quantity = quantity;
            decimal newOrderTotal = orderPrice * quantity;

            numericValueChange?.Invoke(this, new NumericChangeValue(orderPrice));

            orderTotal_lbl.Text = "$" + newOrderTotal.ToString("0.00");
            totalPriceOrder = newOrderTotal;
        }
        public int ProductQuantity()
        {
            return Convert.ToInt32(numericUpDown1.Value);
        }
        // Event 
        private void orderDelete_btn_Click(object sender, EventArgs e)
        {
            OrderDeleted?.Invoke(this, EventArgs.Empty);
        }
    }
}

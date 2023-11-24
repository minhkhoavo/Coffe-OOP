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
        static double totalPriceOrder;
        private string nameOrder;
        private double price;
        private int id;
        public double Price { get => price; set => price = value; }
        public string NameOrder { get => nameOrder; set => nameOrder = value; }
        public Image Img
        {
            get { return orderImg.Image; }
            set { orderImg.Image = value; }
        }
        public int Id { get => id; set => id = value; }
        private bool isUserControlInitialized = false;

        public Order()
        {
            InitializeComponent();
            string priceText = orderPrice_lbl.Text.Replace("$", "");
            orderTotal_lbl.Text = "$" + priceText;
            isUserControlInitialized = true;
        }
        public Order(int Id, string nameOrder, double Price, Image Img)
        {
            InitializeComponent();
            orderName_lbl.Text = nameOrder;
            orderImg.Image = Img;
            orderPrice_lbl.Text = "$" + Price.ToString();
            orderTotal_lbl.Text = "$" + Price.ToString();
            this.Price = Price;
            this.Id = Id;
            isUserControlInitialized = true;
        }
        public event EventHandler OrderDeleted; // Sự kiện khi nút xóa được nhấn
        public event EventHandler<NumericChangeValue> numericValueChange; // Numeric Event

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double oldPrice = double.Parse(orderTotal_lbl.Text.Replace("$", ""));
            double orderPrice = double.Parse(orderPrice_lbl.Text.Replace("$", ""));
            int quantity = (int)numericUpDown1.Value;
            double newOrderTotal = orderPrice * quantity;

            numericValueChange?.Invoke(this, new NumericChangeValue(newOrderTotal - oldPrice));

            orderTotal_lbl.Text = "$" + newOrderTotal.ToString();
            totalPriceOrder = newOrderTotal; 
        }
        public void IncrementNumericUpDown()
        {
            numericUpDown1.Value += 1;
            double oldPrice = double.Parse(orderTotal_lbl.Text.Replace("$", ""));
            double orderPrice = double.Parse(orderPrice_lbl.Text.Replace("$", ""));
            int quantity = (int)numericUpDown1.Value;
            double newOrderTotal = orderPrice * quantity;

            numericValueChange?.Invoke(this, new NumericChangeValue(orderPrice));

            orderTotal_lbl.Text = "$" + newOrderTotal.ToString();
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

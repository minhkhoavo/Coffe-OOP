using OOP_Coffee;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Schema;
using WinFormsApp1.Model;
using System;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Linq;
using System.Collections.Generic;
using WinFormsApp1;
using OOP_Coffee.Form.UserControlUI;
using System.Diagnostics;
using System.IO;

namespace OOP_CoffeeApp
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private List<Order> orders = new List<Order>();
        static decimal total = 0;
        public Form1()
        {
            InitializeComponent();
            //this.products = products;
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
                string projectPath = AppDomain.CurrentDomain.BaseDirectory;
                for (int i = 0; i < 3; i++)
                {
                    projectPath = Directory.GetParent(projectPath).FullName;
                }

                var products = from item in db.ItemDBs
                                select new
                                {
                                    Id = item.ItemId,
                                    Name = item.ItemName,
                                    Price = Convert.ToDecimal(item.Price),
                                    Img = Path.Combine(projectPath, "Images", Path.GetFileName(item.ItemImage)) // Kết hợp đường dẫn
                                };
                foreach (var product in products)
                {
                    Product productControl = new Product(product.Id, product.Name, product.Price, Image.FromFile(product.Img));
                    flowLayoutPanel1.Controls.Add(productControl);
                    productControl.ProductClicked += ProductControl_ProductClicked;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load data sản phẩm: {ex.Message}");
            }
        }
        private void ProductControl_ProductClicked(object sender, ProductClickedEventArgs e)
        {
            int productId = e.Id;
            string productName = e.ProductName;
            decimal productPrice = Convert.ToDecimal(e.ProductPrice);
            Image productImage = e.ProductImage;

            string message = $"Tên Sản Phẩm: {productName} ID: {productId} \nGiá: {productPrice}";
            MessageBox.Show(message, "Thông Tin Sản Phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            bool found = false;
            foreach (Order order in orders)
            {
                if (order.Id == productId)
                {
                    found = true;
                    order.IncrementNumericUpDown();
                    break;
                }
            }

            if (!found)
            {
                Order orderEl = new Order(productId, productName, productPrice, productImage);
                orderEl.OrderDeleted += OrderForm_OrderDeleted;
                orderEl.numericValueChange += NumericValueChangeAction;
                //SetControlBorderRadius(orderEl, 9);
                orders.Add(orderEl);
                flowLayoutPanel2.Controls.Add(orderEl);
                total += productPrice;
            }

            total_lbl.Text = "$" + total.ToString("0.00");
            
        }
        private void NumericValueChangeAction(object sender, NumericChangeValue e)
        {
            total += e.Value;
            total_lbl.Text = "$" + total.ToString("0.00");
        }
        private void OrderForm_OrderDeleted(object sender, EventArgs e)
        {
            if (sender is Order orderForm)
            {
                total = total - orderForm.Price * orderForm.ProductQuantity();
                total_lbl.Text = "$" + total.ToString("0.00");
                flowLayoutPanel2.Controls.Remove(orderForm);
                orders.Remove(orderForm);
                orderForm.Dispose(); 
            }
        }
        private void Order_DeleteClicked(object sender, EventArgs e)
        {
            //Order clickedOrder = (Order)sender;
        }

        private void SetControlBorderRadius(Control control, int borderRadius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, borderRadius * 2, borderRadius * 2), 180, 90);
            path.AddArc(new Rectangle(control.Width - borderRadius * 2, 0, borderRadius * 2, borderRadius * 2), 270, 90);
            path.AddArc(new Rectangle(control.Width - borderRadius * 2, control.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2), 0, 90);
            path.AddArc(new Rectangle(0, control.Height - borderRadius * 2, borderRadius * 2, borderRadius * 2), 90, 90);
            control.Region = new Region(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fFeedback fFeedbackForm = new fFeedback(orders);
            fFeedbackForm.ShowDialog();
        }
    }
}

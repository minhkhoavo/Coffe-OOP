﻿using OOP_Coffee;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml.Schema;
using WinFormsApp1.Model;
using System;
using System.Data;
using System.Drawing;
using System.Data.Linq;
using System.Linq;
using DotNetEnv;
using System.Collections.Generic;
using WinFormsApp1;
using OOP_Coffee.Form.UserControlUI;
using System.Diagnostics;

namespace OOP_CoffeeApp
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private List<Order> orders = new List<Order>();
        private List<Product> products;
        static double total = 0;
        public Form1()
        {
            InitializeComponent();
            //this.products = products;
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                // Load .env file
                DotNetEnv.Env.Load();

                // Lấy giá trị từ môi trường
                string dataSource = Environment.GetEnvironmentVariable("DB_DATASOURCE");
                string initialCatalog = Environment.GetEnvironmentVariable("DB_INITIAL_CATALOG");
                string connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security=True";
                using (LinQDBDataContext context = new LinQDBDataContext("Data Source=DESKTOP-C8B20IS;Initial Catalog=CoffeeDB;Integrated Security=True"))
                {
                    var products = from item in context.Items
                                   select new
                                   {
                                       Id = item.ItemID,
                                       Name = item.Name,
                                       Price = Convert.ToDouble(item.Price),
                                       Img = item.ImageURL
                                   };

                    foreach (var product in products)
                    {
                        Product productControl = new Product(product.Id, product.Name, product.Price, Image.FromFile(product.Img));
                        flowLayoutPanel1.Controls.Add(productControl);
                        productControl.ProductClicked += ProductControl_ProductClicked;
                    }
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
            double productPrice = e.ProductPrice;
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

            total_lbl.Text = "$" + total.ToString();
            
        }
        private void NumericValueChangeAction(object sender, NumericChangeValue e)
        {
            total += e.Value;
            total_lbl.Text = "$" + total.ToString();
        }
        private void OrderForm_OrderDeleted(object sender, EventArgs e)
        {
            if (sender is Order orderForm)
            {
                total = total - orderForm.Price * orderForm.ProductQuantity();
                total_lbl.Text = "$" + total.ToString();
                flowLayoutPanel2.Controls.Remove(orderForm); 
                orders.Remove(orderForm);
                orderForm.Dispose(); // Giải phóng tài nguyên của orderForm (để tránh rò rỉ bộ nhớ)
            }
        }
        private void Order_DeleteClicked(object sender, EventArgs e)
        {
            Order clickedOrder = (Order)sender;
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

        private void button1_Click(object sender, System.EventArgs e)
        {

        }
    }
}

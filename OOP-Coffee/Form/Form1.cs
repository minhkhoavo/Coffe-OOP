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
using DotNetEnv;

namespace OOP_CoffeeApp
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
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
                                       Price = item.Price ?? 0.0,
                                       Img = item.ImageURL
                                   };

                    foreach (var product in products)
                    {
                        Product productControl = new Product(product.Id, product.Name, product.Price, Image.FromFile(product.Img));
                        flowLayoutPanel1.Controls.Add(productControl);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            
        }
    }
}

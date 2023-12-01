using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Model
{
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
        }
        private int id;
        private string name;
        private decimal price;
        public decimal Price { get => price; set => price = value; }
        public string Name { get => name; set => name = value; }

        public Image Img
        {
            get { return proImg.Image; }
            set { proImg.Image = value; }
        }
        public int Id { get => id; set => id = value; }
        public Product(int id, string name, decimal price, Image img)
        {
            InitializeComponent();
            Id = id;
            Name = name;
            Price = price;
            Img = img;

            proName_lbl.Text = name;
            proPrice_lbl.Text = "$" + price.ToString("0.00");
            proImg.Image = img;
        }

        public Product(int id, string name, decimal price)
        {
            InitializeComponent();
            Id = id;
            Name = name;
            Price = price;

            proName_lbl.Text = name;
            proPrice_lbl.Text = "$" + price.ToString("0.00");
        }
        public event EventHandler<ProductClickedEventArgs> ProductClicked;
        private void Product_Click(object sender, EventArgs e)
        {
            ProductClicked?.Invoke(this, new ProductClickedEventArgs(Id, Name, Price, Img));
        }
        private void Product_Load(object sender, EventArgs e)
        {

        }

        private void Product_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Product_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
    }
}

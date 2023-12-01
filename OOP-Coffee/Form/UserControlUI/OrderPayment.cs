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

        public OrderPayment(Image image, int idProduct, int orderItemID, string nameProduct, int quantity, decimal total, string note, string status)
        {
            InitializeComponent();
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
            orderTotal_lbl.Text = total.ToString("0.00");
            orderNote_lbl.Text = Note;
            orderImg.Image = image;
        }
    }
}

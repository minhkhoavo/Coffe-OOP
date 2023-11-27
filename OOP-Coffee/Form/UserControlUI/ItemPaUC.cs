using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace OOP_Coffee
{
    public class DataItemPaUC : EventArgs
    {
        public string OrderItemID { get; set; }

        public DataItemPaUC(string orderItemID)
        {
            OrderItemID = orderItemID;
        }
    }
    public partial class ItemPaUC : UserControl
    {
        private string OrderID;
        private string OrderItemID;
        private string itemName;
        private string sl;
        private string time;
        private string note;
        private string linkImag;
        private string cusName;
        private string phone;
        private string baristaID;


        public event EventHandler<DataItemPaUC> YesButtonClick;
        public event EventHandler<DataItemPaUC> NoButtonClick;
        public ItemPaUC()
        {
            InitializeComponent();
        }
        public ItemPaUC(string OrderID,string OrderItemID,string itemName, string sl, string time, string note, string linkImag,
                    string cusName,string phone,string baristaID)
        {
            InitializeComponent();

            this.OrderID = OrderID;
            this.OrderItemID = OrderItemID;
            this.itemName = itemName;
            this.sl = sl;
            this.time = time;
            this.note = note;
            this.linkImag = linkImag;
            this.cusName = cusName;
            this.phone = phone;
            this.baristaID = baristaID;

            hienThi();
        }
        public void hienThi()
        {
            lblID.Text = OrderID + "-" + OrderItemID;
            lblItem.Text = itemName;
            lblSL.Text = sl;
            lblTime.Text = time;
            lblNote.Text = note;

            lblCusName.Text = cusName;
            lblPhone.Text = phone;
            lblBaristaID.Text = baristaID;

            //chua gan image
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        //button NO
        private void button2_Click(object sender, EventArgs e)
        {
            NoButtonClick?.Invoke(this, new DataItemPaUC(OrderItemID));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        //button Yes
        private void button1_Click(object sender, EventArgs e)
        {
            YesButtonClick?.Invoke(this, new DataItemPaUC(OrderItemID));
        }

        private void ItemPaUC_Load(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }
    }
}

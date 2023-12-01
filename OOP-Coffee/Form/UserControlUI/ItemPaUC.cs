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
        public int OrderItemID { get; set; }

        public DataItemPaUC(int orderItemID)
        {
            OrderItemID = orderItemID;
        }
    }
    public partial class ItemPaUC : UserControl
    {
        private int OrderID;
        private int OrderItemID;
        private string itemName;
        private int sl;
        private DateTime time;
        private string note;
        private string linkImag;
        private string cusName;
        private string phone;
        private int baristaID;


        public event EventHandler<DataItemPaUC> YesButtonClick;
        public event EventHandler<DataItemPaUC> NoButtonClick;
        public ItemPaUC()
        {
            InitializeComponent();
        }
        /*                ItemPaUC item = new ItemPaUC(gr.orderID.ToString(),gr.orderItemID.ToString(),gr.itemName,gr.quantity.ToString(),gr.date.ToString(),gr.note, gr.itemImg,
                                                gr.customer, gr.phone, gr.baristaID.ToString());*/
        public ItemPaUC(int OrderID,int OrderItemID,string itemName,int sl, DateTime time, string note, string linkImag,
                    string cusName,string phone,int baristaID)
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
            lblID.Text = OrderItemID.ToString() +" - "+ OrderID.ToString();
            lblItem.Text = itemName;
            lblSL.Text = sl.ToString();
            lblTime.Text = time.ToString();
            lblNote.Text = note;

            lblCusName.Text = cusName;
            lblPhone.Text = phone;
            lblBaristaID.Text = baristaID.ToString();

            //chua gan image
        }

        //button NO
        private void button2_Click(object sender, EventArgs e)
        {
            NoButtonClick?.Invoke(this, new DataItemPaUC(OrderItemID));
        }
        
        //button Yes
        private void button1_Click(object sender, EventArgs e)
        {
            YesButtonClick?.Invoke(this, new DataItemPaUC(OrderItemID));
        }
    }
}

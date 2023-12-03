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
using System.Reflection;

namespace OOP_Coffee
{
    public partial class ItemPaUC : UserControl
    {
        private DateTime time;
        private int soLuong;
        private string nameCus;
        private int baristaID;
        private int orderID;

        public event EventHandler<DataItemPaUC> YesButtonClick;
        public event EventHandler<DataItemPaUC> NoButtonClick;
        

        public DateTime Time { get => time; set => time = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string NameCus { get => nameCus; set => nameCus = value; }
        public int BaristaID { get => baristaID; set => baristaID = value; }

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
            this.Time = time;
            this.SoLuong = sl;
            this.NameCus = cusName;
            this.BaristaID = baristaID;
            orderID = OrderItemID;

            lblID.Text = OrderItemID.ToString() + " - " + OrderID.ToString();
            lblItem.Text = itemName;
            lblSL.Text = sl.ToString();
            lblTime.Text = time.ToString();
            lblNote.Text = note;

            lblCusName.Text = cusName;
            lblPhone.Text = phone;
            lblBaristaID.Text = baristaID.ToString();


            string path = Path.Combine(pathPro(), linkImag);
            picItem.Image = Image.FromFile(path);


        }

        public string pathPro()
        {
            // Lấy đối tượng Assembly của assembly hiện tại
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Lấy đường dẫn đầy đủ của file thực thi (bao gồm cả tên file)
            string assemblyLocation = assembly.Location;

            // Lấy đường dẫn thư mục cha của file thực thi
            string debug = Path.GetDirectoryName(assemblyLocation);
            string bin = Path.GetDirectoryName(debug);
            string proj = Path.GetDirectoryName(bin);
            return proj;
        }
        //button NO
        private void button2_Click(object sender, EventArgs e)
        {
            NoButtonClick?.Invoke(this, new DataItemPaUC(orderID));
        }
        
        //button Yes
        private void button1_Click(object sender, EventArgs e)
        {
            YesButtonClick?.Invoke(this, new DataItemPaUC(orderID));
        }
    }
    public class DataItemPaUC : EventArgs
    {
        public int OrderItemID { get; set; }

        public DataItemPaUC(int orderItemID)
        {
            OrderItemID = orderItemID;
        }
    }
}

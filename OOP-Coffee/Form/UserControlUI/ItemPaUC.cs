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
using System.Net.Http;

namespace OOP_Coffee
{
    public partial class ItemPaUC : UserControl
    {
        public ItemPaUC()
        {
            InitializeComponent();
        }
        public ItemPaUC(string id,string itemName, string sl, string time, string status, string linkImag,
                    string cusName,string phone)
        {
            InitializeComponent();
            //item
            lblID.Text = id;
            lblItem.Text = itemName;
            lblSL.Text = sl;
            lblTime.Text = time;
            lblStatus.Text = status;

            lblCusName.Text = cusName;
            lblPhone.Text = phone;


            //try
            //{
            //    // Tạo WebClient để tải hình ảnh từ URL
            //    using (WebClient webClient = new WebClient())
            //    {
            //        // Tải dữ liệu từ URL
            //        byte[] data = webClient.DownloadData(linkImag);

            //        // Tạo MemoryStream từ dữ liệu tải về
            //        using (System.IO.MemoryStream mem = new System.IO.MemoryStream(data))
            //        {
            //            // Sử dụng thuộc tính Image để hiển thị hình ảnh trong PictureBox
            //            picItem.Image = System.Drawing.Image.FromStream(mem);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Xử lý lỗi (nếu có)
            //    MessageBox.Show($"Error: {ex.Message}");
            //}
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ItemPaUC_Load(object sender, EventArgs e)
        {

        }
    }
}

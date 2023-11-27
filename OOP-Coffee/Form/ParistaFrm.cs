using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace OOP_Coffee
{
    public partial class ParistaFrm : System.Windows.Forms.Form
    {

        tableDataContext db = new tableDataContext("Data Source=DESKTOP-0C6LJMU;Initial Catalog=CoffeeOOp;Integrated Security=True");
        public ParistaFrm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void ParistaFrm_Load(object sender, EventArgs e)
        {
            var query = from order in db.Orders
                        join oitem in db.OrderItems on order.OrderID equals oitem.OrderID
                        join item in db.Items on oitem.ItemID equals item.ItemID
                        join cus in db.Customers on order.CustomerID equals cus.CustomerID
                        where oitem.Status == "0"
                        select new
                        {
                            orderID = order.OrderID,
                            orderItemID = oitem.OrderItemID,
                            itemName = item.Name,
                            quantity = oitem.Quantity,
                            date = order.OrderDate,
                            note = oitem.Note,
                            itemImg = item.Imag,

                            customer = cus.Name,
                            phone = cus.Phone,
                            baristaID = order.BaristaID                                                      
                        };
            foreach (var gr in query)
            {
                ItemPaUC item = new ItemPaUC(gr.orderID.ToString(),gr.orderItemID.ToString(),gr.itemName,gr.quantity.ToString(),gr.date.ToString(),gr.note, gr.itemImg,
                                                gr.customer, gr.phone, gr.baristaID.ToString());

                //su kien nhan yes
                item.YesButtonClick += ButtonYes_ItemPaUC;
                item.YesButtonClick += DeleteUserControl_ItemPaUC;                

                
                item.NoButtonClick += ButtonNo_ItemPaUC;
                item.NoButtonClick += DeleteUserControl_ItemPaUC; 
                flpParista.Controls.Add(item);
            }
        }

        private void ButtonYes_ItemPaUC(object sender, DataItemPaUC e)
        {
            OrderItem orderItem = db.OrderItems.Where(s => s.OrderItemID == int.Parse(e.OrderItemID)).Single();
            orderItem.Status = "1";

            //trừ số lượng có trong iventory
            var thanhphan = from a in db.Congthucs
                            where orderItem.ItemID == a.id_san_pham
                            select new
                            {
                                nguyenlieuID = a.id_nguyen_lieu,
                                soluong = a.so_luong_nguyen_lieu
                            };
            foreach (var tp in thanhphan)
            {
                int.TryParse(tp.nguyenlieuID.ToString(), out int id);
                var iventory = db.Inventories.Where(s => s.ID == id).Single();
                iventory.SoLuong -= tp.soluong * orderItem.Quantity;
            }

            db.SubmitChanges();
            MessageBox.Show("Đã hoàn thành xong", "Thông báo");
        }
        private void ButtonNo_ItemPaUC(object sender, DataItemPaUC e)
        {
            OrderItem orderItem = db.OrderItems.Where(s => s.OrderItemID == int.Parse(e.OrderItemID)).Single();
            orderItem.Status = "-1";

            db.SubmitChanges();
            MessageBox.Show("Đã hủy", "Thông báo");
        }
        private void DeleteUserControl_ItemPaUC(object sender, EventArgs e)
        {
            if( sender is ItemPaUC item)
            {
                flpParista.Controls.Remove(item);
            }
        }

    }
}

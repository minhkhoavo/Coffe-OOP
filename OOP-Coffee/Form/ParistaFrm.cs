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

        CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
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
            var query = (from order in db.OrderDBs
                        join oitem in db.OrderItemDBs on order.OrderID equals oitem.OrderID
                        join item in db.ItemDBs on oitem.ItemId equals item.ItemId
                        join cus in db.CustomerDBs on order.CustomerID equals cus.CustomerID
                        where oitem.Status == "Pending"
                        select new
                        {
                            orderID = order.OrderID,
                            orderItemID = oitem.OrderItemID,
                            itemName = item.ItemName,
                            quantity = oitem.Quantity,
                            date = order.OrderDate,
                            note = oitem.Note,
                            itemImg = item.ItemImage,

                            customer = cus.Name,
                            phone = cus.Phone,
                            baristaID = oitem.BaristaID                                                     
                        }).ToList()
                        ;
            foreach (var gr in query)
            {
                /*                ItemPaUC item = new ItemPaUC(gr.orderID.ToString(),gr.orderItemID.ToString(),gr.itemName,gr.quantity.ToString(),gr.date.ToString(),gr.note, gr.itemImg,
                                                                gr.customer, gr.phone, gr.baristaID.ToString());*/
                ItemPaUC item = new ItemPaUC(gr.orderID, gr.orderItemID, gr.itemName, gr.quantity, gr.date, gr.note, gr.itemImg,
                                                gr.customer, gr.phone, gr.baristaID);
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
            OrderItemDB orderItem = db.OrderItemDBs.Where(s => s.OrderItemID == e.OrderItemID).Single();
            orderItem.Status = "Completed";

            //trừ số lượng có trong iventory
            var thanhphan = from a in db.CongThucDBs
                            where orderItem.ItemId == a.id_san_pham
                            select new
                            {
                                nguyenlieuID = a.id_nguyen_lieu,
                                soluong = a.so_luong_nguyen_lieu
                            };
            foreach (var tp in thanhphan)
            {
                var iventory = db.InventoryDBs.Where(s => s.ID == tp.nguyenlieuID).Single();
                iventory.SoLuong -= tp.soluong * orderItem.Quantity;
            }

            db.SubmitChanges();
            MessageBox.Show("Đã hoàn thành xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ButtonNo_ItemPaUC(object sender, DataItemPaUC e)
        {
            OrderItemDB orderItem = db.OrderItemDBs.Where(s => s.OrderItemID == e.OrderItemID).Single();
            orderItem.Status = "Rejected";

            db.SubmitChanges();
            MessageBox.Show("Đã hủy", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void DeleteUserControl_ItemPaUC(object sender, EventArgs e)
        {
            if( sender is ItemPaUC item)
            {
                flpParista.Controls.Remove(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemPaUC[] controlList = flpParista.Controls.Cast<ItemPaUC>().ToArray();
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Array.Sort(controlList, (x,y) => x.Time.CompareTo(y.Time));
                    MessageBox.Show("Đã so sánh");
                    break;
                case 1:
                    Array.Sort(controlList, (x, y) => -x.SoLuong.CompareTo(y.SoLuong));
                    break;
                case 2:
                    Array.Sort(controlList, (x, y) => x.NameCus.CompareTo(y.NameCus));
                    break;
                case 3:
                    Array.Sort(controlList, (x, y) => x.BaristaID.CompareTo(y.BaristaID));
                    break;
                default:
                    break;

            }
            flpParista.Controls.Clear();
            flpParista.Controls.AddRange(controlList);
        }
    }
}

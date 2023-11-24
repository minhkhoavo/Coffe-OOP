using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;

namespace OOP_Coffee
{
    public partial class ParistaFrm : System.Windows.Forms.Form
    {

        //dataDataContext db = new dataDataContext();
        public ParistaFrm()
        {
            InitializeComponent();
        }
        
        /*private void ParistaFrm_Load(object sender, EventArgs e)
        {
            var query = from order in db.Orders
                        join oitem in db.OrderItems on order.OrderID equals oitem.OrderID
                        join item in db.Items on oitem.ItemID equals item.ItemID
                        join cus in db.Customers on order.CustomerID equals cus.CustomerID
                        select new
                        {
                            id = order.OrderID.ToString() + "-" + oitem.OrderItemID.ToString(),
                            itemName = item.Name,
                            quantity = oitem.Quantity,
                            date = order.OrderDate,
                            status = "kho co",
                            itemImg = item.Imag,                       
                            
                            customer = cus.Name,
                            phone = cus.Phone
                                                      
                        };
            //string id,string itemName, string sl, string time, string status,, string linkImag,
            //string cusName,string phone
            foreach (var gr in query)
            {
                ItemPaUC item = new ItemPaUC(gr.id,gr.itemName,gr.quantity.ToString(),gr.date.ToString(),gr.status, gr.itemImg,
                                                gr.customer, gr.phone);
                flpParista.Controls.Add(item);
            }


        }
*/
/*        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }*/
    }
}

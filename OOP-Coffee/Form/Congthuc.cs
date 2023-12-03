using OOP_Coffee.Form.UserControlUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Coffee.Form
{
    public partial class CongThuc : System.Windows.Forms.Form
    {
        public ItemDB item;
        CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
        public List<CongThucDB> dsCT { get; set; } = new List<CongThucDB>();
        public CongThuc()
        {
            InitializeComponent();
        }
        public CongThuc(ItemDB obj)
        {
            InitializeComponent();
            this.item = obj;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CongThuc_Load(object sender, EventArgs e)
        {
            if(item != null)
            {
                lblItemName.Text = item.ItemName;
                lblItemID.Text = item.ItemId.ToString();
                var list = db.InventoryDBs.ToList();
                foreach (var tp in list)
                {
                    int sl = db.CongThucDBs
                                .Where(s => s.id_san_pham == item.ItemId && s.id_nguyen_lieu == tp.ID)
                                .Select(s => s.so_luong_nguyen_lieu)
                                .FirstOrDefault();
                    Ingredient ingredient = new Ingredient(tp.ID, tp.Ten, tp.DonVi, sl);
                    flowLayoutPanel1.Controls.Add(ingredient);
                }
            }
            else
            {
                var list = db.InventoryDBs.ToList();
                foreach (var tp in list)
                {
                    int sl = 0;
                    Ingredient ingredient = new Ingredient(tp.ID, tp.Ten, tp.DonVi, sl);
                    flowLayoutPanel1.Controls.Add(ingredient);
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            dsCT.Clear();
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if ((control is Ingredient tp))
                {
                    CongThucDB congthuc = new CongThucDB();
                    congthuc.id_san_pham = item?.ItemId ?? 0;
                    congthuc.id_nguyen_lieu = tp.Id;
                    congthuc.so_luong_nguyen_lieu = tp.SoLuong;
                    dsCT.Add(congthuc);      
                }
            }
            this.Close();
            //string str = "";
            //foreach (var s in dsCT)
            //{
            //    str += $" {s.id_nguyen_lieu} {s.id_san_pham} {s.so_luong_nguyen_lieu} \n";
            //}
            //MessageBox.Show(str);
        }
    }
}

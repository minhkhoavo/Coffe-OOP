using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

namespace OOP_Coffee
{
    public partial class Iventory : System.Windows.Forms.Form
    {
        tableDataContext db = new tableDataContext("Data Source=DESKTOP-0C6LJMU;Initial Catalog=CoffeeOOp;Integrated Security=True");
        public Iventory()
        {
            InitializeComponent();
        }

        private void Iventory_Load(object sender, EventArgs e)
        {
            dgv.DataSource = db.Inventories.ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.Ten = txtTen.Text;
            inventory.SoLuong = int.Parse(txtSoLuong.Text);
            inventory.DonVi = txtDV.Text;
            inventory.GiaNhap = double.Parse(txtGia.Text);
            inventory.NgayNhap = dtpNgayNhap.Value.Date;
            inventory.GhiChu = txtGhiChu.Text;

            db.Inventories.InsertOnSubmit(inventory);
            db.SubmitChanges();
            Iventory_Load(this, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var item = db.Inventories.Where(s => s.ID.ToString() == txtID.Text).Single();
            db.Inventories.DeleteOnSubmit(item);
            db.SubmitChanges();
            Iventory_Load(sender, e);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {               
                var row = dgv.SelectedRows[0];
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                if(row.Cells["DonVi"].Value != null)
                   txtDV.Text = row.Cells["DonVi"].Value.ToString();

                txtGia.Text = row.Cells["GiaNhap"].Value.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                if (row.Cells["GhiChu"].Value != null)
                    txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();              
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Inventory inventory = db.Inventories.Where(s=> s.ID.ToString() ==txtID.Text).Single();
            inventory.Ten = txtTen.Text;
            inventory.SoLuong = int.Parse(txtSoLuong.Text);
            inventory.DonVi = txtDV.Text;
            inventory.GiaNhap = double.Parse(txtGia.Text);
            inventory.NgayNhap = dtpNgayNhap.Value.Date;
            inventory.GhiChu = txtGhiChu.Text;

            db.SubmitChanges();
            Iventory_Load(sender, e);
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            cboSort.SelectedIndex = -1;
            dgv.DataSource = db.Inventories.Where(s => s.Ten.Contains(txtTim.Text)).ToList();
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSort.SelectedIndex != -1)
               txtTim.Text = "";
            switch (cboSort.SelectedIndex)
            {
                case 0:
                    Iventory_Load(sender, e);
                    break;
                case 1:
                    dgv.DataSource = db.Inventories.OrderBy(s => s.Ten).ToList();
                    break;
                case 2:
                    dgv.DataSource = db.Inventories.OrderBy(s => s.GiaNhap).ToList();
                    break;
                case 3:
                    dgv.DataSource = db.Inventories.OrderBy(s => s.SoLuong).ToList();
                    break;
                case 4:
                    dgv.DataSource = db.Inventories.OrderBy(s => s.NgayNhap).ToList();
                    break;
            }
        }
    }
}

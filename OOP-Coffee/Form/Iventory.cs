using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Excel = Microsoft.Office.Interop.Excel;

namespace OOP_Coffee
{
    public partial class Iventory : System.Windows.Forms.Form
    {
        CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
        public Iventory()
        {
            InitializeComponent();
        }

        private void Iventory_Load(object sender, EventArgs e)
        {
            dgv.DataSource = db.InventoryDBs.ToList();
            dgv.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                MessageBox.Show("ID đã có nhấn reset sau đó tạo mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(txtTen.Text == "" || txtSoLuong.Text == "" || txtDV.Text == "" || txtGia.Text == "" || txtGhiChu.Text  == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(!(int.TryParse(txtSoLuong.Text, out _) && decimal.TryParse(txtGia.Text, out _)))
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            InventoryDB inventory = new InventoryDB();
            inventory.Ten = txtTen.Text;
            inventory.SoLuong = int.Parse(txtSoLuong.Text);
            inventory.DonVi = txtDV.Text;
            inventory.GiaNhap = decimal.Parse(txtGia.Text);
            inventory.NgayNhap = dtpNgayNhap.Value.Date;
            inventory.GhiChu = txtGhiChu.Text;

            db.InventoryDBs.InsertOnSubmit(inventory);
            db.SubmitChanges();
            Iventory_Load(this, e);
            MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Chưa lựa chọn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var item = db.InventoryDBs.Where(s => s.ID.ToString() == txtID.Text).Single();
            db.InventoryDBs.DeleteOnSubmit(item);
            db.SubmitChanges();
            Iventory_Load(sender, e);
            MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {               
                var row = dgv.SelectedRows[0];
                txtID.Text = row.Cells["ID"].Value?.ToString();
                txtTen.Text = row.Cells["Ten"].Value?.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtDV.Text = row.Cells["DonVi"].Value?.ToString();

                txtGia.Text = row.Cells["GiaNhap"].Value?.ToString();
                dtpNgayNhap.Value = Convert.ToDateTime(row.Cells["NgayNhap"].Value);
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString();              
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Chưa lựa chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtTen.Text == "" || txtSoLuong.Text == "" || txtDV.Text == "" || txtGia.Text == "" || txtGhiChu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(int.TryParse(txtSoLuong.Text, out _) && decimal.TryParse(txtGia.Text, out _)))
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            InventoryDB inventory = db.InventoryDBs.Where(s=> s.ID.ToString() ==txtID.Text).Single();
            inventory.Ten = txtTen.Text;
            inventory.SoLuong = int.Parse(txtSoLuong.Text);
            inventory.DonVi = txtDV.Text;
            inventory.GiaNhap = decimal.Parse(txtGia.Text);
            inventory.NgayNhap = dtpNgayNhap.Value.Date;
            inventory.GhiChu = txtGhiChu.Text;

            db.SubmitChanges();
            Iventory_Load(sender, e);
            MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            cboSort.SelectedIndex = -1;
            dgv.DataSource = db.InventoryDBs.Where(s => s.Ten.Contains(txtTim.Text)).ToList();
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
                    dgv.DataSource = db.InventoryDBs.OrderBy(s => s.Ten).ToList();
                    break;
                case 2:
                    dgv.DataSource = db.InventoryDBs.OrderBy(s => s.GiaNhap).ToList();
                    break;
                case 3:
                    dgv.DataSource = db.InventoryDBs.OrderBy(s => s.SoLuong).ToList();
                    break;
                case 4:
                    dgv.DataSource = db.InventoryDBs.OrderBy(s => s.NgayNhap).ToList();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtTen.Clear();
            txtSoLuong.Clear();
            txtDV.Clear();
            txtGia.Clear();
            dtpNgayNhap.Value = DateTime.Now;
            txtGhiChu.Clear();
        }

        public string pathPro()
        {
            // Lấy đối tượng Assembly của assembly hiện tại
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Lấy đường dẫn đầy đủ của file thực thi (bao gồm cả tên file)
            string assemblyLocation = assembly.Location;
            string proj = assemblyLocation;
            for (int i = 0; i<3; i++)
            {
                proj = Path.GetDirectoryName(proj);
            }
            return proj;
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(pathPro());
            path = Path.Combine(path, "iventory.txt");

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    sw.Write(dgv.Columns[i].HeaderText.PadRight(25));

                }
                sw.WriteLine();

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            sw.Write(row.Cells[i].Value.ToString().PadRight(25));
                        }
                    }
                    sw.WriteLine();
                }
            }
            MessageBox.Show("Tạo file thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

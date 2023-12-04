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

namespace OOP_Coffee.Form
{
    public partial class ThemItem : System.Windows.Forms.Form
    {
        CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
        List<CongThucDB> dsCT = new List<CongThucDB>();
        private int indexRow;
        public ThemItem()
        {
            InitializeComponent();
            indexRow = 0;
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtImage.Text = openFile.FileName;
                pictureBox1.Image = Image.FromFile(txtImage.Text);
            }            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {   
            if(lblID.Text != "")
            {
                MessageBox.Show("ID đã có nhấn reset sau đó tạo mới","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if(txtName.Text == "" || txtPrice.Text == "" || txtImage.Text == "" || !dsCT.Any())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ!", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    CopyImageToFolder(txtImage.Text);

                    ItemDB item = new ItemDB();
                    item.ItemName = txtName.Text;
                    item.Price = decimal.Parse(txtPrice.Text);
                    item.Cost = decimal.Parse(txtCost.Text);
                    item.ItemImage = Path.Combine("Images", Path.GetFileName(txtImage.Text));

                    db.ItemDBs.InsertOnSubmit(item);

                    db.SubmitChanges();
                    int idItem = db.ItemDBs.Where(s => s.ItemName == item.ItemName && s.Price == item.Price).Single().ItemId;
                    foreach (CongThucDB tp in dsCT)
                    {

                        tp.id_san_pham = idItem;
                        db.CongThucDBs.InsertOnSubmit(tp);
                    }
                    db.SubmitChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

                ThemItem_Load(sender, e);
                MessageBox.Show("Đã thêm thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                indexRow = dataGridView1.SelectedRows[0].Index;
                try
                {
                    lblID.Text = dataGridView1.SelectedRows[0].Cells["ItemID"].Value.ToString();
                    txtName.Text = dataGridView1.SelectedRows[0].Cells["ItemName"].Value.ToString();
                    txtPrice.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();

                    string pathDB = dataGridView1.SelectedRows[0].Cells["ItemImage"].Value.ToString();
                    //path image
                    string pathImage = Path.Combine(pathPro(), pathDB);
                    txtImage.Text = pathImage;


                    if (File.Exists(pathImage))
                    {
                        Image image = Image.FromFile(pathImage);
                        pictureBox1.Image = image;
                    }
                    else
                    {
                        pictureBox1.ImageLocation = Path.Combine(pathPro(), "Images/nen.png");
                    }

                    txtCost.Text = dataGridView1.SelectedRows[0].Cells["cost"].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ThemItem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ItemDBs.ToList();
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows.Count > indexRow)
            {
                dataGridView1.Rows[indexRow].Selected = true;
            }
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
        private void CopyImageToFolder(string sourceFilePath)
        {
            try
            {
                // Kiểm tra xem đường dẫn nguồn có tồn tại không.
                if (File.Exists(sourceFilePath))
                {
                    // Lấy tên tệp từ đường dẫn nguồn.
                    string fileName = Path.GetFileName(sourceFilePath);

                    // Kết hợp đường dẫn của thư mục đích với tên tệp.
                    string pathImage = Path.Combine(pathPro(), "Images");
                    string fileInImage = Path.Combine(pathImage, fileName);

                    // Sao chép tệp từ đường dẫn nguồn đến đường dẫn đích.
                    if(!File.Exists(fileInImage))
                        File.Copy(sourceFilePath, fileInImage, true);
                }
                else
                {
                    MessageBox.Show("Đường dẫn nguồn không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult kt = MessageBox.Show("Bạn có chắn chắn muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(kt == DialogResult.Cancel)
            {
                return;
            }
            ItemDB itemDB = db.ItemDBs.Where(s => s.ItemId == int.Parse(lblID.Text)).Single();
            db.ItemDBs.DeleteOnSubmit(itemDB);

            // xóa các bảng công thức
            var list = db.CongThucDBs.Where(s => s.id_san_pham.ToString() == lblID.Text);
            db.CongThucDBs.DeleteAllOnSubmit(list);

            db.SubmitChanges();
            ThemItem_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtImage.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ;
            }
            else if(!decimal.TryParse(txtPrice.Text, out _))
            {
                MessageBox.Show("Nhập sai kiểu dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ItemDB item = db.ItemDBs.Where(s => s.ItemId.ToString() == lblID.Text).Single();
            item.ItemName = txtName.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Cost = decimal.Parse(txtCost.Text);
            item.ItemImage = Path.Combine("Images", Path.GetFileName(txtImage.Text));

            //them cong thuc
            foreach (CongThucDB tp in dsCT)
            {
                CongThucDB congThucDB = db.CongThucDBs
                            .Where(s => s.id_nguyen_lieu == tp.id_nguyen_lieu && s.id_san_pham == tp.id_san_pham)
                            .FirstOrDefault();
                if (congThucDB != null)
                {
                    congThucDB.so_luong_nguyen_lieu = tp.so_luong_nguyen_lieu;
                }
                else
                {
                    db.CongThucDBs.InsertOnSubmit(tp);
                }
            }

            db.SubmitChanges();
            ThemItem_Load(sender, e);
            MessageBox.Show("Đã sửa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSort.SelectedIndex)
            {
                case 0:
                    ThemItem_Load(sender, e);
                    break;
                case 1:
                    dataGridView1.DataSource = db.ItemDBs.OrderBy(i => i.ItemName).ToList();
                    break;
                case 2:
                    dataGridView1.DataSource = db.ItemDBs.OrderBy(i => i.Price).ToList();
                    break;
                case 3:
                    dataGridView1.DataSource = db.ItemDBs.OrderBy(i => i.Cost).ToList();
                    break;
            }
        }

        private void btnThanhPhan_Click(object sender, EventArgs e)
        {
            ItemDB itemDB = db.ItemDBs.Where(s => s.ItemId.ToString() == lblID.Text).FirstOrDefault();
            CongThuc congThuc = new CongThuc(itemDB);
            congThuc.ShowDialog();
            dsCT = congThuc.dsCT;

            if (dsCT.Any())
            {
                decimal cost = 0;
                foreach (var tp in dsCT)
                {
                    decimal giaTp = db.InventoryDBs.Where(s => s.ID == tp.id_nguyen_lieu).FirstOrDefault().GiaNhap;
                    cost += giaTp * tp.so_luong_nguyen_lieu;
                }
                txtCost.Text = cost.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblID.Text = "";
            txtName.Clear();
            txtPrice.Clear();
            txtCost.Clear();
            txtImage.Clear();
            pictureBox1.ImageLocation = Path.Combine(pathPro(), "Images/nen.png");
        }
    }
}

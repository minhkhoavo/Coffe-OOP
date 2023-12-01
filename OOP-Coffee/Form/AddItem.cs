using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Reflection;

namespace OOP_Coffee.Form
{
    public partial class AddItem : System.Windows.Forms.Form
    {
        CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
        public AddItem()
        {
            InitializeComponent();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.ItemDBs.ToList();
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                txtImage.Text = openFile.FileName;
            }
            pictureBox1.ImageLocation = txtImage.Text;
        }

        private void txtImage_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //luu hinh anh vao file Images
            CopyImageToFolder(txtImage.Text);
            
            ItemDB item = new ItemDB();
            item.ItemName = txtName.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Cost = decimal.Parse(txtCost.Text);
            item.ItemImage = Path.Combine("Images", Path.GetFileName(txtImage.Text));

            db.ItemDBs.InsertOnSubmit(item);
            db.SubmitChanges();

            AddItem_Load(sender, e);
        }
        public string pathFolderImage()
        {
            // Lấy đối tượng Assembly của assembly hiện tại
            Assembly assembly = Assembly.GetExecutingAssembly();

            // Lấy đường dẫn đầy đủ của file thực thi (bao gồm cả tên file)
            string assemblyLocation = assembly.Location;

            // Lấy đường dẫn thư mục cha của file thực thi
            string debug = Path.GetDirectoryName(assemblyLocation);
            string bin = Path.GetDirectoryName(debug);
            string proj = Path.GetDirectoryName(bin);
            //string destinationFolderPath = Path.Combine(proj, "Images");
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
                    string pathImage = Path.Combine(pathFolderImage(), "Images");
                    string destinationFilePath = Path.Combine(pathImage, fileName);

                    // Sao chép tệp từ đường dẫn nguồn đến đường dẫn đích.
                    File.Copy(sourceFilePath, destinationFilePath, true);
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

        private void button3_Click(object sender, EventArgs e)
        {
            var item = db.ItemDBs.Where(s => s.ItemId.ToString() == lblID.Text).Single();
            db.ItemDBs.DeleteOnSubmit(item);
            db.SubmitChanges();
            AddItem_Load(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    lblID.Text = dataGridView1.SelectedRows[0].Cells["ItemID"].Value.ToString();
                    txtName.Text = dataGridView1.SelectedRows[0].Cells["ItemName"].Value.ToString();
                    txtPrice.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();

                    string pathDB = dataGridView1.SelectedRows[0].Cells["ItemImage"].Value.ToString();
                    //path image
                    string pathImage = Path.Combine(pathFolderImage(), pathDB);
                    txtImage.Text = pathImage;


                    if (File.Exists(pathImage))
                    {
                        Image image = Image.FromFile(pathImage);
                        pictureBox1.Image = image;
                    }
                    else
                    {
                        pictureBox1.ImageLocation = Path.Combine(pathFolderImage(),"Images/nen.png");
                    }

                    txtCost.Text = dataGridView1.SelectedRows[0].Cells["cost"].Value.ToString();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ItemDB item = db.ItemDBs.Where(s => s.ItemId.ToString() == lblID.Text).Single();
            item.ItemName = txtName.Text;
            item.Price = decimal.Parse(txtPrice.Text);
            item.Cost = decimal.Parse(txtCost.Text);
            item.ItemImage = Path.Combine("Images", Path.GetFileName(txtImage.Text));

            db.SubmitChanges();
            AddItem_Load(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboSort.SelectedIndex)
            {
                case 0:
                    AddItem_Load(sender, e);
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

        private void btnNguyenLieu_Click(object sender, EventArgs e)
        {

        }
    }
}

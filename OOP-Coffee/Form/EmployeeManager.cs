using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using CoffeeShop;
using System.Data.Linq;
using OOP_Coffee.Form;

namespace OOP_Coffee
{
    public partial class EmployeeManager : System.Windows.Forms.Form
    {
        CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
        public EmployeeManager()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtID.Text != "")
            {
                MessageBox.Show("ID đã có nhấn Reset để tạo mới","Thông Báo ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            else if(txtName.Text == "" || txtPass.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //lay thong tin
            if (radBarista.Checked)
            {
                BaristaDB barista = new BaristaDB();
                barista.Name = txtName.Text;
                barista.Password = txtPass.Text;
                barista.Phone = txtPhone.Text;
                barista.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked == true)
                    barista.Gender = "Male";
                else barista.Gender = "Female";
                barista.Address = txtAddress.Text;
                barista.ManagerID = (int)cboManager.SelectedValue;

                db.BaristaDBs.InsertOnSubmit(barista);
            }
            else
            {
                ManagerDB manager = new ManagerDB();
                manager.Name = txtName.Text;
                manager.Password = txtPass.Text;
                manager.Phone = txtPhone.Text;
                manager.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked == true)
                    manager.Gender = "Male";
                else manager.Gender = "Female";
                manager.Address = txtAddress.Text;

                db.ManagerDBs.InsertOnSubmit(manager);
            }
 
            //luu thong tin
            
            db.SubmitChanges();
            EmployeeManager_Load(sender, e);
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            dgvManager.DataSource = null;
            if (radManager.Checked)
            {
                dgvManager.DataSource = db.ManagerDBs.ToList();
                cboManager.SelectedIndex = -1;
                cboManager.Enabled = false;
            }
            else
            {
                dgvManager.DataSource = db.BaristaDBs.ToList();

                cboManager.DataSource = db.ManagerDBs;
                cboManager.DisplayMember = "Name";
                cboManager.ValueMember = "ManagerID";
                cboManager.Enabled = true;
            }
            dgvManager.Columns["Birthdate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void radBarista_CheckedChanged(object sender, EventArgs e)
        {
            if(radBarista.Checked == false)
            {
                fManagerLogin fLogin = new fManagerLogin();
                fLogin.ShowDialog();
                ManagerDB manager = db.ManagerDBs.ToList().First();
                if (manager != null)
                {
                    if (manager.Name != fLogin.name || manager.Password != fLogin.password)
                    {
                        MessageBox.Show("Mật khẩu sai!", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        radBarista.Checked = true;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            EmployeeManager_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
               MessageBox.Show("Chưa lựa chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (radBarista.Checked)
            {
                BaristaDB barista = db.BaristaDBs.Where(s => s.BaristaID.ToString() == txtID.Text).Single();
                db.BaristaDBs.DeleteOnSubmit(barista);
            }
            else
            {
                if(txtID.Text == db.ManagerDBs.First().ManagerID.ToString())
                {
                   MessageBox.Show("Không thể xóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   return;
                }
                ManagerDB manager = db.ManagerDBs.Where(s => s.ManagerID.ToString() == txtID.Text).Single();
                db.ManagerDBs.DeleteOnSubmit(manager);
            }
            db.SubmitChanges();
            EmployeeManager_Load(sender, e);
            btnReset_Click(sender, e);
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvManager_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManager.SelectedRows.Count > 0)
            {
                txtID.Text = dgvManager.SelectedRows[0].Cells[0].Value?.ToString();
                txtName.Text = dgvManager.SelectedRows[0].Cells["Name"].Value?.ToString();
                txtPass.Text = dgvManager.SelectedRows[0].Cells["Password"].Value?.ToString();
                txtPhone.Text = dgvManager.SelectedRows[0].Cells["Phone"].Value?.ToString();
                if ((dgvManager.SelectedRows[0].Cells["Gender"].Value?.ToString() ?? "Female") == "Female")
                {
                    radNu.Checked = true;
                }
                else radNam.Checked = true;
                dtpBirth.Value = Convert.ToDateTime(dgvManager.SelectedRows[0].Cells["Birthdate"].Value);
                txtAddress.Text = dgvManager.SelectedRows[0].Cells["Address"].Value?.ToString() ?? "";


                //neu la barista thi co dong nay
                if (radBarista.Checked)
                   cboManager.SelectedValue = dgvManager.SelectedRows[0].Cells["ManagerID"].Value;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtID.Text == "")
            {
                MessageBox.Show("Chưa lựa chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtName.Text == "" || txtPass.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (radBarista.Checked)
            {
                BaristaDB barista = db.BaristaDBs.Where(b => b.BaristaID.ToString() == txtID.Text).Single();
                barista.Name = txtName.Text;
                barista.Password = txtPass.Text;
                barista.Phone = txtPhone.Text;
                barista.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked == true)
                    barista.Gender = "Male";
                else barista.Gender = "Female";
                barista.Address = txtAddress.Text;
                barista.ManagerID = (int)cboManager.SelectedValue;
            }
            else
            {
                ManagerDB manager = db.ManagerDBs.Where(m => m.ManagerID.ToString() == txtID.Text).Single();
                manager.Name = txtName.Text;
                manager.Password = txtPass.Text;
                manager.Phone = txtPhone.Text;
                manager.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked)
                    manager.Gender = "Male";
                else manager.Gender = "Female";
                manager.Address = txtAddress.Text;
            }
            db.SubmitChanges();
            EmployeeManager_Load(sender, e);

            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            cboSort.SelectedIndex = -1;
            if (radBarista.Checked)
            {
                dgvManager.DataSource =  db.BaristaDBs.Where(b => b.Name.Contains(txtTim.Text)).ToList();
            }
            else
            {
                dgvManager.DataSource = db.ManagerDBs.Where(m => m.Name.Contains(txtTim.Text)).ToList();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSort.SelectedIndex != -1)
               txtTim.Text = "";

            switch (cboSort.SelectedIndex)
            {
                case 0:
                    EmployeeManager_Load(sender, e);
                    break;
                case 1:
                    if (radBarista.Checked)
                    {
                        dgvManager.DataSource = db.BaristaDBs.OrderBy(item => item.Name).ToList();
                    }
                    else
                        dgvManager.DataSource = db.ManagerDBs.OrderBy(item => item.Name).ToList();
                    break;
                case 2:
                    if (radBarista.Checked)
                        dgvManager.DataSource = db.BaristaDBs.OrderBy(item => item.Birthdate);
                    else
                        dgvManager.DataSource = db.ManagerDBs.OrderBy(item => item.Birthdate);
                    break;
                default:
                    break;
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtPass.Clear();
            txtPhone.Clear();
            dtpBirth.Value = DateTime.Now;
            radNam.Checked = true;
            txtAddress.Clear();
            cboManager.SelectedIndex = 0;
        }
    }
}

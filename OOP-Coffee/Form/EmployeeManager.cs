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
using CoffeeShop;
using System.Data.Linq;

namespace OOP_Coffee
{
    public partial class EmployeeManager : System.Windows.Forms.Form
    {

        tableDataContext db = new tableDataContext("Data Source=DESKTOP-0C6LJMU;Initial Catalog=CoffeeOOp;Integrated Security=True");
        public EmployeeManager()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
            //DialogResult kq = MessageBox.Show("Bạn có chắn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (kq == DialogResult.Yes)
            //    Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //lay thong tin
            if (radBarista.Checked)
            {
                Barista barista = new Barista();
                barista.Name = txtName.Text;
                barista.Password = txtPass.Text;
                barista.Phone = txtPhone.Text;
                barista.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked == true)
                    barista.Gender = "Nam";
                else barista.Gender = "Nu";
                barista.Address = txtAddress.Text;
                barista.ManagerId = (int?)cboManager.SelectedValue;

                db.Baristas.InsertOnSubmit(barista);
            }
            else
            {
                Manager manager = new Manager();
                manager.Name = txtName.Text;
                manager.Password = txtPass.Text;
                manager.Phone = txtPhone.Text;
                manager.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked == true)
                    manager.Gender = "Nam";
                else manager.Gender = "Nu";
                manager.Address = txtAddress.Text;

                db.Managers.InsertOnSubmit(manager);
            }
 
            //luu thong tin
            
            db.SubmitChanges();
            EmployeeManager_Load(sender, e);
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void EmployeeManager_Load(object sender, EventArgs e)
        {
            if (radManager.Checked)
            {
                var list = db.Managers.ToList();
                dgvManager.DataSource = list;
                cboManager.SelectedIndex = -1;
                cboManager.Enabled = false;
            }
            else
            {
                var list = db.Baristas.ToList();
                dgvManager.DataSource = list;

                cboManager.DataSource = db.Managers.ToList();
                cboManager.DisplayMember = "Name";
                cboManager.ValueMember = "ManagerID";
                cboManager.Enabled = true;
            }
        }

        private void radBarista_CheckedChanged(object sender, EventArgs e)
        {
            EmployeeManager_Load(this, e);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (radBarista.Checked)
            {
                Barista barista = db.Baristas.Where(s => s.BaristaID.ToString() == txtID.Text).Single();
                db.Baristas.DeleteOnSubmit(barista);
            }
            else
            {
                Manager manager = db.Managers.Where(s => s.ManagerID.ToString() == txtID.Text).Single();
                db.Managers.DeleteOnSubmit(manager);
            }
            db.SubmitChanges();
            EmployeeManager_Load(sender, e);
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dgvManager_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvManager.SelectedRows.Count > 0)
            {
                txtID.Text = dgvManager.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvManager.SelectedRows[0].Cells[1].Value.ToString();
                txtPass.Text = dgvManager.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvManager.SelectedRows[0].Cells[3].Value.ToString();

                dtpBirth.Value = Convert.ToDateTime(dgvManager.SelectedRows[0].Cells[4].Value);

                if (dgvManager.SelectedRows[0].Cells["Gender"].Value != null)
                {
                    string gender = dgvManager.SelectedRows[0].Cells["Gender"].Value.ToString();
                    if (gender == "Nu")
                        radNu.Checked = true;
                }

                if (dgvManager.SelectedRows[0].Cells["Address"].Value != null)
                    txtAddress.Text = dgvManager.SelectedRows[0].Cells["Address"].Value.ToString();
                else txtAddress.Text = "";
                //neu la barista thi co dong nay
                if(radBarista.Checked)
                   cboManager.SelectedValue = dgvManager.SelectedRows[0].Cells["ManagerID"].Value;
            }

        }
        private void dgvSelectManager()
        {
            if (dgvManager.SelectedRows.Count > 0)
            {
                txtID.Text = dgvManager.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvManager.SelectedRows[0].Cells[1].Value.ToString();
                txtPass.Text = dgvManager.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvManager.SelectedRows[0].Cells[3].Value.ToString();

                dtpBirth.Value = Convert.ToDateTime(dgvManager.SelectedRows[0].Cells[4].Value);
                if (dgvManager.SelectedRows[0].Cells[6].Value != null)
                {
                    string gender = dgvManager.SelectedRows[0].Cells[6].Value.ToString();
                    if (gender == "Nu")
                        radNu.Checked = true;

                }
                if (dgvManager.SelectedRows[0].Cells[7].Value != null)
                    txtAddress.Text = dgvManager.SelectedRows[0].Cells[7].Value.ToString();

                cboManager.SelectedValue = dgvManager.SelectedRows[0].Cells[5].Value;
            }
        }
        private void dgvSelectBarista()
        {
            if (dgvManager.SelectedRows.Count > 0)
            {
                txtID.Text = dgvManager.SelectedRows[0].Cells[0].Value.ToString();
                txtName.Text = dgvManager.SelectedRows[0].Cells[1].Value.ToString();
                txtPass.Text = dgvManager.SelectedRows[0].Cells[2].Value.ToString();
                txtPhone.Text = dgvManager.SelectedRows[0].Cells[3].Value.ToString();

                dtpBirth.Value = Convert.ToDateTime(dgvManager.SelectedRows[0].Cells[4].Value);
                if (dgvManager.SelectedRows[0].Cells[6].Value != null)
                {
                    string gender = dgvManager.SelectedRows[0].Cells[6].Value.ToString();
                    if (gender == "Nu")
                        radNu.Checked = true;

                }
                if (dgvManager.SelectedRows[0].Cells[7].Value != null)
                    txtAddress.Text = dgvManager.SelectedRows[0].Cells[7].Value.ToString();

                cboManager.SelectedValue = dgvManager.SelectedRows[0].Cells[5].Value;
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (radBarista.Checked)
            {
                Barista barista = db.Baristas.Where(b => b.BaristaID.ToString() == txtID.Text).Single();
                barista.Name = txtName.Text;
                barista.Password = txtPass.Text;
                barista.Phone = txtPhone.Text;
                barista.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked == true)
                    barista.Gender = "Nam";
                else barista.Gender = "Nu";
                barista.Address = txtAddress.Text;
                barista.ManagerId = (int?)cboManager.SelectedValue;
            }
            else
            {
                Manager manager = db.Managers.Where(m => m.ManagerID.ToString() == txtID.Text).Single();
                manager.Name = txtName.Text;
                manager.Password = txtPass.Text;
                manager.Phone = txtPhone.Text;
                manager.Birthdate = dtpBirth.Value.Date;
                if (radNam.Checked)
                    manager.Gender = "Nam";
                else manager.Gender = "Nu";
                manager.Address = txtAddress.Text;
            }
            db.SubmitChanges();
            EmployeeManager_Load(sender, e);

            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            cboSort.SelectedIndex = -1;
            if (radBarista.Checked)
            {
                var list = db.Baristas.Where(b => b.Name.Contains(txtTim.Text)).ToList();
                dgvManager.DataSource = list;
            }
            else
            {
                var list = db.Managers.Where(m => m.Name.Contains(txtTim.Text)).ToList();
                dgvManager.DataSource = list;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSort.SelectedIndex != -1)
               txtTim.Text = "";

            switch (cboSort.SelectedIndex)
            {
                case 0:
                    if (radBarista.Checked)
                        dgvManager.DataSource = db.Baristas.OrderBy(item => item.BaristaID);
                    else
                        dgvManager.DataSource = db.Managers.OrderBy(item => item.ManagerID);
                    break;
                case 1:
                    if (radBarista.Checked)
                    {
                        dgvManager.DataSource = db.Baristas.OrderBy(item => item.Name);

                    }else
                        dgvManager.DataSource = db.Managers.OrderBy(item => item.Name);
                    break;
                case 2:
                    if(radBarista.Checked)
                        dgvManager.DataSource = db.Baristas.OrderBy(item => item.Birthdate);
                    else
                        dgvManager.DataSource = db.Managers.OrderBy(item => item.Birthdate);
                    break;
                default:
                    break;
            }

        }
    }
}

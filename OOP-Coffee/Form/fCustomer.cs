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
    public partial class fCustomer : System.Windows.Forms.Form
    {
        CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
        public fCustomer()
        {
            InitializeComponent();
        }

        private void dgvManager_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvManager.SelectedRows.Count > 0)
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
            }
        }

        private void fCustomer_Load(object sender, EventArgs e)
        {
            dgvManager.DataSource = db.CustomerDBs.ToList();
            dgvManager.Columns["Birthdate"].DefaultCellStyle.Format = "dd/MM/yyyy";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                MessageBox.Show("ID đã có nhấn Reset để tạo mới", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtName.Text == "" || txtPass.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CustomerDB customerDB = new CustomerDB();
            customerDB.Name = txtName.Text;
            customerDB.Password = txtPass.Text;
            customerDB.Phone = txtPhone.Text;
            customerDB.Birthdate = dtpBirth.Value.Date;
            if (radNam.Checked == true)
                customerDB.Gender = "Male";
            else customerDB.Gender = "Female";
            customerDB.Address = txtAddress.Text;

            db.CustomerDBs.InsertOnSubmit(customerDB);

            db.SubmitChanges();
            fCustomer_Load(sender, e);
            MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Chưa lựa chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CustomerDB customerDB = db.CustomerDBs.Where(s => s.CustomerID.ToString() == txtID.Text).Single();
            db.CustomerDBs.DeleteOnSubmit(customerDB);

            db.SubmitChanges();
            fCustomer_Load(sender, e);
            btnReset_Click(sender, e);
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Chưa lựa chọn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtName.Text == "" || txtPass.Text == "" || txtPhone.Text == "" || txtAddress.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CustomerDB customerDB = db.CustomerDBs.Where(s => s.CustomerID.ToString() == txtID.Text).Single();
            customerDB.Name = txtName.Text;
            customerDB.Password = txtPass.Text;
            customerDB.Phone = txtPhone.Text;
            customerDB.Birthdate = dtpBirth.Value.Date;
            if (radNam.Checked == true)
                customerDB.Gender = "Male";
            else customerDB.Gender = "Female";
            customerDB.Address = txtAddress.Text;

            db.SubmitChanges();

            fCustomer_Load(sender, e);
            MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSort.SelectedIndex != -1)
                txtTim.Text = "";

            switch (cboSort.SelectedIndex)
            {
                case 0:
                    fCustomer_Load(sender, e);
                    break;
                case 1:
                        dgvManager.DataSource = db.CustomerDBs.OrderBy(item => item.Name).ToList();
                    break;
                case 2:
                        dgvManager.DataSource = db.CustomerDBs.OrderBy(item => item.Birthdate);
                    break;
                default:
                    break;
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            cboSort.SelectedIndex = -1;
            dgvManager.DataSource = db.CustomerDBs.Where(s => s.Name.Contains(txtTim.Text)).ToList();
        }
    }
}

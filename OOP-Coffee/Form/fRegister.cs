using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OOP_Coffee.Utils;

namespace OOP_Coffee.Form
{
    public partial class fRegister : System.Windows.Forms.Form
    {
        public fRegister()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            label1.Visible = true;
            label1.Text = dateTimePicker1.Value.ToString("dd/ MM/ yyyy");

        }
        private void dateTimePicker1_DateChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Text = dateTimePicker1.Value.ToString("dd/ MM/ yyyy");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox1.BringToFront();
            textBox1.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.BringToFront();
            textBox2.Focus();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox3.BringToFront();
            textBox3.Focus();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            textBox4.BringToFront();
            textBox4.Focus();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            textBox5.BringToFront();
            textBox5.Focus();
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(currentTextBox.Text))
            {
                currentTextBox.SendToBack();
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //DateTimePicker newDateTimePicker = new DateTimePicker();

            //newDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            //newDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            //newDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //newDateTimePicker.CustomFormat = "dd/MM/yyyy"; 
            //newDateTimePicker.Location = new System.Drawing.Point(366, 216);
            //newDateTimePicker.Name = "newDateTimePicker";
            //newDateTimePicker.Size = new System.Drawing.Size(120, 30); 


            //this.Controls.Add(newDateTimePicker);
            //newDateTimePicker.Visible = true;

            //newDateTimePicker.Focus();

        }

        // Submit Btn
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox1.Text;
                string gender = comboBox1.Text;
                string phone = textBox2.Text;
                string address = textBox3.Text;
                DateTime birth = dateTimePicker1.Value;
                string password = textBox4.Text;
                string confirmPassword = textBox5.Text;
                if(ValidateUserData(name, gender, phone, address, password, confirmPassword, birth))
                {
                    CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
                    CustomerDB newCustomer = new CustomerDB
                    {
                        Name = name,
                        Gender = gender,
                        Phone = phone,
                        Address = address,
                        Password = Password.HashPassword(password),
                    };
                    db.CustomerDBs.InsertOnSubmit(newCustomer);
                    db.SubmitChanges();
                    this.Close();
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public bool ValidateUserData(string name, string gender, string phone, string address, string password, string confirmPassword, DateTime birth)
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên.");
                return false;
            }

            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Vui lòng chọn giới tính.");
                return false;
            }

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                return false;
            }
            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.");
                return false;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ.");
                return false;
            }
            if (birth > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.");
                return false;
            }

            if (birth == DateTime.MinValue)
            {
                MessageBox.Show("Vui lòng chọn ngày tháng năm sinh.");
                return false;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.");
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.");
                return false;
            }

            return true;
        }
    }
}

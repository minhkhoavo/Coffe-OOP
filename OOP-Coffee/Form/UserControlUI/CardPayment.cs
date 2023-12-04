using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Coffee.Form.UserControlUI
{
    public partial class CardPayment : UserControl
    {
        bool isValidNumCard = true;
        public CardPayment()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.BringToFront();
            textBox1.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.BringToFront();
            textBox2.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox3.BringToFront();
            textBox3.Focus();
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(currentTextBox.Text))
            {
                currentTextBox.SendToBack();
            }
        }
        public static bool IsValidCreditCard(string cardNumber)
        {
            Regex regex = new Regex(@"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$");
            return regex.IsMatch(cardNumber);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.SendToBack();
                return;
            } 
            if(!IsValidCreditCard(textBox1.Text))
            {
                MessageBox.Show("Số thẻ không hợp lệ! Vui lòng nhập lại");
                isValidNumCard = false;
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    
        public bool checkValid()
        {
            if(isValidNumCard && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text))
            {
                return true;
            }
            return false;
        }
    }
}

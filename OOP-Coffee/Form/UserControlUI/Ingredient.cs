using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Coffee.Form.UserControlUI
{
    public partial class Ingredient : UserControl
    {
        private int id;
        private string nametp;
        private string donVi;
        private int soLuong;

        public string Nametp { get => nametp; set => nametp = value; }
        public string DonVi { get => donVi; set => donVi = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public int Id { get => id; set => id = value; }

        public Ingredient()
        {
            InitializeComponent();

        }
        public Ingredient(int id, string name, string dv, int sl)
        {
            InitializeComponent();
            this.Id = id;
            lblTen.Text = name;
            lblDonVi.Text = dv;
            numericUpDown1.Value = sl;
        }

      

        private void Ingredient_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SoLuong = int.Parse(numericUpDown1.Value.ToString());
        }
    }
}

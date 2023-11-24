using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Coffee.Form
{
    public partial class fAdmin : System.Windows.Forms.Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        private void todayBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;
            LinQDBDataContext db = new LinQDBDataContext();
            var query = from data in db.Dashboards
                        where data.order_date >= startDate && data.order_date <= endDate
                        select data;
            List<Dashboard> result = query.ToList();
            dataGridView1.DataSource = result;
        }

        private void weekBtn_Click(object sender, EventArgs e)
        {
            //DateTime startDate = new DateTime(2023, 10, 1);
            //DateTime endDate = new DateTime(2023, 10, 7);

            DateTime startDate = DateTime.Today.AddDays(-6);
            DateTime endDate = DateTime.Today;
            LinQDBDataContext db = new LinQDBDataContext();
            var query = from data in db.Dashboards
                        where data.order_date >= startDate && data.order_date <= endDate
                        select data;
            List<Dashboard> result = query.ToList();
            dataGridView1.DataSource = result;
        }

        private void monthBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            LinQDBDataContext db = new LinQDBDataContext();
            var query = from data in db.Dashboards
                        where data.order_date >= startDate && data.order_date <= endDate
                        select data;
            List<Dashboard> result = query.ToList();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;
            MessageBox.Show(startDate.ToString());
            LinQDBDataContext db = new LinQDBDataContext();
            var query = from data in db.Dashboards
                        where data.order_date >= startDate && data.order_date <= endDate
                        select data;
            List<Dashboard> result = query.ToList();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OOP_Coffee.Model;

namespace OOP_Coffee.Form
{
    public partial class fOrderManagement : System.Windows.Forms.Form
    {
        public fOrderManagement()
        {
            InitializeComponent();
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            viewData(startDate, endDate);
  
        }
        private void fOrderManagement_Load(object sender, EventArgs e)
        {

        }

        private void todayBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today;
            viewData(startDate, endDate);
        }

        private void weekBtn_Click(object sender, EventArgs e)
        {
            //DateTime startDate = new DateTime(2023, 10, 1);
            //DateTime endDate = new DateTime(2023, 10, 7);

            DateTime startDate = DateTime.Today.AddDays(-6);
            DateTime endDate = DateTime.Today;
            viewData(startDate, endDate);
        }

        private void monthBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            viewData(startDate, endDate);
        }
        private void yearBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, 1, 1);
            DateTime endDate = DateTime.Today;
            viewData(startDate, endDate);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;
            if (endDate < startDate)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu. Vui lòng chọn lại.");
                return;
            }

            if (endDate > DateTime.Today)
            {
                MessageBox.Show("Ngày kết thúc không được lớn hơn ngày hiện tại. Vui lòng chọn lại.");
                return;
            }
            viewData(startDate, endDate);
        }
        private void viewData(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();

            totalOrder_lbl.Text = (Dashboard.GetCompletedOrderCount(startDate, endDate) + Dashboard.GetRejectedOrderCount(startDate, endDate)).ToString();
            totalReject_lbl.Text = Dashboard.GetRejectedOrderCount(startDate, endDate).ToString();
            rating_lbl.Text = Dashboard.GetAverageRating(startDate, endDate).ToString();
            var orderData = db.OrderDBs
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .Join(
                    db.CustomerDBs,
                    order => order.CustomerID,
                    customer => customer.CustomerID,
                    (order, customer) => new
                    {
                        customer.Name,
                        order.OrderDate,
                        order.RatingStar,
                        order.Comment,
                        order.OrderID,
                    })
                .Where(o => o.RatingStar != null || o.Comment != null)
                .ToList();

            if (orderData.Any())
            {
                dataGridView1.DataSource = orderData;
            }
            else
            {
                MessageBox.Show("Hiện tại không có dữ liệu phù hợp.");
                DataTable tempTable = new DataTable();
                tempTable.Columns.Add("Message", typeof(string));
                tempTable.Rows.Add("Không có dữ liệu phù hợp.");

                dataGridView1.DataSource = tempTable;
            }

            updatePieChartOrderStatus(startDate, endDate);
            DrawChart(startDate, endDate);
        }

        private void updatePieChartOrderStatus(DateTime startDate, DateTime endDate)
        {
            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var orderStatusCount = db.OrderDBs
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .Join(
                    db.OrderItemDBs,
                    order => order.OrderID,
                    orderItem => orderItem.OrderID,
                    (order, orderItem) => orderItem.Status)
                .GroupBy(status => status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .Where(x => x.Status == "Completed" || x.Status == "Rejected")
            .ToList();

            chart2.Series["OrderStatus"].Points.Clear();
            int sumStatusCount = orderStatusCount.Sum(statusCount => statusCount.Count);

            foreach (var statusCount in orderStatusCount)
            {
                double percentage = (double)statusCount.Count * 100 / sumStatusCount;
                string formattedPercentage = percentage.ToString("0.0");
                chart2.Series["OrderStatus"].Points.AddXY(statusCount.Status, formattedPercentage);
            }

        }
        private void DrawChart(DateTime startDate, DateTime endDate)
        {
            chart1.Titles.Clear();

            CoffeeDataModelDataContext db = new CoffeeDataModelDataContext();
            var rejectedOrders = Dashboard.getRejectedOrderByDay(startDate, endDate);
            Series orderRejectSeries = chart1.Series["orderReject"];
            orderRejectSeries.Points.Clear();
            foreach (var order in rejectedOrders)
            {
                orderRejectSeries.Points.AddXY(order.OrderDate.ToShortDateString(), order.OrdersCount);
            }

            var successfulOrders = Dashboard.getSuccessOrderByDay(startDate, endDate);
            Series orderSuccessSeries = chart1.Series["orderSuccess"];
            orderSuccessSeries.Points.Clear();
            foreach (var order in successfulOrders)
            {
                orderSuccessSeries.Points.AddXY(order.OrderDate.ToShortDateString(), order.OrdersCount);
            }

            var ratings = Dashboard.getAverageRatingByDay(startDate, endDate);
            Series ratingSeries = chart1.Series["Rating"];
            ratingSeries.Points.Clear();
            foreach (var rating in ratings)
            {
                ratingSeries.Points.AddXY(rating.OrderDate.ToShortDateString(), rating.OrdersCount);
                ratingSeries.YAxisType = AxisType.Secondary;
            }
        }

        private void fileBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Export to Text File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                ExportToTxt(saveFileDialog.FileName, dataGridView1);
                MessageBox.Show("Exported successfully!");
            }
        }
        private void ExportToTxt(string filePath, DataGridView dataGridView)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Ghi tiêu đề cột
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    sw.Write(dataGridView.Columns[i].HeaderText);
                    if (i < dataGridView.Columns.Count - 1)
                    {
                        sw.Write("\t");
                    }
                }
                sw.WriteLine();

                // Ghi dữ liệu từ DataGridView vào file .txt
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            sw.Write(row.Cells[i].Value.ToString());
                        }

                        if (i < dataGridView.Columns.Count - 1)
                        {
                            sw.Write("\t");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }


    }


}


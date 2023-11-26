using CoffeeShop;
using OOP_Coffee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_CoffeeApp
{
    public partial class fAdmin : System.Windows.Forms.Form
    {
        public fAdmin()
        {
            InitializeComponent();
            viewData(DateTime.Today, DateTime.Today);
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

            DateTime startDate = new DateTime(2023, 10, 1);
            //DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            viewData(startDate, endDate);
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;
            viewData(startDate, endDate);
        }

        private void viewData(DateTime startDate, DateTime endDate)
        {
            decimal totalRevenue = 0;
            decimal totalProfit = 0;

            List<Dashboard> result = Manager.getSalesData(startDate, endDate);
            List<SalesResult> salesByProduct = Manager.getSalesByProduct(startDate, endDate);
            
            foreach (var item in result)
            {
                totalRevenue += item.total_price;
                totalProfit += item.total_profit;
            }
            foreach (var sale in salesByProduct)
            {
                string productName = Repositories.getProductNameById(sale.ProductID);


                // Thêm điểm dữ liệu vào Series
                chart1.Series["Sales"].Points.AddXY(sale.TotalQuantity.ToString(), sale.TotalQuantity);

                // Thêm chú thích (Legend) bên ngoài cho từng điểm dữ liệu
                int pointIndex = chart1.Series["Sales"].Points.Count - 1;
                chart1.Series["Sales"].Points[pointIndex].LegendText = productName;
            }

            totalOrder_lbl.Text = result.Count.ToString();
            totalRevenue_lbl.Text = totalRevenue.ToString();
            totalProfit_lbl.Text = totalProfit.ToString();
            dataGridView1.DataSource = result;
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
                        if (dataGridView.Columns[i].Name == "order_date") sw.Write("\t\t");
                        else sw.Write("\t"); 
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
                            if (dataGridView.Columns[i].Name == "order_date") sw.Write("\t\t");
                            else sw.Write("\t");
                        }
                    }
                    sw.WriteLine();
                }
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
    }
}

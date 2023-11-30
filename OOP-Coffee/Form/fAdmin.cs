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
using OOP_Coffee;

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

            //DateTime startDate = new DateTime(2023, 11, 1);
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
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
            decimal totalRevenue = 0;
            decimal totalProfit = 0;

            List<DashboardDB> result = Manager.getSalesData(startDate, endDate);
            List<SalesResult> salesByProduct = Manager.getSalesByProduct(startDate, endDate);
            
            foreach (var item in result)
            {
                totalRevenue += item.totalRevenue;
                totalProfit += item.totalRevenue;
            }

            chart1.Series["Sales"].Points.Clear();
            foreach (var sale in salesByProduct)
            {
                string productName = Repositories.getProductNameById(sale.ProductID);

                chart1.Series["Sales"].Points.AddXY(sale.TotalQuantity.ToString(), sale.TotalQuantity);
                int pointIndex = chart1.Series["Sales"].Points.Count - 1;
                chart1.Series["Sales"].Points[pointIndex].LegendText = productName;
            }

            totalOrder_lbl.Text = result.Count.ToString();
            totalRevenue_lbl.Text = totalRevenue.ToString();
            totalProfit_lbl.Text = totalProfit.ToString();
            dataGridView1.DataSource = result;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["order_id"].Visible = false;
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

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeManager employeeManagementForm = new EmployeeManager();
            employeeManagementForm.ShowDialog();
        }

        private void quảnLýKhoHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Iventory inventoryForm = new Iventory();
            inventoryForm.ShowDialog();
        }
    }
}

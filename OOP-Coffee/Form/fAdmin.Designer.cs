namespace OOP_CoffeeApp
{
    partial class fAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileBtn = new System.Windows.Forms.Button();
            this.monthBtn = new System.Windows.Forms.Button();
            this.weekBtn = new System.Windows.Forms.Button();
            this.todayBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.totalProfit_lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.totalRevenue_lbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.totalOrder_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.revenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKhoHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.quảnLýĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admin";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(105, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(111, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(251, 14);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(111, 26);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileBtn);
            this.panel1.Controls.Add(this.monthBtn);
            this.panel1.Controls.Add(this.weekBtn);
            this.panel1.Controls.Add(this.todayBtn);
            this.panel1.Controls.Add(this.okBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(12, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1234, 50);
            this.panel1.TabIndex = 2;
            // 
            // fileBtn
            // 
            this.fileBtn.Location = new System.Drawing.Point(1094, 9);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(117, 38);
            this.fileBtn.TabIndex = 2;
            this.fileBtn.Text = "Export to File";
            this.fileBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.fileBtn.UseVisualStyleBackColor = true;
            this.fileBtn.Click += new System.EventHandler(this.fileBtn_Click);
            // 
            // monthBtn
            // 
            this.monthBtn.Location = new System.Drawing.Point(823, 6);
            this.monthBtn.Name = "monthBtn";
            this.monthBtn.Size = new System.Drawing.Size(117, 41);
            this.monthBtn.TabIndex = 2;
            this.monthBtn.Text = "This month";
            this.monthBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.monthBtn.UseVisualStyleBackColor = true;
            this.monthBtn.Click += new System.EventHandler(this.monthBtn_Click);
            // 
            // weekBtn
            // 
            this.weekBtn.Location = new System.Drawing.Point(686, 7);
            this.weekBtn.Name = "weekBtn";
            this.weekBtn.Size = new System.Drawing.Size(117, 41);
            this.weekBtn.TabIndex = 2;
            this.weekBtn.Text = "Last 7 days";
            this.weekBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.weekBtn.UseVisualStyleBackColor = true;
            this.weekBtn.Click += new System.EventHandler(this.weekBtn_Click);
            // 
            // todayBtn
            // 
            this.todayBtn.Location = new System.Drawing.Point(590, 7);
            this.todayBtn.Name = "todayBtn";
            this.todayBtn.Size = new System.Drawing.Size(75, 41);
            this.todayBtn.TabIndex = 2;
            this.todayBtn.Text = "Today";
            this.todayBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.todayBtn.UseVisualStyleBackColor = true;
            this.todayBtn.Click += new System.EventHandler(this.todayBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(384, 8);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 38);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(12, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1234, 123);
            this.panel2.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.totalProfit_lbl);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Location = new System.Drawing.Point(802, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(409, 114);
            this.panel5.TabIndex = 0;
            // 
            // totalProfit_lbl
            // 
            this.totalProfit_lbl.AutoSize = true;
            this.totalProfit_lbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.totalProfit_lbl.ForeColor = System.Drawing.Color.Black;
            this.totalProfit_lbl.Location = new System.Drawing.Point(157, 54);
            this.totalProfit_lbl.Name = "totalProfit_lbl";
            this.totalProfit_lbl.Size = new System.Drawing.Size(120, 41);
            this.totalProfit_lbl.TabIndex = 1;
            this.totalProfit_lbl.Text = "100000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label7.Location = new System.Drawing.Point(168, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 1;
            this.label7.Text = "Lợi nhuận";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.totalRevenue_lbl);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(319, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(456, 114);
            this.panel4.TabIndex = 0;
            // 
            // totalRevenue_lbl
            // 
            this.totalRevenue_lbl.AutoSize = true;
            this.totalRevenue_lbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.totalRevenue_lbl.ForeColor = System.Drawing.Color.Black;
            this.totalRevenue_lbl.Location = new System.Drawing.Point(162, 51);
            this.totalRevenue_lbl.Name = "totalRevenue_lbl";
            this.totalRevenue_lbl.Size = new System.Drawing.Size(120, 41);
            this.totalRevenue_lbl.TabIndex = 1;
            this.totalRevenue_lbl.Text = "100000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label5.Location = new System.Drawing.Point(174, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 1;
            this.label5.Text = "Doanh thu";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.totalOrder_lbl);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(286, 114);
            this.panel3.TabIndex = 0;
            // 
            // totalOrder_lbl
            // 
            this.totalOrder_lbl.AutoSize = true;
            this.totalOrder_lbl.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.totalOrder_lbl.ForeColor = System.Drawing.Color.Black;
            this.totalOrder_lbl.Location = new System.Drawing.Point(76, 51);
            this.totalOrder_lbl.Name = "totalOrder_lbl";
            this.totalOrder_lbl.Size = new System.Drawing.Size(120, 41);
            this.totalOrder_lbl.TabIndex = 1;
            this.totalOrder_lbl.Text = "100000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(60, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tổng số đơn hàng";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.revenue,
            this.profit});
            this.dataGridView1.Location = new System.Drawing.Point(15, 267);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(772, 413);
            this.dataGridView1.TabIndex = 5;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "OrderDate";
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 8;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 150;
            // 
            // revenue
            // 
            this.revenue.DataPropertyName = "totalRevenue";
            this.revenue.HeaderText = "Doanh thu";
            this.revenue.MinimumWidth = 8;
            this.revenue.Name = "revenue";
            this.revenue.ReadOnly = true;
            this.revenue.Width = 150;
            // 
            // profit
            // 
            this.profit.DataPropertyName = "totalProfit";
            this.profit.HeaderText = "Lợi nhuận";
            this.profit.MinimumWidth = 8;
            this.profit.Name = "profit";
            this.profit.ReadOnly = true;
            this.profit.Width = 150;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýNhânViênToolStripMenuItem,
            this.quảnLýKhoHàngToolStripMenuItem,
            this.quảnLýSảnPhẩmToolStripMenuItem,
            this.quảnLýĐơnHàngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1258, 33);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(170, 29);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // quảnLýKhoHàngToolStripMenuItem
            // 
            this.quảnLýKhoHàngToolStripMenuItem.Name = "quảnLýKhoHàngToolStripMenuItem";
            this.quảnLýKhoHàngToolStripMenuItem.Size = new System.Drawing.Size(169, 29);
            this.quảnLýKhoHàngToolStripMenuItem.Text = "Quản lý kho hàng";
            this.quảnLýKhoHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKhoHàngToolStripMenuItem_Click);
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(172, 29);
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Quản lý sản phẩm";
            this.quảnLýSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýSảnPhẩmToolStripMenuItem_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(814, 267);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Sales";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(409, 413);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // quảnLýĐơnHàngToolStripMenuItem
            // 
            this.quảnLýĐơnHàngToolStripMenuItem.Name = "quảnLýĐơnHàngToolStripMenuItem";
            this.quảnLýĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(171, 29);
            this.quảnLýĐơnHàngToolStripMenuItem.Text = "Quản lý đơn hàng";
            this.quảnLýĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýĐơnHàngToolStripMenuItem_Click);
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 711);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAdmin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.Button monthBtn;
        private System.Windows.Forms.Button weekBtn;
        private System.Windows.Forms.Button todayBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label totalOrder_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label totalProfit_lbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label totalRevenue_lbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKhoHàngToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn revenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn profit;
        private System.Windows.Forms.ToolStripMenuItem quảnLýĐơnHàngToolStripMenuItem;
    }
}
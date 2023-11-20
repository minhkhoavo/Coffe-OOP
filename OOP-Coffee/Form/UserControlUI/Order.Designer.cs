namespace OOP_Coffee.Form.UserControlUI
{
    partial class Order
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orderImg = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.orderTotal_lbl = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.orderPrice_lbl = new System.Windows.Forms.Label();
            this.orderName_lbl = new System.Windows.Forms.Label();
            this.orderNote_lbl = new System.Windows.Forms.TextBox();
            this.orderDelete_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderImg)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // orderImg
            // 
            this.orderImg.Location = new System.Drawing.Point(14, 4);
            this.orderImg.Name = "orderImg";
            this.orderImg.Size = new System.Drawing.Size(45, 41);
            this.orderImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.orderImg.TabIndex = 0;
            this.orderImg.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.orderTotal_lbl);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.orderPrice_lbl);
            this.panel1.Controls.Add(this.orderName_lbl);
            this.panel1.Controls.Add(this.orderImg);
            this.panel1.Location = new System.Drawing.Point(17, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 53);
            this.panel1.TabIndex = 0;
            // 
            // orderTotal_lbl
            // 
            this.orderTotal_lbl.AutoSize = true;
            this.orderTotal_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.orderTotal_lbl.Location = new System.Drawing.Point(293, 11);
            this.orderTotal_lbl.Name = "orderTotal_lbl";
            this.orderTotal_lbl.Size = new System.Drawing.Size(48, 28);
            this.orderTotal_lbl.TabIndex = 4;
            this.orderTotal_lbl.Text = "$10";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.Gray;
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 12F);
            this.numericUpDown1.ForeColor = System.Drawing.Color.AliceBlue;
            this.numericUpDown1.Location = new System.Drawing.Point(217, 9);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(55, 35);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Click += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // orderPrice_lbl
            // 
            this.orderPrice_lbl.AutoSize = true;
            this.orderPrice_lbl.BackColor = System.Drawing.Color.Transparent;
            this.orderPrice_lbl.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.orderPrice_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(171)))), ((int)(((byte)(187)))), ((int)(((byte)(194)))));
            this.orderPrice_lbl.Location = new System.Drawing.Point(63, 25);
            this.orderPrice_lbl.Name = "orderPrice_lbl";
            this.orderPrice_lbl.Size = new System.Drawing.Size(37, 21);
            this.orderPrice_lbl.TabIndex = 2;
            this.orderPrice_lbl.Text = "$10";
            // 
            // orderName_lbl
            // 
            this.orderName_lbl.AutoSize = true;
            this.orderName_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.orderName_lbl.Location = new System.Drawing.Point(61, 3);
            this.orderName_lbl.Name = "orderName_lbl";
            this.orderName_lbl.Size = new System.Drawing.Size(129, 25);
            this.orderName_lbl.TabIndex = 1;
            this.orderName_lbl.Text = "Tên sản phẩm";
            // 
            // orderNote_lbl
            // 
            this.orderNote_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.orderNote_lbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.orderNote_lbl.Font = new System.Drawing.Font("Arial", 10F);
            this.orderNote_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.orderNote_lbl.Location = new System.Drawing.Point(12, 64);
            this.orderNote_lbl.Multiline = true;
            this.orderNote_lbl.Name = "orderNote_lbl";
            this.orderNote_lbl.Size = new System.Drawing.Size(260, 31);
            this.orderNote_lbl.TabIndex = 1;
            // 
            // orderDelete_btn
            // 
            this.orderDelete_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.orderDelete_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.orderDelete_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orderDelete_btn.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.orderDelete_btn.Location = new System.Drawing.Point(287, 62);
            this.orderDelete_btn.Name = "orderDelete_btn";
            this.orderDelete_btn.Size = new System.Drawing.Size(71, 33);
            this.orderDelete_btn.TabIndex = 2;
            this.orderDelete_btn.Text = "Xóa";
            this.orderDelete_btn.UseVisualStyleBackColor = false;
            this.orderDelete_btn.Click += new System.EventHandler(this.orderDelete_btn_Click);
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.orderDelete_btn);
            this.Controls.Add(this.orderNote_lbl);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Order";
            this.Padding = new System.Windows.Forms.Padding(14);
            this.Size = new System.Drawing.Size(374, 105);
            ((System.ComponentModel.ISupportInitialize)(this.orderImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox orderImg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label orderPrice_lbl;
        private System.Windows.Forms.Label orderName_lbl;
        private System.Windows.Forms.Label orderTotal_lbl;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.TextBox orderNote_lbl;
        private System.Windows.Forms.Button orderDelete_btn;
    }
}

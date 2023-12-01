using System.Drawing;

namespace OOP_Coffee.Form.UserControlUI
{
    partial class OrderPayment
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.quantity_lbl = new System.Windows.Forms.Label();
            this.orderTotal_lbl = new System.Windows.Forms.Label();
            this.orderName_lbl = new System.Windows.Forms.Label();
            this.orderImg = new System.Windows.Forms.PictureBox();
            this.orderNote_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.status_lbl = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderImg)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quantity_lbl);
            this.panel1.Controls.Add(this.orderTotal_lbl);
            this.panel1.Controls.Add(this.orderName_lbl);
            this.panel1.Controls.Add(this.orderImg);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 53);
            this.panel1.TabIndex = 1;
            // 
            // quantity_lbl
            // 
            this.quantity_lbl.AutoSize = true;
            this.quantity_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.quantity_lbl.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.quantity_lbl.Location = new System.Drawing.Point(218, 14);
            this.quantity_lbl.Name = "quantity_lbl";
            this.quantity_lbl.Size = new System.Drawing.Size(25, 26);
            this.quantity_lbl.TabIndex = 5;
            this.quantity_lbl.Text = "1";
            // 
            // orderTotal_lbl
            // 
            this.orderTotal_lbl.AutoSize = true;
            this.orderTotal_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.orderTotal_lbl.ForeColor = System.Drawing.Color.White;
            this.orderTotal_lbl.Location = new System.Drawing.Point(284, 11);
            this.orderTotal_lbl.Name = "orderTotal_lbl";
            this.orderTotal_lbl.Size = new System.Drawing.Size(48, 28);
            this.orderTotal_lbl.TabIndex = 4;
            this.orderTotal_lbl.Text = "$10";
            // 
            // orderName_lbl
            // 
            this.orderName_lbl.AutoSize = true;
            this.orderName_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.orderName_lbl.ForeColor = System.Drawing.Color.White;
            this.orderName_lbl.Location = new System.Drawing.Point(65, 14);
            this.orderName_lbl.Name = "orderName_lbl";
            this.orderName_lbl.Size = new System.Drawing.Size(129, 25);
            this.orderName_lbl.TabIndex = 1;
            this.orderName_lbl.Text = "Tên sản phẩm";
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
            // orderNote_lbl
            // 
            this.orderNote_lbl.AutoEllipsis = true;
            this.orderNote_lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.orderNote_lbl.ForeColor = System.Drawing.Color.White;
            this.orderNote_lbl.Location = new System.Drawing.Point(9, 58);
            this.orderNote_lbl.Name = "orderNote_lbl";
            this.orderNote_lbl.Size = new System.Drawing.Size(334, 37);
            this.orderNote_lbl.TabIndex = 2;
            this.orderNote_lbl.Text = "Đây là một ghi chú của đơn hàng này";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(349, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 100);
            this.label2.TabIndex = 3;
            // 
            // status_lbl
            // 
            this.status_lbl.AutoSize = true;
            this.status_lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.status_lbl.ForeColor = System.Drawing.Color.Yellow;
            this.status_lbl.Location = new System.Drawing.Point(359, 23);
            this.status_lbl.MaximumSize = new System.Drawing.Size(90, 0);
            this.status_lbl.Name = "status_lbl";
            this.status_lbl.Size = new System.Drawing.Size(79, 56);
            this.status_lbl.TabIndex = 4;
            this.status_lbl.Text = "Chờ xử lý";
            this.status_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OrderPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.status_lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.orderNote_lbl);
            this.Controls.Add(this.panel1);
            this.Name = "OrderPayment";
            this.Size = new System.Drawing.Size(456, 96);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label orderTotal_lbl;
        private System.Windows.Forms.Label orderName_lbl;
        private System.Windows.Forms.PictureBox orderImg;
        private System.Windows.Forms.Label quantity_lbl;
        private System.Windows.Forms.Label orderNote_lbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label status_lbl;
    }
}

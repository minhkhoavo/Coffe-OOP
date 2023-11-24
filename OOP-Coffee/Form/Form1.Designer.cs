using System.Drawing;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OOP_CoffeeApp
{
    partial class Form1 
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.total_lbl = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
<<<<<<< HEAD
            this.flowLayoutPanel1.Location = new System.Drawing.Point(7, 6);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(490, 334);
=======
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 10);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(735, 514);
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
<<<<<<< HEAD
            this.flowLayoutPanel2.Location = new System.Drawing.Point(509, 6);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(248, 259);
=======
            this.flowLayoutPanel2.Location = new System.Drawing.Point(764, 10);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(372, 398);
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(515, 277);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
=======
            this.label1.Location = new System.Drawing.Point(773, 426);
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total";
            // 
            // total_lbl
            // 
            this.total_lbl.AutoSize = true;
            this.total_lbl.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.total_lbl.ForeColor = System.Drawing.Color.Red;
<<<<<<< HEAD
            this.total_lbl.Location = new System.Drawing.Point(697, 277);
            this.total_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
=======
            this.total_lbl.Location = new System.Drawing.Point(1045, 426);
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
            this.total_lbl.Name = "total_lbl";
            this.total_lbl.Size = new System.Drawing.Size(32, 25);
            this.total_lbl.TabIndex = 3;
            this.total_lbl.Text = "$0";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
<<<<<<< HEAD
            this.button1.Location = new System.Drawing.Point(515, 311);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 29);
=======
            this.button1.Location = new System.Drawing.Point(773, 478);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(350, 44);
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
            this.button1.TabIndex = 4;
            this.button1.Text = "Payment orders";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
<<<<<<< HEAD
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(764, 353);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1147, 542);
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
            this.Controls.Add(this.button1);
            this.Controls.Add(this.total_lbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
<<<<<<< HEAD
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Quản lý coffee";
=======
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Quản lý coffee";
            this.Load += new System.EventHandler(this.Form1_Load);
>>>>>>> 9940db46e7269c4fe6be5b1477aa2cf43660c77a
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label total_lbl;
        private System.Windows.Forms.Button button1;
    }
}
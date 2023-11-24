using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1.Model
{
    partial class Product
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.proImg = new System.Windows.Forms.PictureBox();
            this.proName_lbl = new System.Windows.Forms.Label();
            this.proPrice_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proImg)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // proImg
            // 
            this.proImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.proImg.BackColor = System.Drawing.Color.Transparent;
            this.proImg.Location = new System.Drawing.Point(19, 4);
            this.proImg.Margin = new System.Windows.Forms.Padding(2);
            this.proImg.Name = "proImg";
            this.proImg.Size = new System.Drawing.Size(76, 70);
            this.proImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.proImg.TabIndex = 0;
            this.proImg.TabStop = false;
            this.proImg.Click += new System.EventHandler(this.proImg_Click);
            // 
            // proName_lbl
            // 
            this.proName_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.proName_lbl.BackColor = System.Drawing.Color.Transparent;
            this.proName_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.proName_lbl.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.proName_lbl.Location = new System.Drawing.Point(9, 80);
            this.proName_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.proName_lbl.Name = "proName_lbl";
            this.proName_lbl.Size = new System.Drawing.Size(97, 18);
            this.proName_lbl.TabIndex = 1;
            this.proName_lbl.Text = "label1";
            this.proName_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // proPrice_lbl
            // 
            this.proPrice_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.proPrice_lbl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.proPrice_lbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.proPrice_lbl.Location = new System.Drawing.Point(17, 99);
            this.proPrice_lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.proPrice_lbl.Name = "proPrice_lbl";
            this.proPrice_lbl.Size = new System.Drawing.Size(77, 17);
            this.proPrice_lbl.TabIndex = 2;
            this.proPrice_lbl.Text = "10$";
            this.proPrice_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.proPrice_lbl.Click += new System.EventHandler(this.proPrice_lbl_Click);
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(43)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.proPrice_lbl);
            this.Controls.Add(this.proName_lbl);
            this.Controls.Add(this.proImg);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Product";
            this.Size = new System.Drawing.Size(115, 122);
            this.Load += new System.EventHandler(this.Product_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private PictureBox proImg;
        private Label proName_lbl;
        private Label proPrice_lbl;
    }
}

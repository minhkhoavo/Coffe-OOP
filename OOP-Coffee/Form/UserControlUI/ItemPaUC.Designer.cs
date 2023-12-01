namespace OOP_Coffee
{
    partial class ItemPaUC
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
            this.lblI = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbaa = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblCusName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblSL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBaristaID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.SuspendLayout();
            // 
            // lblI
            // 
            this.lblI.AutoSize = true;
            this.lblI.Location = new System.Drawing.Point(54, 9);
            this.lblI.Name = "lblI";
            this.lblI.Size = new System.Drawing.Size(38, 14);
            this.lblI.TabIndex = 0;
            this.lblI.Text = "Item :";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.Color.Red;
            this.lblItem.Location = new System.Drawing.Point(97, 6);
            this.lblItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(57, 17);
            this.lblItem.TabIndex = 2;
            this.lblItem.Text = "tenItem";
            // 
            // picItem
            // 
            this.picItem.Location = new System.Drawing.Point(15, 62);
            this.picItem.Margin = new System.Windows.Forms.Padding(2);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(104, 77);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem.TabIndex = 3;
            this.picItem.TabStop = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(110, 32);
            this.lblNote.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(38, 14);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "note_";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 14);
            this.label4.TabIndex = 1;
            this.label4.Text = "Note";
            // 
            // lbaa
            // 
            this.lbaa.AutoSize = true;
            this.lbaa.Location = new System.Drawing.Point(144, 106);
            this.lbaa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbaa.Name = "lbaa";
            this.lbaa.Size = new System.Drawing.Size(39, 14);
            this.lbaa.TabIndex = 2;
            this.lbaa.Text = "CUS :";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(44, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Yes";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.OrangeRed;
            this.button2.Location = new System.Drawing.Point(184, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "No";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(142, 62);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(31, 14);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "time";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 9);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 14);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "id";
            // 
            // lblCusName
            // 
            this.lblCusName.AutoSize = true;
            this.lblCusName.Location = new System.Drawing.Point(188, 106);
            this.lblCusName.Name = "lblCusName";
            this.lblCusName.Size = new System.Drawing.Size(24, 14);
            this.lblCusName.TabIndex = 7;
            this.lblCusName.Text = "ten";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(187, 124);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(43, 14);
            this.lblPhone.TabIndex = 8;
            this.lblPhone.Text = "---------";
            // 
            // lblSL
            // 
            this.lblSL.AutoSize = true;
            this.lblSL.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSL.ForeColor = System.Drawing.Color.Red;
            this.lblSL.Location = new System.Drawing.Point(247, 3);
            this.lblSL.Name = "lblSL";
            this.lblSL.Size = new System.Drawing.Size(23, 21);
            this.lblSL.TabIndex = 9;
            this.lblSL.Text = "sl";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(222, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "SL:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(142, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "BaristaID:";
            // 
            // lblBaristaID
            // 
            this.lblBaristaID.AutoSize = true;
            this.lblBaristaID.Location = new System.Drawing.Point(217, 83);
            this.lblBaristaID.Name = "lblBaristaID";
            this.lblBaristaID.Size = new System.Drawing.Size(18, 14);
            this.lblBaristaID.TabIndex = 6;
            this.lblBaristaID.Text = "id";
            // 
            // ItemPaUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aquamarine;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSL);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblCusName);
            this.Controls.Add(this.lblBaristaID);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picItem);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.lbaa);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblI);
            this.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ItemPaUC";
            this.Size = new System.Drawing.Size(301, 198);
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblI;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbaa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblSL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBaristaID;
    }
}

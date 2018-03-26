namespace IQVL
{
    partial class frmAddLabOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddLabOrder));
            this.tblAddLabOrder = new System.Windows.Forms.TableLayoutPanel();
            this.lblLabToBeDone = new System.Windows.Forms.Label();
            this.dtpLabDoneOn = new System.Windows.Forms.DateTimePicker();
            this.lblOrderedbyDate = new System.Windows.Forms.Label();
            this.dtpOrderedbyDate = new System.Windows.Forms.DateTimePicker();
            this.lblFacilityName = new System.Windows.Forms.Label();
            this.cboFacilityName = new System.Windows.Forms.ComboBox();
            this.picNotify = new System.Windows.Forms.PictureBox();
            this.lblOrderedbyName = new System.Windows.Forms.Label();
            this.cboOrderedbyName = new System.Windows.Forms.ComboBox();
            this.lblNotify = new System.Windows.Forms.Label();
            this.btnCreateLab = new System.Windows.Forms.Button();
            this.tblAddLabOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).BeginInit();
            this.SuspendLayout();
            // 
            // tblAddLabOrder
            // 
            this.tblAddLabOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.tblAddLabOrder.ColumnCount = 3;
            this.tblAddLabOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.94366F));
            this.tblAddLabOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.49296F));
            this.tblAddLabOrder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.56338F));
            this.tblAddLabOrder.Controls.Add(this.lblLabToBeDone, 0, 1);
            this.tblAddLabOrder.Controls.Add(this.dtpLabDoneOn, 1, 1);
            this.tblAddLabOrder.Controls.Add(this.lblOrderedbyDate, 0, 2);
            this.tblAddLabOrder.Controls.Add(this.dtpOrderedbyDate, 1, 2);
            this.tblAddLabOrder.Controls.Add(this.lblFacilityName, 0, 4);
            this.tblAddLabOrder.Controls.Add(this.cboFacilityName, 1, 4);
            this.tblAddLabOrder.Controls.Add(this.picNotify, 2, 6);
            this.tblAddLabOrder.Controls.Add(this.lblOrderedbyName, 0, 3);
            this.tblAddLabOrder.Controls.Add(this.cboOrderedbyName, 1, 3);
            this.tblAddLabOrder.Controls.Add(this.lblNotify, 1, 6);
            this.tblAddLabOrder.Controls.Add(this.btnCreateLab, 1, 5);
            this.tblAddLabOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblAddLabOrder.Location = new System.Drawing.Point(0, 0);
            this.tblAddLabOrder.Name = "tblAddLabOrder";
            this.tblAddLabOrder.RowCount = 8;
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAddLabOrder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblAddLabOrder.Size = new System.Drawing.Size(489, 263);
            this.tblAddLabOrder.TabIndex = 0;
            // 
            // lblLabToBeDone
            // 
            this.lblLabToBeDone.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLabToBeDone.AutoSize = true;
            this.lblLabToBeDone.Location = new System.Drawing.Point(8, 45);
            this.lblLabToBeDone.Name = "lblLabToBeDone";
            this.lblLabToBeDone.Size = new System.Drawing.Size(106, 13);
            this.lblLabToBeDone.TabIndex = 1;
            this.lblLabToBeDone.Text = "Lab To Be Done On:";
            // 
            // dtpLabDoneOn
            // 
            this.dtpLabDoneOn.CustomFormat = "yyyy-MM-dd";
            this.dtpLabDoneOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLabDoneOn.Location = new System.Drawing.Point(120, 40);
            this.dtpLabDoneOn.Name = "dtpLabDoneOn";
            this.dtpLabDoneOn.Size = new System.Drawing.Size(192, 20);
            this.dtpLabDoneOn.TabIndex = 2;
            // 
            // lblOrderedbyDate
            // 
            this.lblOrderedbyDate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOrderedbyDate.AutoSize = true;
            this.lblOrderedbyDate.Location = new System.Drawing.Point(29, 75);
            this.lblOrderedbyDate.Name = "lblOrderedbyDate";
            this.lblOrderedbyDate.Size = new System.Drawing.Size(85, 13);
            this.lblOrderedbyDate.TabIndex = 3;
            this.lblOrderedbyDate.Text = "Ordered byDate:";
            // 
            // dtpOrderedbyDate
            // 
            this.dtpOrderedbyDate.CustomFormat = "yyyy-MM-dd";
            this.dtpOrderedbyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderedbyDate.Location = new System.Drawing.Point(120, 70);
            this.dtpOrderedbyDate.Name = "dtpOrderedbyDate";
            this.dtpOrderedbyDate.Size = new System.Drawing.Size(192, 20);
            this.dtpOrderedbyDate.TabIndex = 4;
            // 
            // lblFacilityName
            // 
            this.lblFacilityName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFacilityName.AutoSize = true;
            this.lblFacilityName.Location = new System.Drawing.Point(44, 135);
            this.lblFacilityName.Name = "lblFacilityName";
            this.lblFacilityName.Size = new System.Drawing.Size(70, 13);
            this.lblFacilityName.TabIndex = 6;
            this.lblFacilityName.Text = "FacilityName:";
            // 
            // cboFacilityName
            // 
            this.cboFacilityName.FormattingEnabled = true;
            this.cboFacilityName.Location = new System.Drawing.Point(120, 130);
            this.cboFacilityName.Name = "cboFacilityName";
            this.cboFacilityName.Size = new System.Drawing.Size(192, 21);
            this.cboFacilityName.TabIndex = 7;
            // 
            // picNotify
            // 
            this.picNotify.Location = new System.Drawing.Point(318, 190);
            this.picNotify.Name = "picNotify";
            this.picNotify.Size = new System.Drawing.Size(41, 24);
            this.picNotify.TabIndex = 9;
            this.picNotify.TabStop = false;
            // 
            // lblOrderedbyName
            // 
            this.lblOrderedbyName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblOrderedbyName.AutoSize = true;
            this.lblOrderedbyName.Location = new System.Drawing.Point(27, 105);
            this.lblOrderedbyName.Name = "lblOrderedbyName";
            this.lblOrderedbyName.Size = new System.Drawing.Size(87, 13);
            this.lblOrderedbyName.TabIndex = 10;
            this.lblOrderedbyName.Text = "OrderedbyName:";
            // 
            // cboOrderedbyName
            // 
            this.cboOrderedbyName.FormattingEnabled = true;
            this.cboOrderedbyName.Location = new System.Drawing.Point(120, 100);
            this.cboOrderedbyName.Name = "cboOrderedbyName";
            this.cboOrderedbyName.Size = new System.Drawing.Size(192, 21);
            this.cboOrderedbyName.TabIndex = 11;
            // 
            // lblNotify
            // 
            this.lblNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotify.AutoSize = true;
            this.lblNotify.Location = new System.Drawing.Point(120, 195);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(192, 13);
            this.lblNotify.TabIndex = 8;
            // 
            // btnCreateLab
            // 
            this.btnCreateLab.Location = new System.Drawing.Point(120, 160);
            this.btnCreateLab.Name = "btnCreateLab";
            this.btnCreateLab.Size = new System.Drawing.Size(154, 20);
            this.btnCreateLab.TabIndex = 5;
            this.btnCreateLab.Text = "CREATE LAB";
            this.btnCreateLab.UseVisualStyleBackColor = true;
            this.btnCreateLab.Click += new System.EventHandler(this.btnCreateLab_Click);
            // 
            // frmAddLabOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 263);
            this.Controls.Add(this.tblAddLabOrder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddLabOrder";
            this.Text = "AddNewLabOrder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddLabOrder_FormClosed);
            this.Load += new System.EventHandler(this.frmAddLabOrder_Load);
            this.tblAddLabOrder.ResumeLayout(false);
            this.tblAddLabOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblAddLabOrder;
        private System.Windows.Forms.Label lblLabToBeDone;
        private System.Windows.Forms.DateTimePicker dtpLabDoneOn;
        private System.Windows.Forms.Label lblOrderedbyDate;
        private System.Windows.Forms.DateTimePicker dtpOrderedbyDate;
        private System.Windows.Forms.Button btnCreateLab;
        private System.Windows.Forms.Label lblFacilityName;
        private System.Windows.Forms.ComboBox cboFacilityName;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.PictureBox picNotify;
        private System.Windows.Forms.Label lblOrderedbyName;
        private System.Windows.Forms.ComboBox cboOrderedbyName;
    }
}
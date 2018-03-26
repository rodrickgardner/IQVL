namespace IQVL
{
    partial class frmSearchPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchPatient));
            this.pnlSearchCriteria = new System.Windows.Forms.Panel();
            this.dtpRegDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.cboFacility = new System.Windows.Forms.ComboBox();
            this.lblFacility = new System.Windows.Forms.Label();
            this.txtIdentificationNo = new System.Windows.Forms.TextBox();
            this.lblIdentificationNo = new System.Windows.Forms.Label();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.btnSearchPatient = new System.Windows.Forms.Button();
            this.pnlSelectPatient = new System.Windows.Forms.Panel();
            this.picNotify = new System.Windows.Forms.PictureBox();
            this.lblNotify = new System.Windows.Forms.Label();
            this.btnGenerateVLLab = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.pnlSearchCriteria.SuspendLayout();
            this.pnlSelectPatient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearchCriteria
            // 
            this.pnlSearchCriteria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.pnlSearchCriteria.Controls.Add(this.dtpRegDate);
            this.pnlSearchCriteria.Controls.Add(this.dtpDOB);
            this.pnlSearchCriteria.Controls.Add(this.cboFacility);
            this.pnlSearchCriteria.Controls.Add(this.lblFacility);
            this.pnlSearchCriteria.Controls.Add(this.txtIdentificationNo);
            this.pnlSearchCriteria.Controls.Add(this.lblIdentificationNo);
            this.pnlSearchCriteria.Controls.Add(this.lblRegistrationDate);
            this.pnlSearchCriteria.Controls.Add(this.lblDOB);
            this.pnlSearchCriteria.Controls.Add(this.txtLastName);
            this.pnlSearchCriteria.Controls.Add(this.lblLastName);
            this.pnlSearchCriteria.Controls.Add(this.txtMiddleName);
            this.pnlSearchCriteria.Controls.Add(this.lblMiddleName);
            this.pnlSearchCriteria.Controls.Add(this.txtFirstName);
            this.pnlSearchCriteria.Controls.Add(this.lblFirstName);
            this.pnlSearchCriteria.Controls.Add(this.btnSearchPatient);
            this.pnlSearchCriteria.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSearchCriteria.ForeColor = System.Drawing.Color.DarkBlue;
            this.pnlSearchCriteria.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchCriteria.Name = "pnlSearchCriteria";
            this.pnlSearchCriteria.Size = new System.Drawing.Size(251, 492);
            this.pnlSearchCriteria.TabIndex = 0;
            // 
            // dtpRegDate
            // 
            this.dtpRegDate.CustomFormat = "yyyy-MM-dd";
            this.dtpRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegDate.Location = new System.Drawing.Point(9, 376);
            this.dtpRegDate.Name = "dtpRegDate";
            this.dtpRegDate.Size = new System.Drawing.Size(200, 20);
            this.dtpRegDate.TabIndex = 17;
            // 
            // dtpDOB
            // 
            this.dtpDOB.CustomFormat = "yyyy-MM-dd";
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDOB.Location = new System.Drawing.Point(9, 307);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 20);
            this.dtpDOB.TabIndex = 16;
            // 
            // cboFacility
            // 
            this.cboFacility.FormattingEnabled = true;
            this.cboFacility.Location = new System.Drawing.Point(9, 442);
            this.cboFacility.Name = "cboFacility";
            this.cboFacility.Size = new System.Drawing.Size(205, 21);
            this.cboFacility.TabIndex = 18;
            // 
            // lblFacility
            // 
            this.lblFacility.AutoSize = true;
            this.lblFacility.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFacility.Location = new System.Drawing.Point(8, 426);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(93, 13);
            this.lblFacility.TabIndex = 13;
            this.lblFacility.Text = "FACILITY  NAME:";
            // 
            // txtIdentificationNo
            // 
            this.txtIdentificationNo.Location = new System.Drawing.Point(9, 70);
            this.txtIdentificationNo.Name = "txtIdentificationNo";
            this.txtIdentificationNo.Size = new System.Drawing.Size(192, 20);
            this.txtIdentificationNo.TabIndex = 12;
            // 
            // lblIdentificationNo
            // 
            this.lblIdentificationNo.AutoSize = true;
            this.lblIdentificationNo.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblIdentificationNo.Location = new System.Drawing.Point(9, 54);
            this.lblIdentificationNo.Name = "lblIdentificationNo";
            this.lblIdentificationNo.Size = new System.Drawing.Size(114, 13);
            this.lblIdentificationNo.TabIndex = 11;
            this.lblIdentificationNo.Text = "IDENTIFICATION NO:";
            // 
            // lblRegistrationDate
            // 
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblRegistrationDate.Location = new System.Drawing.Point(6, 360);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(123, 13);
            this.lblRegistrationDate.TabIndex = 9;
            this.lblRegistrationDate.Text = "REGISTRATION DATE:";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDOB.Location = new System.Drawing.Point(9, 291);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(92, 13);
            this.lblDOB.TabIndex = 7;
            this.lblDOB.Text = "DATE OF BIRTH:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(9, 243);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(195, 20);
            this.txtLastName.TabIndex = 15;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblLastName.Location = new System.Drawing.Point(6, 227);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(71, 13);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "LAST NAME:";
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Location = new System.Drawing.Point(9, 182);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(195, 20);
            this.txtMiddleName.TabIndex = 14;
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblMiddleName.Location = new System.Drawing.Point(6, 166);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(85, 13);
            this.lblMiddleName.TabIndex = 3;
            this.lblMiddleName.Text = "MIDDLE NAME:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(9, 123);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(195, 20);
            this.txtFirstName.TabIndex = 13;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblFirstName.Location = new System.Drawing.Point(9, 107);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(75, 13);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "FIRST NAME:";
            // 
            // btnSearchPatient
            // 
            this.btnSearchPatient.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSearchPatient.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPatient.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnSearchPatient.Location = new System.Drawing.Point(0, 0);
            this.btnSearchPatient.Name = "btnSearchPatient";
            this.btnSearchPatient.Size = new System.Drawing.Size(251, 51);
            this.btnSearchPatient.TabIndex = 0;
            this.btnSearchPatient.Text = "Search Patient";
            this.btnSearchPatient.UseVisualStyleBackColor = true;
            this.btnSearchPatient.Click += new System.EventHandler(this.btnSearchPatient_Click);
            // 
            // pnlSelectPatient
            // 
            this.pnlSelectPatient.BackColor = System.Drawing.Color.LightGray;
            this.pnlSelectPatient.Controls.Add(this.picNotify);
            this.pnlSelectPatient.Controls.Add(this.lblNotify);
            this.pnlSelectPatient.Controls.Add(this.btnGenerateVLLab);
            this.pnlSelectPatient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSelectPatient.Location = new System.Drawing.Point(251, 444);
            this.pnlSelectPatient.Name = "pnlSelectPatient";
            this.pnlSelectPatient.Size = new System.Drawing.Size(724, 48);
            this.pnlSelectPatient.TabIndex = 1;
            // 
            // picNotify
            // 
            this.picNotify.Location = new System.Drawing.Point(6, 22);
            this.picNotify.Name = "picNotify";
            this.picNotify.Size = new System.Drawing.Size(46, 23);
            this.picNotify.TabIndex = 2;
            this.picNotify.TabStop = false;
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Location = new System.Drawing.Point(17, 6);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(0, 13);
            this.lblNotify.TabIndex = 1;
            // 
            // btnGenerateVLLab
            // 
            this.btnGenerateVLLab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGenerateVLLab.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGenerateVLLab.Location = new System.Drawing.Point(547, 0);
            this.btnGenerateVLLab.Name = "btnGenerateVLLab";
            this.btnGenerateVLLab.Size = new System.Drawing.Size(177, 48);
            this.btnGenerateVLLab.TabIndex = 0;
            this.btnGenerateVLLab.Text = "Generate VL LabRequest";
            this.btnGenerateVLLab.UseVisualStyleBackColor = false;
            this.btnGenerateVLLab.Click += new System.EventHandler(this.btnGenerateVLLab_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.dgvResults);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(251, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(724, 444);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvResults
            // 
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(724, 444);
            this.dgvResults.TabIndex = 0;
            this.dgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellClick);
            // 
            // frmSearchPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 492);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSelectPatient);
            this.Controls.Add(this.pnlSearchCriteria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSearchPatient";
            this.Text = "SearchPatient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSearchPatient_FormClosed);
            this.Load += new System.EventHandler(this.frmSearchPatient_Load);
            this.pnlSearchCriteria.ResumeLayout(false);
            this.pnlSearchCriteria.PerformLayout();
            this.pnlSelectPatient.ResumeLayout(false);
            this.pnlSelectPatient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchCriteria;
        private System.Windows.Forms.Panel pnlSelectPatient;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DateTimePicker dtpRegDate;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cboFacility;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.TextBox txtIdentificationNo;
        private System.Windows.Forms.Label lblIdentificationNo;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblMiddleName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Button btnSearchPatient;
        private System.Windows.Forms.Button btnGenerateVLLab;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.PictureBox picNotify;
        private System.Windows.Forms.Label lblNotify;
    }
}
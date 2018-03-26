namespace IQVL
{
    partial class frmLogin
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
            this.tcLogin = new System.Windows.Forms.TabControl();
            this.tpLogin = new System.Windows.Forms.TabPage();
            this.tlpLogin = new System.Windows.Forms.TableLayoutPanel();
            this.lblUID = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPasswordLogin = new System.Windows.Forms.TextBox();
            this.lblFacility = new System.Windows.Forms.Label();
            this.cboFacility = new System.Windows.Forms.ComboBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picLoad = new System.Windows.Forms.PictureBox();
            this.lblLoad = new System.Windows.Forms.Label();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.tblSettings = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserNameServer = new System.Windows.Forms.Label();
            this.txtUserNameServer = new System.Windows.Forms.TextBox();
            this.lblPasswordServer = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblIQCareDatabase = new System.Windows.Forms.Label();
            this.picServer = new System.Windows.Forms.PictureBox();
            this.picUserName = new System.Windows.Forms.PictureBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.picIQCareDatabase = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.picSettingsProgress = new System.Windows.Forms.PictureBox();
            this.cboServer = new System.Windows.Forms.ComboBox();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.lblSaveProgress = new System.Windows.Forms.Label();
            this.lblIQCareVersion = new System.Windows.Forms.Label();
            this.tcLogin.SuspendLayout();
            this.tpLogin.SuspendLayout();
            this.tlpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).BeginInit();
            this.tpSettings.SuspendLayout();
            this.tblSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIQCareDatabase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingsProgress)).BeginInit();
            this.SuspendLayout();
            // 
            // tcLogin
            // 
            this.tcLogin.Controls.Add(this.tpLogin);
            this.tcLogin.Controls.Add(this.tpSettings);
            this.tcLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLogin.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcLogin.Location = new System.Drawing.Point(0, 0);
            this.tcLogin.Name = "tcLogin";
            this.tcLogin.SelectedIndex = 0;
            this.tcLogin.Size = new System.Drawing.Size(432, 281);
            this.tcLogin.TabIndex = 1;
            this.tcLogin.SelectedIndexChanged += new System.EventHandler(this.tcLogin_SelectedIndexChanged);
            // 
            // tpLogin
            // 
            this.tpLogin.BackColor = System.Drawing.SystemColors.Window;
            this.tpLogin.Controls.Add(this.tlpLogin);
            this.tpLogin.Location = new System.Drawing.Point(4, 22);
            this.tpLogin.Name = "tpLogin";
            this.tpLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tpLogin.Size = new System.Drawing.Size(424, 255);
            this.tpLogin.TabIndex = 0;
            this.tpLogin.Text = "Login";
            // 
            // tlpLogin
            // 
            this.tlpLogin.BackColor = System.Drawing.SystemColors.Menu;
            this.tlpLogin.ColumnCount = 3;
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLogin.Controls.Add(this.lblUID, 0, 2);
            this.tlpLogin.Controls.Add(this.txtUser, 1, 2);
            this.tlpLogin.Controls.Add(this.lblPassword, 0, 3);
            this.tlpLogin.Controls.Add(this.txtPasswordLogin, 1, 3);
            this.tlpLogin.Controls.Add(this.lblFacility, 0, 4);
            this.tlpLogin.Controls.Add(this.cboFacility, 1, 4);
            this.tlpLogin.Controls.Add(this.btnLogin, 1, 5);
            this.tlpLogin.Controls.Add(this.picLoad, 1, 6);
            this.tlpLogin.Controls.Add(this.lblLoad, 2, 6);
            this.tlpLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogin.Location = new System.Drawing.Point(3, 3);
            this.tlpLogin.Name = "tlpLogin";
            this.tlpLogin.RowCount = 7;
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpLogin.Size = new System.Drawing.Size(418, 249);
            this.tlpLogin.TabIndex = 0;
            this.tlpLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpLogin_Paint);
            // 
            // lblUID
            // 
            this.lblUID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUID.AutoSize = true;
            this.lblUID.Location = new System.Drawing.Point(15, 47);
            this.lblUID.Name = "lblUID";
            this.lblUID.Size = new System.Drawing.Size(65, 13);
            this.lblUID.TabIndex = 0;
            this.lblUID.Text = "User Name:";
            // 
            // txtUser
            // 
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUser.Location = new System.Drawing.Point(86, 43);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(244, 22);
            this.txtUser.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(21, 75);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Password:";
            // 
            // txtPasswordLogin
            // 
            this.txtPasswordLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPasswordLogin.Location = new System.Drawing.Point(86, 71);
            this.txtPasswordLogin.Name = "txtPasswordLogin";
            this.txtPasswordLogin.PasswordChar = '*';
            this.txtPasswordLogin.Size = new System.Drawing.Size(244, 22);
            this.txtPasswordLogin.TabIndex = 3;
            this.txtPasswordLogin.UseSystemPasswordChar = true;
            // 
            // lblFacility
            // 
            this.lblFacility.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblFacility.AutoSize = true;
            this.lblFacility.Location = new System.Drawing.Point(35, 103);
            this.lblFacility.Name = "lblFacility";
            this.lblFacility.Size = new System.Drawing.Size(45, 13);
            this.lblFacility.TabIndex = 4;
            this.lblFacility.Text = "Facility:";
            this.lblFacility.Visible = false;
            // 
            // cboFacility
            // 
            this.cboFacility.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboFacility.FormattingEnabled = true;
            this.cboFacility.Location = new System.Drawing.Point(86, 99);
            this.cboFacility.Name = "cboFacility";
            this.cboFacility.Size = new System.Drawing.Size(244, 21);
            this.cboFacility.TabIndex = 5;
            this.cboFacility.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Location = new System.Drawing.Point(86, 126);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(244, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picLoad
            // 
            this.picLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picLoad.Location = new System.Drawing.Point(306, 155);
            this.picLoad.Name = "picLoad";
            this.picLoad.Size = new System.Drawing.Size(24, 24);
            this.picLoad.TabIndex = 7;
            this.picLoad.TabStop = false;
            // 
            // lblLoad
            // 
            this.lblLoad.AutoSize = true;
            this.lblLoad.Location = new System.Drawing.Point(336, 152);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(0, 13);
            this.lblLoad.TabIndex = 8;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.tblSettings);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(424, 255);
            this.tpSettings.TabIndex = 1;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // tblSettings
            // 
            this.tblSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tblSettings.ColumnCount = 4;
            this.tblSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tblSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tblSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tblSettings.Controls.Add(this.label2, 0, 1);
            this.tblSettings.Controls.Add(this.lblUserNameServer, 0, 2);
            this.tblSettings.Controls.Add(this.txtUserNameServer, 1, 2);
            this.tblSettings.Controls.Add(this.lblPasswordServer, 0, 3);
            this.tblSettings.Controls.Add(this.txtPassword, 1, 3);
            this.tblSettings.Controls.Add(this.lblIQCareDatabase, 0, 4);
            this.tblSettings.Controls.Add(this.picServer, 2, 1);
            this.tblSettings.Controls.Add(this.picUserName, 2, 2);
            this.tblSettings.Controls.Add(this.picPassword, 2, 3);
            this.tblSettings.Controls.Add(this.picIQCareDatabase, 2, 4);
            this.tblSettings.Controls.Add(this.btnSave, 1, 5);
            this.tblSettings.Controls.Add(this.picSettingsProgress, 0, 7);
            this.tblSettings.Controls.Add(this.cboServer, 1, 1);
            this.tblSettings.Controls.Add(this.cboDatabase, 1, 4);
            this.tblSettings.Controls.Add(this.lblSaveProgress, 1, 7);
            this.tblSettings.Controls.Add(this.lblIQCareVersion, 3, 4);
            this.tblSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblSettings.Location = new System.Drawing.Point(3, 3);
            this.tblSettings.Name = "tblSettings";
            this.tblSettings.RowCount = 9;
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblSettings.Size = new System.Drawing.Size(418, 249);
            this.tblSettings.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "SQL Server:";
            // 
            // lblUserNameServer
            // 
            this.lblUserNameServer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUserNameServer.AutoSize = true;
            this.lblUserNameServer.Location = new System.Drawing.Point(36, 68);
            this.lblUserNameServer.Name = "lblUserNameServer";
            this.lblUserNameServer.Size = new System.Drawing.Size(65, 13);
            this.lblUserNameServer.TabIndex = 2;
            this.lblUserNameServer.Text = "User Name:";
            // 
            // txtUserNameServer
            // 
            this.txtUserNameServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUserNameServer.Location = new System.Drawing.Point(107, 63);
            this.txtUserNameServer.Name = "txtUserNameServer";
            this.txtUserNameServer.Size = new System.Drawing.Size(226, 22);
            this.txtUserNameServer.TabIndex = 3;
            // 
            // lblPasswordServer
            // 
            this.lblPasswordServer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPasswordServer.AutoSize = true;
            this.lblPasswordServer.Location = new System.Drawing.Point(42, 98);
            this.lblPasswordServer.Name = "lblPasswordServer";
            this.lblPasswordServer.Size = new System.Drawing.Size(59, 13);
            this.lblPasswordServer.TabIndex = 4;
            this.lblPasswordServer.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(107, 93);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(226, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // lblIQCareDatabase
            // 
            this.lblIQCareDatabase.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblIQCareDatabase.AutoSize = true;
            this.lblIQCareDatabase.Location = new System.Drawing.Point(6, 128);
            this.lblIQCareDatabase.Name = "lblIQCareDatabase";
            this.lblIQCareDatabase.Size = new System.Drawing.Size(95, 13);
            this.lblIQCareDatabase.TabIndex = 6;
            this.lblIQCareDatabase.Text = "IQCare Database:";
            // 
            // picServer
            // 
            this.picServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picServer.Location = new System.Drawing.Point(339, 33);
            this.picServer.Name = "picServer";
            this.picServer.Size = new System.Drawing.Size(24, 24);
            this.picServer.TabIndex = 8;
            this.picServer.TabStop = false;
            // 
            // picUserName
            // 
            this.picUserName.Location = new System.Drawing.Point(339, 63);
            this.picUserName.Name = "picUserName";
            this.picUserName.Size = new System.Drawing.Size(24, 24);
            this.picUserName.TabIndex = 9;
            this.picUserName.TabStop = false;
            // 
            // picPassword
            // 
            this.picPassword.Location = new System.Drawing.Point(339, 93);
            this.picPassword.Name = "picPassword";
            this.picPassword.Size = new System.Drawing.Size(24, 24);
            this.picPassword.TabIndex = 10;
            this.picPassword.TabStop = false;
            // 
            // picIQCareDatabase
            // 
            this.picIQCareDatabase.Location = new System.Drawing.Point(339, 123);
            this.picIQCareDatabase.Name = "picIQCareDatabase";
            this.picIQCareDatabase.Size = new System.Drawing.Size(24, 24);
            this.picIQCareDatabase.TabIndex = 11;
            this.picIQCareDatabase.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(107, 153);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(226, 24);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picSettingsProgress
            // 
            this.picSettingsProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picSettingsProgress.Location = new System.Drawing.Point(77, 213);
            this.picSettingsProgress.Name = "picSettingsProgress";
            this.picSettingsProgress.Size = new System.Drawing.Size(24, 24);
            this.picSettingsProgress.TabIndex = 13;
            this.picSettingsProgress.TabStop = false;
            // 
            // cboServer
            // 
            this.cboServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboServer.FormattingEnabled = true;
            this.cboServer.Location = new System.Drawing.Point(107, 33);
            this.cboServer.Name = "cboServer";
            this.cboServer.Size = new System.Drawing.Size(226, 21);
            this.cboServer.TabIndex = 14;
            // 
            // cboDatabase
            // 
            this.cboDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(107, 123);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(226, 21);
            this.cboDatabase.TabIndex = 15;
            this.cboDatabase.SelectedIndexChanged += new System.EventHandler(this.cboDatabase_SelectedIndexChanged);
            this.cboDatabase.SelectionChangeCommitted += new System.EventHandler(this.cboDatabase_SelectionChangeCommitted);
            this.cboDatabase.Enter += new System.EventHandler(this.cboDatabase_Enter);
            // 
            // lblSaveProgress
            // 
            this.lblSaveProgress.AutoSize = true;
            this.lblSaveProgress.Location = new System.Drawing.Point(107, 210);
            this.lblSaveProgress.Name = "lblSaveProgress";
            this.lblSaveProgress.Size = new System.Drawing.Size(77, 13);
            this.lblSaveProgress.TabIndex = 16;
            this.lblSaveProgress.Text = "Save Progress";
            // 
            // lblIQCareVersion
            // 
            this.lblIQCareVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIQCareVersion.AutoSize = true;
            this.lblIQCareVersion.Location = new System.Drawing.Point(369, 128);
            this.lblIQCareVersion.Name = "lblIQCareVersion";
            this.lblIQCareVersion.Size = new System.Drawing.Size(0, 13);
            this.lblIQCareVersion.TabIndex = 17;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 281);
            this.Controls.Add(this.tcLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IQVL";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.tcLogin.ResumeLayout(false);
            this.tpLogin.ResumeLayout(false);
            this.tlpLogin.ResumeLayout(false);
            this.tlpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoad)).EndInit();
            this.tpSettings.ResumeLayout(false);
            this.tblSettings.ResumeLayout(false);
            this.tblSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIQCareDatabase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSettingsProgress)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcLogin;
        private System.Windows.Forms.TabPage tpLogin;
        private System.Windows.Forms.TableLayoutPanel tlpLogin;
        private System.Windows.Forms.TabPage tpSettings;
        private System.Windows.Forms.Label lblUID;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPasswordLogin;
        private System.Windows.Forms.Label lblFacility;
        private System.Windows.Forms.ComboBox cboFacility;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TableLayoutPanel tblSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserNameServer;
        private System.Windows.Forms.TextBox txtUserNameServer;
        private System.Windows.Forms.Label lblPasswordServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblIQCareDatabase;
        private System.Windows.Forms.PictureBox picServer;
        private System.Windows.Forms.PictureBox picUserName;
        private System.Windows.Forms.PictureBox picPassword;
        private System.Windows.Forms.PictureBox picIQCareDatabase;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picSettingsProgress;
        private System.Windows.Forms.PictureBox picLoad;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.ComboBox cboServer;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.Label lblSaveProgress;
        private System.Windows.Forms.Label lblIQCareVersion;
    }
}


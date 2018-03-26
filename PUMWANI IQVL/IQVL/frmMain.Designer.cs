namespace IQVL
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tpGenerate = new System.Windows.Forms.TabPage();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnGenerateCsvList = new System.Windows.Forms.Button();
            this.lblNotifycsv = new System.Windows.Forms.Label();
            this.btnAddNewList = new System.Windows.Forms.Button();
            this.picProgressCsv = new System.Windows.Forms.PictureBox();
            this.btnGenerateSelectedList = new System.Windows.Forms.Button();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.rdbClientIpNo = new System.Windows.Forms.RadioButton();
            this.rdbName = new System.Windows.Forms.RadioButton();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.txtSearchbyName = new System.Windows.Forms.TextBox();
            this.picProgress = new System.Windows.Forms.PictureBox();
            this.lblNotify = new System.Windows.Forms.Label();
            this.pnlViralloadList = new System.Windows.Forms.Panel();
            this.dtptodate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpfromdate = new System.Windows.Forms.DateTimePicker();
            this.optAllViralLoads = new System.Windows.Forms.RadioButton();
            this.optWithoutviralloads = new System.Windows.Forms.RadioButton();
            this.btnGenerateVL = new System.Windows.Forms.Button();
            this.tpUpload = new System.Windows.Forms.TabPage();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvResultUpload = new System.Windows.Forms.DataGridView();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.picUploadNotify = new System.Windows.Forms.PictureBox();
            this.lblUploadNotify = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pnlBrowse = new System.Windows.Forms.Panel();
            this.pgbUpdateIQCare = new System.Windows.Forms.ProgressBar();
            this.btnImport = new System.Windows.Forms.Button();
            this.errorProviderGenerateVL = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbcMain.SuspendLayout();
            this.tpGenerate.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgressCsv)).BeginInit();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.pnlViralloadList.SuspendLayout();
            this.tpUpload.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultUpload)).BeginInit();
            this.pnlNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUploadNotify)).BeginInit();
            this.pnlBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGenerateVL)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tpGenerate);
            this.tbcMain.Controls.Add(this.tpUpload);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Margin = new System.Windows.Forms.Padding(6);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(2718, 1155);
            this.tbcMain.TabIndex = 0;
            this.tbcMain.SelectedIndexChanged += new System.EventHandler(this.tbcMain_SelectedIndexChanged);
            // 
            // tpGenerate
            // 
            this.tpGenerate.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tpGenerate.Controls.Add(this.pnlContent);
            this.tpGenerate.Location = new System.Drawing.Point(8, 39);
            this.tpGenerate.Margin = new System.Windows.Forms.Padding(6);
            this.tpGenerate.Name = "tpGenerate";
            this.tpGenerate.Padding = new System.Windows.Forms.Padding(6);
            this.tpGenerate.Size = new System.Drawing.Size(2702, 1108);
            this.tpGenerate.TabIndex = 0;
            this.tpGenerate.Text = "Generate VL List";
            // 
            // pnlContent
            // 
            this.pnlContent.AutoSize = true;
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Controls.Add(this.pnlGrid);
            this.pnlContent.Controls.Add(this.pnlButtons);
            this.pnlContent.Controls.Add(this.pnlProgress);
            this.pnlContent.Controls.Add(this.pnlViralloadList);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(6, 6);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(6);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(2690, 1096);
            this.pnlContent.TabIndex = 0;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvResults);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(658, 92);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(6);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(2032, 842);
            this.pnlGrid.TabIndex = 6;
            this.pnlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrid_Paint);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToOrderColumns = true;
            this.dgvResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvResults.Location = new System.Drawing.Point(0, 0);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(6);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.Size = new System.Drawing.Size(2032, 842);
            this.dgvResults.TabIndex = 0;
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellContentClick);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.White;
            this.pnlButtons.Controls.Add(this.btnGenerateCsvList);
            this.pnlButtons.Controls.Add(this.lblNotifycsv);
            this.pnlButtons.Controls.Add(this.btnAddNewList);
            this.pnlButtons.Controls.Add(this.picProgressCsv);
            this.pnlButtons.Controls.Add(this.btnGenerateSelectedList);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(658, 934);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(2032, 162);
            this.pnlButtons.TabIndex = 5;
            // 
            // btnGenerateCsvList
            // 
            this.btnGenerateCsvList.AutoSize = true;
            this.btnGenerateCsvList.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateCsvList.ForeColor = System.Drawing.Color.Teal;
            this.btnGenerateCsvList.Location = new System.Drawing.Point(446, 69);
            this.btnGenerateCsvList.Margin = new System.Windows.Forms.Padding(6);
            this.btnGenerateCsvList.Name = "btnGenerateCsvList";
            this.btnGenerateCsvList.Size = new System.Drawing.Size(382, 77);
            this.btnGenerateCsvList.TabIndex = 0;
            this.btnGenerateCsvList.Text = "Generate CSV from the List";
            this.btnGenerateCsvList.UseVisualStyleBackColor = true;
            this.btnGenerateCsvList.Click += new System.EventHandler(this.btnGenerateCsvList_Click);
            // 
            // lblNotifycsv
            // 
            this.lblNotifycsv.AutoSize = true;
            this.lblNotifycsv.Location = new System.Drawing.Point(32, 15);
            this.lblNotifycsv.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNotifycsv.Name = "lblNotifycsv";
            this.lblNotifycsv.Size = new System.Drawing.Size(0, 25);
            this.lblNotifycsv.TabIndex = 3;
            // 
            // btnAddNewList
            // 
            this.btnAddNewList.AutoSize = true;
            this.btnAddNewList.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewList.ForeColor = System.Drawing.Color.Teal;
            this.btnAddNewList.Location = new System.Drawing.Point(952, 69);
            this.btnAddNewList.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddNewList.Name = "btnAddNewList";
            this.btnAddNewList.Size = new System.Drawing.Size(382, 77);
            this.btnAddNewList.TabIndex = 1;
            this.btnAddNewList.Text = "Add To The List";
            this.btnAddNewList.UseVisualStyleBackColor = true;
            this.btnAddNewList.Click += new System.EventHandler(this.btnAddNewList_Click);
            // 
            // picProgressCsv
            // 
            this.picProgressCsv.BackColor = System.Drawing.Color.White;
            this.picProgressCsv.Location = new System.Drawing.Point(22, 69);
            this.picProgressCsv.Margin = new System.Windows.Forms.Padding(6);
            this.picProgressCsv.Name = "picProgressCsv";
            this.picProgressCsv.Size = new System.Drawing.Size(126, 69);
            this.picProgressCsv.TabIndex = 4;
            this.picProgressCsv.TabStop = false;
            // 
            // btnGenerateSelectedList
            // 
            this.btnGenerateSelectedList.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSelectedList.ForeColor = System.Drawing.Color.Teal;
            this.btnGenerateSelectedList.Location = new System.Drawing.Point(1440, 69);
            this.btnGenerateSelectedList.Margin = new System.Windows.Forms.Padding(6);
            this.btnGenerateSelectedList.Name = "btnGenerateSelectedList";
            this.btnGenerateSelectedList.Size = new System.Drawing.Size(382, 77);
            this.btnGenerateSelectedList.TabIndex = 2;
            this.btnGenerateSelectedList.Text = "Generate Csv for SelectedList";
            this.btnGenerateSelectedList.UseVisualStyleBackColor = true;
            this.btnGenerateSelectedList.Click += new System.EventHandler(this.btnGenerateSelectedList_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlProgress.Controls.Add(this.rdbClientIpNo);
            this.pnlProgress.Controls.Add(this.rdbName);
            this.pnlProgress.Controls.Add(this.lblSearchName);
            this.pnlProgress.Controls.Add(this.txtSearchbyName);
            this.pnlProgress.Controls.Add(this.picProgress);
            this.pnlProgress.Controls.Add(this.lblNotify);
            this.pnlProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlProgress.Location = new System.Drawing.Point(658, 0);
            this.pnlProgress.Margin = new System.Windows.Forms.Padding(6);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(2032, 92);
            this.pnlProgress.TabIndex = 1;
            this.pnlProgress.Visible = false;
            // 
            // rdbClientIpNo
            // 
            this.rdbClientIpNo.AutoSize = true;
            this.rdbClientIpNo.Location = new System.Drawing.Point(1064, 35);
            this.rdbClientIpNo.Margin = new System.Windows.Forms.Padding(6);
            this.rdbClientIpNo.Name = "rdbClientIpNo";
            this.rdbClientIpNo.Size = new System.Drawing.Size(142, 29);
            this.rdbClientIpNo.TabIndex = 5;
            this.rdbClientIpNo.TabStop = true;
            this.rdbClientIpNo.Text = "ClientIpNo";
            this.rdbClientIpNo.UseVisualStyleBackColor = true;
            // 
            // rdbName
            // 
            this.rdbName.AutoSize = true;
            this.rdbName.Location = new System.Drawing.Point(932, 35);
            this.rdbName.Margin = new System.Windows.Forms.Padding(6);
            this.rdbName.Name = "rdbName";
            this.rdbName.Size = new System.Drawing.Size(99, 29);
            this.rdbName.TabIndex = 4;
            this.rdbName.TabStop = true;
            this.rdbName.Text = "Name";
            this.rdbName.UseVisualStyleBackColor = true;
            // 
            // lblSearchName
            // 
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchName.Location = new System.Drawing.Point(784, 37);
            this.lblSearchName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(118, 27);
            this.lblSearchName.TabIndex = 3;
            this.lblSearchName.Text = "Search by:";
            // 
            // txtSearchbyName
            // 
            this.txtSearchbyName.Location = new System.Drawing.Point(1238, 27);
            this.txtSearchbyName.Margin = new System.Windows.Forms.Padding(6);
            this.txtSearchbyName.Multiline = true;
            this.txtSearchbyName.Name = "txtSearchbyName";
            this.txtSearchbyName.Size = new System.Drawing.Size(462, 42);
            this.txtSearchbyName.TabIndex = 2;
            this.txtSearchbyName.TextChanged += new System.EventHandler(this.txtSearchbyName_TextChanged);
            // 
            // picProgress
            // 
            this.picProgress.BackColor = System.Drawing.Color.Transparent;
            this.picProgress.Location = new System.Drawing.Point(218, 6);
            this.picProgress.Margin = new System.Windows.Forms.Padding(6);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(88, 81);
            this.picProgress.TabIndex = 1;
            this.picProgress.TabStop = false;
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotify.ForeColor = System.Drawing.Color.Black;
            this.lblNotify.Location = new System.Drawing.Point(32, 33);
            this.lblNotify.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(0, 30);
            this.lblNotify.TabIndex = 0;
            // 
            // pnlViralloadList
            // 
            this.pnlViralloadList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlViralloadList.Controls.Add(this.dtptodate);
            this.pnlViralloadList.Controls.Add(this.label2);
            this.pnlViralloadList.Controls.Add(this.label1);
            this.pnlViralloadList.Controls.Add(this.dtpfromdate);
            this.pnlViralloadList.Controls.Add(this.optAllViralLoads);
            this.pnlViralloadList.Controls.Add(this.optWithoutviralloads);
            this.pnlViralloadList.Controls.Add(this.btnGenerateVL);
            this.pnlViralloadList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlViralloadList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlViralloadList.Location = new System.Drawing.Point(0, 0);
            this.pnlViralloadList.Margin = new System.Windows.Forms.Padding(6);
            this.pnlViralloadList.Name = "pnlViralloadList";
            this.pnlViralloadList.Size = new System.Drawing.Size(658, 1096);
            this.pnlViralloadList.TabIndex = 0;
            // 
            // dtptodate
            // 
            this.dtptodate.CustomFormat = "yyyy-MM-dd";
            this.dtptodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtptodate.Location = new System.Drawing.Point(146, 417);
            this.dtptodate.Margin = new System.Windows.Forms.Padding(6);
            this.dtptodate.Name = "dtptodate";
            this.dtptodate.Size = new System.Drawing.Size(400, 37);
            this.dtptodate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 425);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "ToDate ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 327);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "FromDate";
            // 
            // dtpfromdate
            // 
            this.dtpfromdate.CustomFormat = "yyyy-MM-dd";
            this.dtpfromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfromdate.Location = new System.Drawing.Point(146, 319);
            this.dtpfromdate.Margin = new System.Windows.Forms.Padding(6);
            this.dtpfromdate.Name = "dtpfromdate";
            this.dtpfromdate.Size = new System.Drawing.Size(400, 37);
            this.dtpfromdate.TabIndex = 3;
            // 
            // optAllViralLoads
            // 
            this.optAllViralLoads.AutoSize = true;
            this.optAllViralLoads.Location = new System.Drawing.Point(30, 221);
            this.optAllViralLoads.Margin = new System.Windows.Forms.Padding(6);
            this.optAllViralLoads.Name = "optAllViralLoads";
            this.optAllViralLoads.Size = new System.Drawing.Size(373, 34);
            this.optAllViralLoads.TabIndex = 2;
            this.optAllViralLoads.Text = "ViralLoad With Or Without Results";
            this.optAllViralLoads.UseVisualStyleBackColor = true;
            // 
            // optWithoutviralloads
            // 
            this.optWithoutviralloads.AutoSize = true;
            this.optWithoutviralloads.Checked = true;
            this.optWithoutviralloads.ForeColor = System.Drawing.Color.Black;
            this.optWithoutviralloads.Location = new System.Drawing.Point(30, 115);
            this.optWithoutviralloads.Margin = new System.Windows.Forms.Padding(6);
            this.optWithoutviralloads.Name = "optWithoutviralloads";
            this.optWithoutviralloads.Size = new System.Drawing.Size(370, 34);
            this.optWithoutviralloads.TabIndex = 1;
            this.optWithoutviralloads.TabStop = true;
            this.optWithoutviralloads.Text = "Patients without ViralLoad Results";
            this.optWithoutviralloads.UseVisualStyleBackColor = true;
            // 
            // btnGenerateVL
            // 
            this.btnGenerateVL.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenerateVL.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnGenerateVL.Location = new System.Drawing.Point(0, 0);
            this.btnGenerateVL.Margin = new System.Windows.Forms.Padding(6);
            this.btnGenerateVL.Name = "btnGenerateVL";
            this.btnGenerateVL.Size = new System.Drawing.Size(658, 92);
            this.btnGenerateVL.TabIndex = 0;
            this.btnGenerateVL.Text = "Generate VL List";
            this.btnGenerateVL.UseVisualStyleBackColor = true;
            this.btnGenerateVL.Click += new System.EventHandler(this.btnGenerateVL_Click);
            // 
            // tpUpload
            // 
            this.tpUpload.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tpUpload.Controls.Add(this.pnlMain);
            this.tpUpload.Controls.Add(this.pnlNavigation);
            this.tpUpload.Controls.Add(this.pnlBrowse);
            this.tpUpload.Location = new System.Drawing.Point(8, 39);
            this.tpUpload.Margin = new System.Windows.Forms.Padding(6);
            this.tpUpload.Name = "tpUpload";
            this.tpUpload.Padding = new System.Windows.Forms.Padding(6);
            this.tpUpload.Size = new System.Drawing.Size(2702, 1108);
            this.tpUpload.TabIndex = 1;
            this.tpUpload.Text = "Upload VL Results";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvResultUpload);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(6, 116);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(2690, 865);
            this.pnlMain.TabIndex = 2;
            // 
            // dgvResultUpload
            // 
            this.dgvResultUpload.AllowUserToAddRows = false;
            this.dgvResultUpload.BackgroundColor = System.Drawing.Color.White;
            this.dgvResultUpload.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResultUpload.Location = new System.Drawing.Point(0, 0);
            this.dgvResultUpload.Margin = new System.Windows.Forms.Padding(6);
            this.dgvResultUpload.Name = "dgvResultUpload";
            this.dgvResultUpload.Size = new System.Drawing.Size(2690, 865);
            this.dgvResultUpload.TabIndex = 0;
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlNavigation.Controls.Add(this.picUploadNotify);
            this.pnlNavigation.Controls.Add(this.lblUploadNotify);
            this.pnlNavigation.Controls.Add(this.btnUpdate);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigation.Location = new System.Drawing.Point(6, 981);
            this.pnlNavigation.Margin = new System.Windows.Forms.Padding(6);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(2690, 121);
            this.pnlNavigation.TabIndex = 1;
            // 
            // picUploadNotify
            // 
            this.picUploadNotify.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picUploadNotify.Location = new System.Drawing.Point(10, 12);
            this.picUploadNotify.Margin = new System.Windows.Forms.Padding(6);
            this.picUploadNotify.Name = "picUploadNotify";
            this.picUploadNotify.Size = new System.Drawing.Size(298, 100);
            this.picUploadNotify.TabIndex = 2;
            this.picUploadNotify.TabStop = false;
            // 
            // lblUploadNotify
            // 
            this.lblUploadNotify.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUploadNotify.AutoSize = true;
            this.lblUploadNotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUploadNotify.Location = new System.Drawing.Point(276, 48);
            this.lblUploadNotify.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblUploadNotify.Name = "lblUploadNotify";
            this.lblUploadNotify.Size = new System.Drawing.Size(0, 29);
            this.lblUploadNotify.TabIndex = 1;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnUpdate.Location = new System.Drawing.Point(2196, 0);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(494, 121);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "UPDATE INTO IQCARE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlBrowse
            // 
            this.pnlBrowse.Controls.Add(this.pgbUpdateIQCare);
            this.pnlBrowse.Controls.Add(this.btnImport);
            this.pnlBrowse.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBrowse.Location = new System.Drawing.Point(6, 6);
            this.pnlBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.pnlBrowse.Name = "pnlBrowse";
            this.pnlBrowse.Size = new System.Drawing.Size(2690, 110);
            this.pnlBrowse.TabIndex = 0;
            // 
            // pgbUpdateIQCare
            // 
            this.pgbUpdateIQCare.Location = new System.Drawing.Point(1158, 35);
            this.pgbUpdateIQCare.Margin = new System.Windows.Forms.Padding(6);
            this.pgbUpdateIQCare.Name = "pgbUpdateIQCare";
            this.pgbUpdateIQCare.Size = new System.Drawing.Size(1126, 44);
            this.pgbUpdateIQCare.TabIndex = 1;
            this.pgbUpdateIQCare.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.AutoSize = true;
            this.btnImport.Location = new System.Drawing.Point(50, 35);
            this.btnImport.Margin = new System.Windows.Forms.Padding(6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(342, 67);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "BROWSE  FILE";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // errorProviderGenerateVL
            // 
            this.errorProviderGenerateVL.ContainerControl = this;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2718, 1155);
            this.Controls.Add(this.tbcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VLJustification System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbcMain.ResumeLayout(false);
            this.tpGenerate.ResumeLayout(false);
            this.tpGenerate.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgressCsv)).EndInit();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.pnlViralloadList.ResumeLayout(false);
            this.pnlViralloadList.PerformLayout();
            this.tpUpload.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultUpload)).EndInit();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUploadNotify)).EndInit();
            this.pnlBrowse.ResumeLayout(false);
            this.pnlBrowse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderGenerateVL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tpGenerate;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlViralloadList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpfromdate;
        private System.Windows.Forms.RadioButton optAllViralLoads;
        private System.Windows.Forms.RadioButton optWithoutviralloads;
        private System.Windows.Forms.Button btnGenerateVL;
        private System.Windows.Forms.TabPage tpUpload;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.DateTimePicker dtptodate;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.PictureBox picProgress;
        private System.Windows.Forms.ErrorProvider errorProviderGenerateVL;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Panel pnlBrowse;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvResultUpload;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PictureBox picUploadNotify;
        private System.Windows.Forms.Label lblUploadNotify;
        private System.Windows.Forms.ProgressBar pgbUpdateIQCare;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.TextBox txtSearchbyName;
        private System.Windows.Forms.RadioButton rdbClientIpNo;
        private System.Windows.Forms.RadioButton rdbName;
        private System.Windows.Forms.Label lblNotifycsv;
        private System.Windows.Forms.PictureBox picProgressCsv;
        private System.Windows.Forms.Button btnGenerateSelectedList;
        private System.Windows.Forms.Button btnAddNewList;
        private System.Windows.Forms.Button btnGenerateCsvList;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvResults;
    }
}
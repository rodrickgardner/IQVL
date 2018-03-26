namespace IQVL
{
    partial class frmViralLoadList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViralLoadList));
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblViralwithoutresults = new System.Windows.Forms.Label();
            this.pnlNavigation = new System.Windows.Forms.Panel();
            this.picNotify = new System.Windows.Forms.PictureBox();
            this.lblNotify = new System.Windows.Forms.Label();
            this.btnAddToList = new System.Windows.Forms.Button();
            this.btnCreateLab = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.pnlSearch.SuspendLayout();
            this.pnlNavigation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).BeginInit();
            this.pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblViralwithoutresults);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(689, 30);
            this.pnlSearch.TabIndex = 0;
            // 
            // lblViralwithoutresults
            // 
            this.lblViralwithoutresults.AutoSize = true;
            this.lblViralwithoutresults.Font = new System.Drawing.Font("Segoe Marker", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViralwithoutresults.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblViralwithoutresults.Location = new System.Drawing.Point(3, 9);
            this.lblViralwithoutresults.Name = "lblViralwithoutresults";
            this.lblViralwithoutresults.Size = new System.Drawing.Size(138, 13);
            this.lblViralwithoutresults.TabIndex = 3;
            this.lblViralwithoutresults.Text = "ViralLoad Without Results:";
            // 
            // pnlNavigation
            // 
            this.pnlNavigation.Controls.Add(this.picNotify);
            this.pnlNavigation.Controls.Add(this.lblNotify);
            this.pnlNavigation.Controls.Add(this.btnAddToList);
            this.pnlNavigation.Controls.Add(this.btnCreateLab);
            this.pnlNavigation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNavigation.Location = new System.Drawing.Point(0, 370);
            this.pnlNavigation.Name = "pnlNavigation";
            this.pnlNavigation.Size = new System.Drawing.Size(689, 71);
            this.pnlNavigation.TabIndex = 1;
            // 
            // picNotify
            // 
            this.picNotify.Location = new System.Drawing.Point(12, 21);
            this.picNotify.Name = "picNotify";
            this.picNotify.Size = new System.Drawing.Size(47, 38);
            this.picNotify.TabIndex = 3;
            this.picNotify.TabStop = false;
            // 
            // lblNotify
            // 
            this.lblNotify.AutoSize = true;
            this.lblNotify.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotify.Location = new System.Drawing.Point(65, 31);
            this.lblNotify.Name = "lblNotify";
            this.lblNotify.Size = new System.Drawing.Size(0, 13);
            this.lblNotify.TabIndex = 2;
            // 
            // btnAddToList
            // 
            this.btnAddToList.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddToList.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToList.Location = new System.Drawing.Point(538, 21);
            this.btnAddToList.Name = "btnAddToList";
            this.btnAddToList.Size = new System.Drawing.Size(148, 23);
            this.btnAddToList.TabIndex = 1;
            this.btnAddToList.Text = "Add To List";
            this.btnAddToList.UseVisualStyleBackColor = true;
            this.btnAddToList.Click += new System.EventHandler(this.btnAddToList_Click);
            // 
            // btnCreateLab
            // 
            this.btnCreateLab.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCreateLab.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateLab.Location = new System.Drawing.Point(388, 21);
            this.btnCreateLab.Name = "btnCreateLab";
            this.btnCreateLab.Size = new System.Drawing.Size(132, 23);
            this.btnCreateLab.TabIndex = 0;
            this.btnCreateLab.Text = "Create Lab Order";
            this.btnCreateLab.UseVisualStyleBackColor = true;
            this.btnCreateLab.Click += new System.EventHandler(this.btnCreateLab_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.dgvResult);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 30);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(689, 340);
            this.pnlContent.TabIndex = 2;
            // 
            // dgvResult
            // 
            this.dgvResult.BackgroundColor = System.Drawing.Color.White;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.Size = new System.Drawing.Size(689, 340);
            this.dgvResult.TabIndex = 0;
            // 
            // frmViralLoadList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 441);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNavigation);
            this.Controls.Add(this.pnlSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmViralLoadList";
            this.Text = "ViralLoadList";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmViralLoadList_FormClosed);
            this.Load += new System.EventHandler(this.frmViralLoadList_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlNavigation.ResumeLayout(false);
            this.pnlNavigation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotify)).EndInit();
            this.pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel pnlNavigation;
        private System.Windows.Forms.Button btnAddToList;
        private System.Windows.Forms.Button btnCreateLab;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.PictureBox picNotify;
        private System.Windows.Forms.Label lblNotify;
        private System.Windows.Forms.Label lblViralwithoutresults;
    }
}
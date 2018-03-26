using IQVL.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQVL.BusinessLayer;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using ClosedXML.Excel;
using System.Text.RegularExpressions;


namespace IQVL
{
    public partial class frmMain : Form
    {
        int FacilityId;
        string serverType = null;
        private Dictionary<string, bool> store = new Dictionary<string, bool>();
        string iqcareconnstring = null;
        public Stream s;
        Entity theObject = new Entity();
        DataTable theDt = new DataTable();
        public string uploadfilename;
        public string locationfilename;
        public bool validtodate = true;
        public bool validfromdate = true;
        public string patientptnpk;
        public string finalres;
        public DataTable uploadresult = new DataTable();
        public int totalcount;
        string laborderidoutcome;
        string parameteridlab;

        DataView dvuploadres = new DataView();
        // Excel.Application app;
        //Excel.Workbook ows;
        //Excel.Range xlRange;
        //Excel.Worksheet xlworksheet;
        // XLWorkbook otws;
        //IXLWorksheet worksheet;
        DataTable ResultUpload = new DataTable();
        public int j;
        public int l;
        public int t;
        public int r;



        public frmMain()
        {

            InitializeComponent();
        }
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        private static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe)
                    , new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control
                    , new object[] { propertyValue });
            }
        }

        public void InitializeForm()
        {
            SetControlPropertyThreadSafe(lblUploadNotify, "Text", "");
            SetControlPropertyThreadSafe(picUploadNotify, "Image", null);
            SetControlPropertyThreadSafe(btnUpdate, "Enabled", false);
            SetControlPropertyThreadSafe(dgvResultUpload, "DataSource", null);
            SetControlPropertyThreadSafe(pgbUpdateIQCare, "Visible", false);
            SetControlPropertyThreadSafe(lblSearchName, "Visible", false);
            SetControlPropertyThreadSafe(rdbClientIpNo, "Visible", false);
            SetControlPropertyThreadSafe(rdbName, "Visible", false);
            SetControlPropertyThreadSafe(txtSearchbyName, "Visible", false);
            SetControlPropertyThreadSafe(btnImport, "Enabled", true);
            SetControlPropertyThreadSafe(picUploadNotify, "Image", null);
        }
        private void UpdateProgress(int p, ProgressBar pr)
        {
            if (pr == null) return;


            pr.Invoke(new MethodInvoker(delegate { pr.Value = p; }));
        }

        private void frmMain_Load(object sender, EventArgs e)
        {




            try
            {
                clsGbl.frmMain = this;
                serverType = Entity.GetServerType();
                iqcareconnstring = Entity.GetConnString();


                DataGridView dg = clsGbl.dgvView;
                if (dg != null)
                {
                    dg.DataSource = null;
                    dgvResults.DataSource = null;
                    DataTable dr = clsGbl.VLDataTable;
                    DataTable dt = clsGbl.VLWithoutDataTable;
                    DataTable addlist = clsGbl.AddList;

                    if (clsGbl.AddList != null)
                    {
                        if (dr != null && dr.Rows.Count > -1)
                        {



                            foreach (DataRow row in addlist.Rows)
                            {
                                dr.Rows.Add(row.ItemArray);

                            }







                            clsGbl.VLDataTable = dr;

                            dgvResults.DataSource = dr;
                            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                            checkboxColumn.HeaderText = "";
                            checkboxColumn.Width = 30;
                            checkboxColumn.Name = "checkBoxColumn";
                            dgvResults.Columns.Insert(0, checkboxColumn);

                            clsGbl.dgvView = dgvResults;


                        }

                        else if (dt != null && dt.Rows.Count > -1)
                        {


                            foreach (DataRow row in addlist.Rows)
                            {
                                dt.Rows.Add(row.ItemArray);

                            }






                            clsGbl.VLWithoutDataTable = dt;
                            dgvResults.DataSource = dt;


                            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                            checkboxColumn.HeaderText = "";
                            checkboxColumn.Width = 30;
                            checkboxColumn.Name = "checkBoxColumn";
                            dgvResults.Columns.Insert(0, checkboxColumn);
                            clsGbl.dgvView = dgvResults;


                        }
                       // pnlResults.Visible = true;
                        pnlProgress.Visible = true;
                        btnAddNewList.Enabled = true;
                        btnGenerateCsvList.Enabled = true;
                        btnGenerateSelectedList.Enabled = true;
                        lblSearchName.Visible = true;
                        txtSearchbyName.Visible = true;
                        rdbName.Visible = true;
                        rdbClientIpNo.Visible = true;
                        dgvResults.Visible = true;
                        dgvResults.Enabled = true;
                    }

                    else
                    {
                        //pnlResults.Visible = true;
                        pnlProgress.Visible = true;
                        btnAddNewList.Enabled = false;
                        btnGenerateCsvList.Enabled = false;
                        lblSearchName.Visible = false;
                        txtSearchbyName.Visible = false;
                        rdbName.Visible = false;
                        rdbClientIpNo.Visible = false;
                        btnGenerateSelectedList.Enabled = false;


                    }


                }

                else
                {



                    //pnlResults.Visible = true;
                    pnlProgress.Visible = true;
                    btnAddNewList.Enabled = false;
                    lblSearchName.Visible = false;
                    txtSearchbyName.Visible = false;
                    rdbName.Visible = false;
                    rdbClientIpNo.Visible = false;
                    btnGenerateCsvList.Enabled = false;
                    btnGenerateSelectedList.Enabled = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {


            }

        }

        private void GenerateVLAllResults(string Fromdate, string ToDate)
        {
            Entity en = new Entity();
            string connstring = Entity.GetConnString().ToString();
            string fromdate = Fromdate;
            string todate = ToDate;

            ClsUtility.Init_Hashtable();

            string squery = ViralLoadQuery.VlAllResults.ToString();
            squery = squery.Replace("@fromdate", fromdate.ToString());
            squery = squery.Replace("@todate", todate.ToString());

            try
            {


                SetControlPropertyThreadSafe(lblSearchName, "Visible", false);
                SetControlPropertyThreadSafe(rdbClientIpNo, "Visible", false);
                SetControlPropertyThreadSafe(rdbName, "Visible", false);
                SetControlPropertyThreadSafe(txtSearchbyName, "Visible", false);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", false);
                SetControlPropertyThreadSafe(lblNotifycsv, "Text", "");
                SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
                //SetControlPropertyThreadSafe(pnlResults, "Visible", true);

                SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progressWheel5);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Running Query....");
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", false);
                SetControlPropertyThreadSafe(dgvResults, "DataSource", null);
                // dgvResults.DataSource = null;
                DataTable dr = (DataTable)en.ReturnObject(connstring, ClsUtility.theParams, squery, ClsUtility.ObjectEnum.DataTable, serverType);
                clsGbl.VLDataTable = dr;

                DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                checkboxColumn.HeaderText = "";
                checkboxColumn.Width = 30;
                checkboxColumn.Name = "checkBoxColumn";



                // dgvResults.DataSource = dr;
                dgvResults.Invoke((MethodInvoker)(() => dgvResults.Columns.Insert(0, checkboxColumn)));

                SetControlPropertyThreadSafe(dgvResults, "DataSource", dr);
                //  
                // SetControlPropertyThreadSafe(dgvResults, "VirtualMode", true);
                //  dgvResults.Invoke((MethodInvoker)(() => dgvResults.CellValueNeeded += new DataGridViewCellValueEventHandler(dgvResults_CellValueNeeded)));
                //   dgvResults.Invoke((MethodInvoker)(() => dgvResults.CellValuePushed += new DataGridViewCellValueEventHandler(dgvResults_CellValuePushed)));
                clsGbl.dgvView = dgvResults;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                SetControlPropertyThreadSafe(picProgress, "Image", null);
                SetControlPropertyThreadSafe(lblNotify, "Text", dgvResults.Rows.Count.ToString() + " Records");
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", true);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", true);
                SetControlPropertyThreadSafe(lblSearchName, "Visible", true);
                SetControlPropertyThreadSafe(rdbClientIpNo, "Visible", true);
                SetControlPropertyThreadSafe(rdbName, "Visible", true);
                SetControlPropertyThreadSafe(txtSearchbyName, "Visible", true);

            }





        }

        private void GenerateVLWithoutResults(string FromDate, string ToDate)
        {

            Entity en = new Entity();
            string connstring = Entity.GetConnString().ToString();
            string fromdate = FromDate;
            string todate = ToDate;
            ClsUtility.Init_Hashtable();
            string squery = ViralLoadQuery.VLWithoutResults.ToString();

            squery = squery.Replace("@fromdate", fromdate.ToString());
            squery = squery.Replace("@todate", todate.ToString());

            try
            {

                SetControlPropertyThreadSafe(lblSearchName, "Visible", false);
                SetControlPropertyThreadSafe(rdbClientIpNo, "Visible", false);
                SetControlPropertyThreadSafe(rdbName, "Visible", false);
                SetControlPropertyThreadSafe(txtSearchbyName, "Visible", false);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", false);
                SetControlPropertyThreadSafe(lblNotifycsv, "Text", "");
                SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
              //  SetControlPropertyThreadSafe(pnlResults, "Visible", true);
                SetControlPropertyThreadSafe(picProgress, "Image", Properties.Resources.progressWheel5);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Running Query....");
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", false);
                SetControlPropertyThreadSafe(dgvResults, "DataSource", null);
                //   SetControlPropertyThreadSafe(dgvResults, "VirtualMode", true);
                // dgvResults.DataSource = null;
                DataTable dr = (DataTable)en.ReturnObject(connstring, ClsUtility.theParams, squery, ClsUtility.ObjectEnum.DataTable, serverType);
                clsGbl.VLWithoutDataTable = dr;

                DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                checkboxColumn.HeaderText = "";
                checkboxColumn.Width = 30;
                checkboxColumn.Name = "checkBoxColumn";


                // SetControlPropertyThreadSafe(dgvResults, "DataSource", dr);

                // dgvResults.DataSource = dr;
                dgvResults.Invoke((MethodInvoker)(() => dgvResults.Columns.Insert(0, checkboxColumn)));

                SetControlPropertyThreadSafe(dgvResults, "DataSource", dr);
                //   SetControlPropertyThreadSafe(dgvResults, "VirtualMode", true);

                // dgvResults.Invoke((MethodInvoker)(()=> dgvResults.CellValueNeeded+= new DataGridViewCellValueEventHandler(dgvResults_CellValueNeeded)));
                // dgvResults.Invoke((MethodInvoker)(() => dgvResults.CellValuePushed += new DataGridViewCellValueEventHandler(dgvResults_CellValuePushed)));

                clsGbl.dgvView = dgvResults;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                SetControlPropertyThreadSafe(picProgress, "Image", null);
                SetControlPropertyThreadSafe(lblNotify, "Text", dgvResults.Rows.Count.ToString() + " Records");
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", true);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", true);
                SetControlPropertyThreadSafe(lblSearchName, "Visible", true);
                SetControlPropertyThreadSafe(rdbClientIpNo, "Visible", true);
                SetControlPropertyThreadSafe(rdbName, "Visible", true);
                SetControlPropertyThreadSafe(txtSearchbyName, "Visible", true);
            }




        }
        private void runQuery()
        {


        }

        public bool ValidateControl()
        {
            if (dtpfromdate.Text.Length == 0)
            {
                errorProviderGenerateVL.SetError(dtpfromdate, "Please enter valid date");

                return false;

            }





            else if (dtptodate.Text.Length == 0)
            {
                errorProviderGenerateVL.SetError(dtptodate, "Please enter valid date");
                return false;

            }


            else if (dtpfromdate.Value.Date > dtptodate.Value.Date)
            {

                MessageBox.Show("FromDate cannot be greater than todate"
                                        , "VLSystem", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;

            }

            else
            { return true; }




        }

        private void btnGenerateVL_Click(object sender, EventArgs e)
        {
            store.Clear();
            SetControlPropertyThreadSafe(btnAddNewList, "Enabled", false);
            SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", false);
            SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", false);
            SetControlPropertyThreadSafe(lblNotifycsv, "Text", "");
            SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
            SetControlPropertyThreadSafe(lblSearchName, "Visible", false);
            SetControlPropertyThreadSafe(rdbClientIpNo, "Visible", false);
            SetControlPropertyThreadSafe(rdbName, "Visible", false);
            SetControlPropertyThreadSafe(txtSearchbyName, "Visible", false);

            dgvResults.DataSource = null;
            dgvResults.Columns.Clear();
            dgvResults.Refresh();

            picProgress.Image = null;

            lblNotify.Text = "";
          
            string fromdate = dtpfromdate.Value.Date.ToString();
            string todate = dtptodate.Value.Date.ToString();
            bool validation = true;
            bool valid = ValidateControl();
            try
            {
                if (validation == valid)
                {

                    if (optWithoutviralloads.Checked == true)
                    {
                        Thread runQueryThread = new Thread(() => GenerateVLWithoutResults(fromdate, todate));
                        runQueryThread.SetApartmentState(ApartmentState.STA);
                        runQueryThread.Start();

                    }
                    else if (optAllViralLoads.Checked == true)
                    {
                        Thread runQueryThread = new Thread(() => GenerateVLAllResults(fromdate, todate));
                        runQueryThread.SetApartmentState(ApartmentState.STA);
                        runQueryThread.Start();
                    }
                }
                else
                {

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {

                SetControlPropertyThreadSafe(lblSearchName, "Visible", true);
                SetControlPropertyThreadSafe(rdbClientIpNo, "Visible", true);
                SetControlPropertyThreadSafe(rdbName, "Visible", true);
                SetControlPropertyThreadSafe(txtSearchbyName, "Visible", true);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", true);

            }




        }


        //private void dtpfromDate_ValueChanged(object sender, EventArgs e)
        //{

        //    errorProviderGenerateVL.SetError(dtpfromdate, "");
        //    errorProviderGenerateVL.SetError(dtptodate, "");

        //}

        //private void dtptodate_ValueChanged(object sender, EventArgs e)
        //{

        //    errorProviderGenerateVL.SetError(dtpfromdate, "");
        //    errorProviderGenerateVL.SetError(dtptodate, "");
        //}

        //private void dtptodate_Validating(object sender, CancelEventArgs e)
        //{
        //    if (Convert.ToDateTime(dtptodate.Value) < Convert.ToDateTime(dtpfromdate.Value))
        //    {
        //        errorProviderGenerateVL.SetError(dtptodate, " ToDate cannot be less than fromdate");
        //        validtodate = false;

        //    }
        //    else
        //    {

        //        validtodate = true;
        //    }


        //}

        //private void dptfromDate_Validating(object sender, CancelEventArgs e)
        //{
        //    if (Convert.ToDateTime(dtpfromdate.Value) > Convert.ToDateTime(dtptodate.Value))
        //    {
        //        errorProviderGenerateVL.SetError(dtpfromdate, " FromDate cannot be greater than todate");
        //        validfromdate = false;

        //    }
        //    else
        //    {
        //        validfromdate = true;
        //    }

        //}

        private void btnGenerateCsvList_Click(object sender, EventArgs e)
        {
            string filename;
            try
            {
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", false);

                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", false);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", false);
                SetControlPropertyThreadSafe(dgvResults, "Enabled", false);
                SetControlPropertyThreadSafe(lblNotifycsv, "Text", "");

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
                {
                    DialogResult dialogResult = sfd.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        filename = sfd.FileName;
                        locationfilename = sfd.FileName;
                        WriteCsv(dgvResults, filename);
                        SetControlPropertyThreadSafe(lblNotifycsv, "Text", "Completed generating Csv file and saved at the location:" + locationfilename);

                    }
                    if (dialogResult == DialogResult.Cancel)
                    {
                        SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
                        SetControlPropertyThreadSafe(lblNotifycsv, "Text", "The operation has been cancelled");

                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", true);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", true);
                SetControlPropertyThreadSafe(dgvResults, "Enabled", true);
            }
        }

        private void WriteDataTableCsv(DataTable dt, string outputfile)
        {
            DataRow dr;
            string value;
            if (dt.Rows.Count > 0)
            {
                StreamWriter swOut = new StreamWriter(new FileStream(outputfile, FileMode.Create), Encoding.UTF8);
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    if (i > 0)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(dt.Columns[i].ColumnName);
                }
                swOut.WriteLine();
                for (int j = 0; j <= dt.Rows.Count - 1; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = dt.Rows[j];

                    for (int i = 0; i <= dt.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }

                        value = dr[i].ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();
            }

        }
        private void WriteCsv(DataGridView gridview, string outputFile)
        {

            SetControlPropertyThreadSafe(picProgressCsv, "Image", Properties.Resources.progressWheel5);
            SetControlPropertyThreadSafe(lblNotifycsv, "Text", "Generating Csv....");
            if (gridview.RowCount > 0)
            {
                string value = "";
                DataGridViewRow dr = new DataGridViewRow();
                StreamWriter swOut = new StreamWriter(new FileStream(outputFile, FileMode.Create), Encoding.UTF8);
                for (int i = 1; i <= gridview.Columns.Count - 1; i++)
                {
                    if (i > 1)
                    {
                        swOut.Write(",");
                    }
                    swOut.Write(gridview.Columns[i].HeaderText);
                }

                swOut.WriteLine();
                for (int j = 0; j <= gridview.Rows.Count - 2; j++)
                {
                    if (j > 0)
                    {
                        swOut.WriteLine();
                    }

                    dr = gridview.Rows[j];

                    for (int i = 1; i <= gridview.Columns.Count - 1; i++)
                    {
                        if (i > 1)
                        {
                            swOut.Write(",");
                        }

                        value = dr.Cells[i].Value.ToString();
                        //replace comma's with spaces
                        value = value.Replace(',', ' ');
                        //replace embedded newlines with spaces
                        value = value.Replace(Environment.NewLine, " ");

                        swOut.Write(value);
                    }
                }
                swOut.Close();



            }

        }


        public DataTable GetSelectedDataTable()
        {
            try
            {
                int jt;
                DataTable Result = new DataTable();
                if (dgvResults.ColumnCount == 0)
                {
                    return null;
                }
                for (jt = 1; jt <= dgvResults.Columns.Count - 1; jt++)
                {
                    Result.Columns.Add(dgvResults.Columns[jt].HeaderText);
                }


                for (int i = 0; i < dgvResults.RowCount - 1; i++)
                {

                    if (Convert.ToBoolean(dgvResults.Rows[i].Cells["checkBoxColumn"].Value))
                    {
                        DataRow row = Result.NewRow();
                        for (int j = 0; j <= Result.Columns.Count - 1; j++)
                        {

                            row[j] = dgvResults.Rows[i].Cells[j + 1].Value;

                        }
                        Result.Rows.Add(row);
                    }
                }

                return Result;
            }

            catch
            {
                return null;
            }

        }
        private void btnGenerateSelectedList_Click(object sender, EventArgs e)
        {
            try
            {
                string filename;
                DataTable res = new DataTable();
                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", false);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", false);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", false);
                SetControlPropertyThreadSafe(dgvResults, "Enabled", false);
                SetControlPropertyThreadSafe(lblNotifycsv, "Text", "");
                SetControlPropertyThreadSafe(picProgressCsv, "Image", Properties.Resources.progressWheel5);
                SetControlPropertyThreadSafe(lblNotifycsv, "Text", "Generating Csv....");
                res = GetSelectedDataTable();
                if (res == null)
                {
                    SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
                    SetControlPropertyThreadSafe(lblNotifycsv, "Text", "No Selected item from the list");



                }
                else
                {
                    using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
                    {
                        DialogResult dialogResult = sfd.ShowDialog();
                        if (dialogResult == DialogResult.OK)
                        {
                            filename = sfd.FileName;
                            locationfilename = sfd.FileName;
                            WriteDataTableCsv(res, filename);
                            SetControlPropertyThreadSafe(lblNotifycsv, "Text", "Completed generating Csv file and saved at the location:" + locationfilename);

                        }
                        if (dialogResult == DialogResult.Cancel)
                        {
                            SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
                            SetControlPropertyThreadSafe(lblNotifycsv, "Text", "The operation has been cancelled");

                        }




                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


            finally
            {

                SetControlPropertyThreadSafe(btnGenerateSelectedList, "Enabled", true);
                SetControlPropertyThreadSafe(picProgressCsv, "Image", null);
                SetControlPropertyThreadSafe(btnGenerateCsvList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", true);
                SetControlPropertyThreadSafe(btnAddNewList, "Enabled", true);
                SetControlPropertyThreadSafe(btnGenerateVL, "Enabled", true);
                SetControlPropertyThreadSafe(dgvResults, "Enabled", true);
            }
        }

        private void btnAddNewList_Click(object sender, EventArgs e)
        {
            Form frm = new frmSearchPatient();

            frm.Show();
            this.Hide();
        }

        private DataTable GenerateColumns(string f)
        {
            try
            {

                SetControlPropertyThreadSafe(lblUploadNotify, "Text", "Uploading data.....");



                XLWorkbook otws = new XLWorkbook(f);

                IXLWorksheet worksheet = otws.Worksheet(1);

                //var row = worksheet.Row(2).Cell(1)
                int colCount = 27;
                int RowCount = Convert.ToInt32(worksheet.Rows().Count().ToString());

                DataTable resup = new DataTable();


                if (resup != null)
                {
                    for (int i = 1; i < 2; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            resup.Columns.Add(worksheet.Row(i).Cell(j).Value.ToString());

                        }


                    }

                }









                return resup;



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //MessageBox.Show("Kindly select the correct file generated by the VLreports");


                return null;


            }
            finally
            {




            }

        }

        private DataView GenerateDataView(string f)
        {
            try
            {

                XLWorkbook ows = new XLWorkbook(f);
                IXLWorksheet worksheetdata = ows.Worksheet(1);

                int colCount = 27;
                int RowCount = Convert.ToInt32(worksheetdata.Rows().Count().ToString());
                DataTable ress = new DataTable();
                ress = ResultUpload;
                if (ress != null && ress.Columns.Count == 0)
                {

                    for (int i = 1; i < 2; i++)
                    {
                        for (int j = 1; j <= colCount; j++)
                        {
                            ress.Columns.Add(worksheetdata.Row(i).Cell(j).Value.ToString());
                        }
                    }
                }
                for (int i = 1; i <= RowCount; i++)
                {
                    DataRow row = ress.NewRow();
                    int t = 0;
                    for (int j = 1; j <= colCount; j++)
                    {

                        if (t <= ress.Columns.Count - 1)
                        {
                            if (worksheetdata.Row(i).Cell(j).Value == null)
                            {
                                row[t] = "NULL";

                            }
                            else
                            {
                                row[t] = worksheetdata.Row(i).Cell(j).Value.ToString();
                            }
                            t++;
                        }
                    }
                    ress.Rows.Add(row);
                }

                string FacilityName = clsGbl.loggedInUser.FacilityName;
                string txt;
                if (FacilityName.Trim().ToLower().Replace(" ", "") == "kigumosubcountyhosp")
                {
                    txt = "Kigumo Health Centre (Kiambu East)";
                    ResultUpload = ress;
                    DataView dvupload = ress.AsDataView();

                    dvupload.RowFilter = string.Format("[Facility Name] LIKE '{0}'", txt);

                    return dvupload;
                }
                else
                {
                    string Text = FacilityName.Split(' ').FirstOrDefault();
                    string fac = FacilityName.Split(' ')[1];
                    ResultUpload = ress;
                    DataView dvupload = ress.AsDataView();


                    dvupload.RowFilter = string.Format("[Facility Name] LIKE '{0}%' or [Facility Name] Like '{1}%'", Text,fac );

                    return dvupload;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    if (rows.Length > 1)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i].Trim();
                        }
                        dt.Rows.Add(dr);
                    }
                }

            }


            return dt;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            SetControlPropertyThreadSafe(lblUploadNotify, "Text", "Select file to upload.....");
            SetControlPropertyThreadSafe(picUploadNotify, "Image", Properties.Resources.progressWheel5);
            SetControlPropertyThreadSafe(pgbUpdateIQCare, "Value", 0);
            SetControlPropertyThreadSafe(pgbUpdateIQCare, "Visible", false);
            SetControlPropertyThreadSafe(pgbUpdateIQCare, "Value", 0);
            SetControlPropertyThreadSafe(btnUpdate, "Enabled", false);
            SetControlPropertyThreadSafe(dgvResultUpload, "DataSource", null);
            dgvResultUpload.Rows.Clear();
            dgvResultUpload.Refresh();
            ResultUpload = null;

            OpenFileDialog fd = new OpenFileDialog();
            fd.Title = "Select file";
            fd.Filter = "CSV Files(*.csv)| *.csv";
            // fd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            fd.Multiselect = false;
            if (fd.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    string ft = fd.FileName;




                    // ResultUpload = GenerateColumns(ft);
                    ResultUpload = ConvertCSVtoDataTable(ft);


                    // foreach (string f in fd.FileNames)
                    //{
                    //dvuploadres = GenerateDataView(f);



                    ///}


                    if (ResultUpload != null)
                    {
                        SetControlPropertyThreadSafe(dgvResultUpload, "DataSource", ResultUpload);
                        SetControlPropertyThreadSafe(lblUploadNotify, "Text", "Completed uploading data");
                    }
                    else
                    {
                        SetControlPropertyThreadSafe(dgvResultUpload, "DataSource", null);
                        SetControlPropertyThreadSafe(lblUploadNotify, "Text", "No data");
                    }


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());






                    SetControlPropertyThreadSafe(lblUploadNotify, "Text", "");
                    SetControlPropertyThreadSafe(picUploadNotify, "Image", null);

                    SetControlPropertyThreadSafe(btnUpdate, "Enabled", true);
                    return;

                }

                finally
                {





                    SetControlPropertyThreadSafe(picUploadNotify, "Image", null);

                    SetControlPropertyThreadSafe(btnUpdate, "Enabled", true);


                }
            }
            else
            {
                SetControlPropertyThreadSafe(lblUploadNotify, "Text", "");
                SetControlPropertyThreadSafe(picUploadNotify, "Image", null);

                SetControlPropertyThreadSafe(btnUpdate, "Enabled", true);
                tpUpload.Show();

            }


        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcMain.SelectedTab == tpUpload)
            {


                //InitializeForm();
            }

        }

        private bool check_file_oppen(string check)
        {//where string check is the path of required file


            try
            {
                Stream s = File.Open(check, FileMode.Open, FileAccess.Read, FileShare.None);
                s.Close();
                //  MessageBox.Show("FILE IS NOT OPEN");
                return true;
            }
            catch (Exception)
            {
                s.Dispose();
                // MessageBox.Show("FILE IS OPEN");

                return true;
            }
        }
        private DataTable ToDataTable(DataGridView dataGridView)
        {
            var dt = new DataTable();


            //for (jt = 1; jt <= dgvResult.Columns.Count - 1; jt++)
            //{
            //    Result.Columns.Add(dgvResult.Columns[jt].HeaderText);
            //}
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    string text = dataGridViewColumn.HeaderText.ToString();
                    text = text.Replace(" ", "").ToLower();
                    dt.Columns.Add(text);
                }
            }
            var cell = new object[dataGridView.Columns.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }
        private void UpdateData()
        {

            try
            {
                string res;
                string laborderidres;

                CancellationTokenSource cancelToken = new CancellationTokenSource();
                DataTable CorrectRes = new DataTable();
                SetControlPropertyThreadSafe(btnImport, "Enabled", false);
                SetControlPropertyThreadSafe(pgbUpdateIQCare, "Visible", true);
                SetControlPropertyThreadSafe(btnUpdate, "Enabled", false);
                SetControlPropertyThreadSafe(dgvResultUpload, "Enabled", false);
                SetControlPropertyThreadSafe(lblUploadNotify, "Text", "processing files.....");
                SetControlPropertyThreadSafe(picUploadNotify, "Image", Properties.Resources.progressWheel5);
                uploadresult.Clear();
                int rowident;
                // bool islimited = false;
                int limit = 0;
                string laborderid;
                string OrderedbyDate;
                string OrderedbyName;
                string correctage;
                string LocationID;
                string precliniclabdate;
                string parameterid;
                ParallelOptions parOpts = new ParallelOptions();
                Entity en = new Entity();
                parOpts.CancellationToken = cancelToken.Token;
                parOpts.MaxDegreeOfParallelism = Environment.ProcessorCount;
                if (uploadresult.Columns.Count == 0)
                {
                    for (int jt = 0; jt <= dgvResultUpload.Columns.Count - 1; jt++)
                    {
                        uploadresult.Columns.Add(dgvResultUpload.Columns[jt].HeaderText);
                    }
                    uploadresult.Columns.Add("LabOrderId");
                    uploadresult.Columns.Add("OrderedbyDate");
                    uploadresult.Columns.Add("OrderedbyName");
                    uploadresult.Columns.Add("TestResults");
                }
                CorrectRes = ToDataTable(dgvResultUpload);
                limit = CorrectRes.Rows.Count - 1;
                int rowcount = CorrectRes.Rows.Count;
                totalcount = CorrectRes.Rows.Count;
                int count = 0;
                int normalcount = 0;

                foreach (DataRow dtrres in CorrectRes.AsEnumerable())
                {
                    if (cancelToken.Token.IsCancellationRequested)
                    {
                        cancelToken.Token.ThrowIfCancellationRequested();
                    }
                    count = CorrectRes.Rows.IndexOf(dtrres);
                    normalcount = 1 + count;

                    // if (count>=)
                    //{
                    //  cancelToken.Cancel();
                    //}
                    // rowident = CorrectRes.Rows.IndexOf(dtrres);
                    rowident = count;
                    string patid = null;
                    patid = dtrres["enrol"].ToString();

                    string patientid = patid;

                    //  string SampleCollectedDate =dtrres["Collection Date"].ToString();
                    string SampleCollectedDate = dtrres["DateofVL"].ToString();
                    //  dgvResultUpload.Rows[i].Cells["Collection Date"].Value.ToString();
                    //string Viralload = dtrres["Viral Load"].ToString();
                    string Viralload = dtrres["VLResult"].ToString();
                    //dgvResultUpload.Rows[i].Cells["Viral Load"].Value.ToString();
                    // string Age = dtrres["Age"].ToString();
                    //dgvResultUpload.Rows[i].Cells["Age"].Value.ToString();
                    //string Sex = dtrres["Sex"].ToString();
                    //dgvResultUpload.Rows[i].Cells["Sex"].Value.ToString();
                    //string FacilityName =dtrres["Facility Name"].ToString();
                    //dgvResultUpload.Rows[i].Cells["Facility Name"].Value.ToString();
                    //string DateofReceiving =dtrres["Date of Receiving"].ToString();
                    String DateofReceiving = dtrres["DateofVL"].ToString();
                    //dgvResultUpload.Rows[i].Cells["Date of Receiving"].Value.ToString();

                    int OrderedbyId = clsGbl.loggedInUser.UserID;

                    string query = string.Format("select p.Ptn_Pk from mst_Patient p where p.PatientEnrollmentID= '{0}' or p.PatientClinicID ='{0}'  or p.ANCNumber='{0}' " +
                       "or p.HEI_ID_Number = '{0}' or p.AdmissionNumber = '{0}' or p.Patient_Number = '{0}' or p.PMTCTNumber = '{0}' or p.HTC_Number = '{0}'", patientid);
                    DataTable dr = (DataTable)en.ReturnObject(iqcareconnstring, ClsUtility.theParams
          , query, ClsUtility.ObjectEnum.DataTable, serverType);
                    if (dr != null)
                    {
                        if (dr.Rows.Count > 0)
                        {
                            patientptnpk = dr.Rows[0].ItemArray[0].ToString();

                        }
                    }
                    if (string.IsNullOrEmpty(patientptnpk))
                    {
                        patientptnpk = "nodata";
                        DataRow dnorow = uploadresult.NewRow();
                        for (int col = 0; col < dgvResultUpload.Columns.Count; col++)
                        {
                            //for (int it = 0; it < uploadresult.Columns.Count; it++)
                            //{

                            dnorow[col] = dgvResultUpload.Rows[rowident].Cells[col].Value.ToString();
                        }
                        uploadresult.Rows.Add(dnorow);


                    }
                    else
                    {
                        DateTime orderedbydate = Convert.ToDateTime(SampleCollectedDate);
                        string querylocation = string.Format("select LocationId from mst_patient where ptn_pk='{0}'", patientptnpk);
                        DataTable dtlocation = (DataTable)en.ReturnObject(iqcareconnstring, ClsUtility.theParams
, querylocation, ClsUtility.ObjectEnum.DataTable, serverType);
                        if (dtlocation != null)

                        {
                            if (dtlocation.Rows.Count > 0)
                            {
                                string fid = dtlocation.Rows[0].ItemArray[0].ToString();
                                FacilityId = Convert.ToInt32(fid);
                            }
                        }
                        string parameterqueryparam = "select SubTestID from[dbo].lnk_TestParameter where SubTestName like 'Viral Load%'";
                        DataTable dtsubtestidparam = (DataTable)en.ReturnObject(iqcareconnstring, ClsUtility.theParams
                        , parameterqueryparam, ClsUtility.ObjectEnum.DataTable, serverType);
                        string parameteridparam = dtsubtestidparam.Rows[0].ItemArray[0].ToString();
                        parameteridlab = parameteridparam;

                        string ptnpk = patientptnpk;

                        string querylabres = string.Format("select p.Ptn_Pk,plo.LabID,plo.OrderedbyDate,plo.OrderedbyName,plr.TestResults,DATEDIFF(hour,p.DOB,plo.OrderedbyDate)/8766 as Age,plo.LocationID,plo.PreClinicLabDate,plr.ParameterID from mst_patient p left join ord_PatientLabOrder " +
                                             "plo  on plo.Ptn_pk = p.Ptn_Pk left join dtl_patientlabresults plr on plr.LabID = plo.LabID " +
                                             "left join lnk_TestParameter lt on lt.SubTestID=plr.ParameterID left join mst_LabTest lts on lts.LabTestID = plr.LabTestID " +
                                             "where plo.Ptn_pk='{0}' and  plo.OrderedbyDate =cast('{1}' as datetime) ", ptnpk, Convert.ToDateTime(SampleCollectedDate));


                        DataTable dlabres = (DataTable)en.ReturnObject(iqcareconnstring, ClsUtility.theParams, querylabres, ClsUtility.ObjectEnum.DataTable, serverType);

                        laborderidoutcome = null;
                        if (dlabres != null)
                        {
                            if (dlabres.Rows.Count > 0)
                            {
                                for (int il = 0; il < dlabres.Rows.Count; il++)
                                {
                                    DataRow dlabrow = uploadresult.NewRow();
                                    laborderidoutcome = dlabres.Rows[0].ItemArray[1].ToString();

                                }
                            }
                        }
                        if (String.IsNullOrEmpty(laborderidoutcome))
                        {
                            string labidqry = "select LabTestID from[dbo].[mst_LabTest] where LabName like '%Viral%'";
                            DataTable dt = (DataTable)en.ReturnObject(iqcareconnstring, ClsUtility.theParams
                                , labidqry, ClsUtility.ObjectEnum.DataTable, serverType);
                            string labid = dt.Rows[0].ItemArray[0].ToString();
                            string parameterquery = "select SubTestID from[dbo].lnk_TestParameter where SubTestName like 'Viral Load%'";
                            DataTable dtsubtestid = (DataTable)en.ReturnObject(iqcareconnstring, ClsUtility.theParams
                            , parameterquery, ClsUtility.ObjectEnum.DataTable, serverType);
                            parameterid = dtsubtestid.Rows[0].ItemArray[0].ToString();
                            parameteridlab = parameterid;
                            laborderidres = null;
                            using (SqlConnection myconn = new SqlConnection(iqcareconnstring))
                            {
                                myconn.Open();
                                using (SqlCommand mycomm = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn))
                                {

                                    mycomm.CommandType = CommandType.StoredProcedure;
                                    mycomm.Parameters.Add(new SqlParameter("@Ptn_pk", patientptnpk));
                                    mycomm.Parameters.Add(new SqlParameter("@LocationID", FacilityId));
                                    mycomm.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                                    mycomm.Parameters.Add(new SqlParameter("@ParameterID", '0'));
                                    mycomm.Parameters.Add(new SqlParameter("@OrderedByName", OrderedbyId));
                                    mycomm.Parameters.Add(new SqlParameter("@OrderedByDate", orderedbydate));
                                    mycomm.Parameters.Add(new SqlParameter("@Flag", '0'));
                                    mycomm.Parameters.Add(new SqlParameter("@LabID", labid));
                                    mycomm.Parameters.Add(new SqlParameter("@FlagExist", '0'));
                                    mycomm.Parameters.Add(new SqlParameter("@PreClinicLabDate", orderedbydate));
                                    mycomm.Parameters.Add(new SqlParameter("@ReportedBy", clsGbl.loggedInUser.UserID));
                                    mycomm.Parameters.Add(new SqlParameter("@LabOrderId", '0'));
                                    mycomm.Parameters.Add(new SqlParameter("@TestResults", ""));
                                    mycomm.Parameters.Add(new SqlParameter("@TestResultId", '0'));
                                    mycomm.Parameters.Add(new SqlParameter("@DeleteFlag", 'N'));
                                    mycomm.Parameters.Add(new SqlParameter("@SystemId", '1'));


                                    DataTable reslaborderid = new DataTable();
                                    using (var da = new SqlDataAdapter(mycomm))
                                    {
                                        da.Fill(reslaborderid);
                                    }
                                    laborderidres = reslaborderid.Rows[0].ItemArray[0].ToString();
                                }



                            }

                            using (SqlConnection myconn2 = new SqlConnection(iqcareconnstring))
                            {
                                myconn2.Open();
                                using (SqlCommand mycommUpdate = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn2))
                                {
                                    mycommUpdate.CommandTimeout = 0;
                                    mycommUpdate.CommandType = CommandType.StoredProcedure;
                                    mycommUpdate.Parameters.Add(new SqlParameter("@Ptn_pk", patientptnpk));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@LocationID", FacilityId));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@ParameterID", parameterid));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@OrderedByName", '0'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@OrderedByDate", orderedbydate));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@Flag", '1'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@LabID", labid));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@FlagExist", '0'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@PreClinicLabDate", orderedbydate));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@ReportedBy", clsGbl.loggedInUser.UserID));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@LabOrderId", laborderidres));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@TestResults", ""));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@TestResultId", '0'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@DeleteFlag", 'N'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@SystemId", '0'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@UrgentFlag", '0'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@LabReportByDate", orderedbydate));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@LabReportByName", '0'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@Confirmed", '0'));
                                    mycommUpdate.Parameters.Add(new SqlParameter("@Confirmedby", '0'));

                                    DataTable result = new DataTable();
                                    using (var da = new SqlDataAdapter(mycommUpdate))
                                    {
                                        da.Fill(result);
                                    }

                                    string laborderedid = result.Rows[0].ItemArray[0].ToString();
                                }


                            }
                        }
                        // else
                        //{
                        string querylab = string.Format("select p.Ptn_Pk,plo.LabID,plo.OrderedbyDate,plo.OrderedbyName,plr.TestResults,DATEDIFF(hour,p.DOB,plo.OrderedbyDate)/8766 as Age,plo.LocationID,plo.PreClinicLabDate,plr.ParameterID from mst_patient p left join ord_PatientLabOrder " +
                                    "plo  on plo.Ptn_pk = p.Ptn_Pk left join dtl_patientlabresults plr on plr.LabID = plo.LabID " +
                                    "left join lnk_TestParameter lt on lt.SubTestID=plr.ParameterID left join mst_LabTest lts on lts.LabTestID = plr.LabTestID " +
                                    "where plo.Ptn_pk='{0}' and  plo.OrderedbyDate =cast('{1}' as datetime) ", patientptnpk, Convert.ToDateTime(SampleCollectedDate));
                        DataTable dlab = (DataTable)en.ReturnObject(iqcareconnstring, ClsUtility.theParams, querylab, ClsUtility.ObjectEnum.DataTable, serverType);
                        if (dlab != null)
                        {
                            if (dlab.Rows.Count > 0)
                            {
                                for (int il = 0; il < dlab.Rows.Count; il++)
                                {
                                    DataRow dlabrow = uploadresult.NewRow();
                                    laborderid = dlab.Rows[il].ItemArray[1].ToString();
                                    OrderedbyDate = dlab.Rows[il].ItemArray[2].ToString();
                                    OrderedbyName = dlab.Rows[il].ItemArray[3].ToString();
                                    correctage = dlab.Rows[il].ItemArray[5].ToString();
                                    LocationID = dlab.Rows[il].ItemArray[6].ToString();
                                    precliniclabdate = dlab.Rows[il].ItemArray[7].ToString();
                                    // parameterid = dlab.Rows[i].ItemArray[8].ToString();

                                    using (SqlConnection myconn3 = new SqlConnection(iqcareconnstring))
                                    {
                                        myconn3.Open();
                                        using (SqlCommand mycomm2 = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn3))
                                        {
                                            mycomm2.CommandTimeout = 0;
                                            mycomm2.CommandType = CommandType.StoredProcedure;

                                            mycomm2.Parameters.Add(new SqlParameter("@Ptn_pk", patientptnpk));
                                            mycomm2.Parameters.Add(new SqlParameter("@LocationID", LocationID));
                                            mycomm2.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                                            mycomm2.Parameters.Add(new SqlParameter("@ParameterID", '0'));
                                            mycomm2.Parameters.Add(new SqlParameter("@OrderedByName", OrderedbyName));
                                            mycomm2.Parameters.Add(new SqlParameter("@OrderedByDate", OrderedbyDate));
                                            mycomm2.Parameters.Add(new SqlParameter("@Flag", '2'));
                                            mycomm2.Parameters.Add(new SqlParameter("@LabID", '0'));
                                            mycomm2.Parameters.Add(new SqlParameter("@FlagExist", '0'));
                                            mycomm2.Parameters.Add(new SqlParameter("@PreClinicLabDate", precliniclabdate));
                                            mycomm2.Parameters.Add(new SqlParameter("@ReportedBy", clsGbl.loggedInUser.UserID));
                                            mycomm2.Parameters.Add(new SqlParameter("@ReportedByDate", DateofReceiving));
                                            mycomm2.Parameters.Add(new SqlParameter("@LabOrderId", laborderid));
                                            mycomm2.Parameters.Add(new SqlParameter("@TestResults", ""));
                                            mycomm2.Parameters.Add(new SqlParameter("@TestResultId", '0'));
                                            mycomm2.Parameters.Add(new SqlParameter("@DeleteFlag", 'N'));
                                            mycomm2.Parameters.Add(new SqlParameter("@SystemId", '1'));
                                            l = mycomm2.ExecuteNonQuery();

                                        }


                                    }
                                    res = Viralload.Replace(" ", "").ToLower();

                                    if (res == "<ldlcopies/ml" || res == "ldlcopies" || res == "<ldlcopies")
                                    {

                                        finalres = "UNDETECTABLE";
                                        using (SqlConnection myconn4 = new SqlConnection(iqcareconnstring))
                                        {
                                            myconn4.Open();
                                            using (SqlCommand mycommupdate = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn4))
                                            {
                                                mycommupdate.CommandTimeout = 0;
                                                mycommupdate.CommandType = CommandType.StoredProcedure;
                                                mycommupdate.Parameters.Add(new SqlParameter("@Ptn_pk", patientptnpk));
                                                mycommupdate.Parameters.Add(new SqlParameter("@LocationID", LocationID));
                                                mycommupdate.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                                                mycommupdate.Parameters.Add(new SqlParameter("@ParameterID", parameteridlab));
                                                mycommupdate.Parameters.Add(new SqlParameter("@OrderedByName", OrderedbyName));
                                                mycommupdate.Parameters.Add(new SqlParameter("@OrderedByDate", Convert.ToDateTime(OrderedbyDate)));
                                                mycommupdate.Parameters.Add(new SqlParameter("@Flag", '3'));
                                                mycommupdate.Parameters.Add(new SqlParameter("@LabID", '0'));
                                                mycommupdate.Parameters.Add(new SqlParameter("@FlagExist", '0'));
                                                mycommupdate.Parameters.Add(new SqlParameter("@ReportedBy", clsGbl.loggedInUser.UserID));
                                                mycommupdate.Parameters.Add(new SqlParameter("@ReportedByDate", DateofReceiving));
                                                mycommupdate.Parameters.Add(new SqlParameter("@LabOrderId", laborderid));
                                                mycommupdate.Parameters.Add(new SqlParameter("@TestResults", ""));
                                                mycommupdate.Parameters.Add(new SqlParameter("@TestResultId", "9998"));
                                                mycommupdate.Parameters.Add(new SqlParameter("@DeleteFlag", 'N'));
                                                mycommupdate.Parameters.Add(new SqlParameter("@SystemId", '0'));
                                                mycommupdate.Parameters.Add(new SqlParameter("@UrgentFlag", '0'));

                                                mycommupdate.Parameters.Add(new SqlParameter("@LabReportByDate", Convert.ToDateTime(OrderedbyDate)));
                                                mycommupdate.Parameters.Add(new SqlParameter("@LabReportByName", '0'));
                                                mycommupdate.Parameters.Add(new SqlParameter("@Confirmed", '0'));
                                                mycommupdate.Parameters.Add(new SqlParameter("@Confirmedby", '0'));


                                                j = mycommupdate.ExecuteNonQuery();
                                            }

                                        }

                                    }
                                    else
                                    {


                                        string ret = Viralload.ToLower();

                                        ret = ret.Replace("'insufficientsample,pleasecollectnewsam'", " ");

                                        ret = ret.Replace(@"""", "");

                                        res = ret.Replace("cp/mL", " ").Replace("cp/ml", " ").Replace("copies/ml", " ").Replace("/ml", "").Replace("copies", " ").Replace(" ", "").Replace("failed", "").Replace("none", "").Replace("targetnotdetected", "").Replace("collectnewsample", "").Replace("'insufficientsample,pleasecollectnewsam'", "");

                                        int num = 0;
                                        if (Int32.TryParse(res, out num) == true)
                                        {




                                            if (Convert.ToInt32(res) > 0.00)
                                            {
                                                finalres = res;
                                                using (SqlConnection myconn5 = new SqlConnection(iqcareconnstring))
                                                {
                                                    myconn5.Open();
                                                    using (SqlCommand mycommupt = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn5))
                                                    {
                                                        mycommupt.CommandTimeout = 0;
                                                        mycommupt.CommandType = CommandType.StoredProcedure;
                                                        mycommupt.Parameters.Add(new SqlParameter("@Ptn_pk", patientptnpk));
                                                        mycommupt.Parameters.Add(new SqlParameter("@LocationID", LocationID));
                                                        mycommupt.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                                                        mycommupt.Parameters.Add(new SqlParameter("@ParameterID", parameteridlab));
                                                        mycommupt.Parameters.Add(new SqlParameter("@OrderedByName", OrderedbyName));
                                                        mycommupt.Parameters.Add(new SqlParameter("@OrderedByDate", Convert.ToDateTime(OrderedbyDate)));
                                                        mycommupt.Parameters.Add(new SqlParameter("@Flag", '3'));
                                                        mycommupt.Parameters.Add(new SqlParameter("@LabID", '0'));
                                                        mycommupt.Parameters.Add(new SqlParameter("@FlagExist", '0'));
                                                        mycommupt.Parameters.Add(new SqlParameter("@ReportedBy", clsGbl.loggedInUser.UserID));
                                                        mycommupt.Parameters.Add(new SqlParameter("@ReportedByDate", DateofReceiving));
                                                        mycommupt.Parameters.Add(new SqlParameter("@LabOrderId", laborderid));
                                                        mycommupt.Parameters.Add(new SqlParameter("@TestResults", res));
                                                        mycommupt.Parameters.Add(new SqlParameter("@TestResultId", "9999"));
                                                        mycommupt.Parameters.Add(new SqlParameter("@DeleteFlag", 'N'));
                                                        mycommupt.Parameters.Add(new SqlParameter("@SystemId", '0'));
                                                        mycommupt.Parameters.Add(new SqlParameter("@UrgentFlag", '0'));

                                                        mycommupt.Parameters.Add(new SqlParameter("@LabReportByDate", Convert.ToDateTime(OrderedbyDate)));
                                                        mycommupt.Parameters.Add(new SqlParameter("@LabReportByName", '0'));
                                                        mycommupt.Parameters.Add(new SqlParameter("@Confirmed", '0'));
                                                        mycommupt.Parameters.Add(new SqlParameter("@Confirmedby", '0'));
                                                        r = mycommupt.ExecuteNonQuery();
                                                    }

                                                }
                                            }
                                            else
                                            {

                                                finalres = "UNDETECTABLE";

                                                using (SqlConnection myconn6 = new SqlConnection(iqcareconnstring))
                                                {
                                                    myconn6.Open();
                                                    using (SqlCommand mycommupdte = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn6))
                                                    {
                                                        mycommupdte.CommandTimeout = 0;
                                                        mycommupdte.CommandType = CommandType.StoredProcedure;
                                                        mycommupdte.Parameters.Add(new SqlParameter("@Ptn_pk", patientptnpk));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@LocationID", LocationID));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@ParameterID", parameteridlab));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@OrderedByName", OrderedbyName));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@OrderedByDate", Convert.ToDateTime(OrderedbyDate)));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@Flag", '3'));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@LabID", '0'));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@FlagExist", '0'));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@ReportedBy", clsGbl.loggedInUser.UserID));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@ReportedByDate", DateofReceiving));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@LabOrderId", laborderid));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@TestResults", ""));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@TestResultId", "9998"));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@DeleteFlag", 'N'));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@SystemId", '0'));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@UrgentFlag", '0'));

                                                        mycommupdte.Parameters.Add(new SqlParameter("@LabReportByDate", Convert.ToDateTime(OrderedbyDate)));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@LabReportByName", '0'));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@Confirmed", '0'));
                                                        mycommupdte.Parameters.Add(new SqlParameter("@Confirmedby", '0'));
                                                        t = mycommupdte.ExecuteNonQuery();
                                                    }

                                                }


                                            }

                                        }
                                    }

                                    for (int col = 0; col < dgvResultUpload.Columns.Count; col++)
                                    {
                                        //for (int it = 0; it < uploadresult.Columns.Count; it++)
                                        //{

                                        dlabrow[col] = dgvResultUpload.Rows[rowident].Cells[col].Value.ToString();
                                    }


                                    // }

                                    if (l > 0)
                                    {

                                        dlabrow["LabOrderId"] = laborderid;
                                        dlabrow["OrderedbyDate"] = OrderedbyDate;
                                        dlabrow["OrderedbyName"] = OrderedbyName;
                                    }
                                    if (j > 0)
                                    {
                                        dlabrow["TestResults"] = finalres;
                                    }
                                    else if (r > 0)
                                    {
                                        dlabrow["TestResults"] = finalres;
                                    }

                                    else if (t > 0)
                                    {
                                        dlabrow["TestResults"] = finalres;
                                    }

                                    else
                                    {

                                        dlabrow["TestResults"] = "NULL";
                                    }
                                    uploadresult.Rows.Add(dlabrow);


                                }





                            }
                            else
                            {
                                DataRow dlabnocollection = uploadresult.NewRow();
                                for (int col = 0; col < dgvResultUpload.Columns.Count; col++)
                                {
                                    //for (int it = 0; it < uploadresult.Columns.Count; it++)
                                    //{

                                    dlabnocollection[col] = dgvResultUpload.Rows[rowident].Cells[col].Value.ToString();
                                }
                                uploadresult.Rows.Add(dlabnocollection);

                            }

                        }






                    }

                    int value2 = (normalcount * 100) / totalcount;

                    // Task childtask=new Task(() => ReportProgress(value2));
                    //childtask.Start();
                    //if(childtask.IsCompleted ==true)
                    //{
                    //  childtask.Dispose();
                    //}

                    //  childtask.Dispose();
                    // Task.Factory.StartNew(() => ReportProgress(value2));

                    //ReportProgress(value2);
                    Thread Reportthread2 = new Thread(() => ReportProgress(value2));
                    Reportthread2.SetApartmentState(ApartmentState.STA);
                    Reportthread2.Start();
                    //Reportthread2.Abort();






                }



                DataRow duploadcsv;
                string value;



                if (uploadresult.Rows.Count > 0)
                {

                    StreamWriter swOut = new StreamWriter(new FileStream(uploadfilename, FileMode.Create), Encoding.UTF8);

                    for (int i = 0; i <= uploadresult.Columns.Count - 1; i++)
                    {
                        if (i > 0)
                        {
                            swOut.Write(",");
                        }
                        swOut.Write(uploadresult.Columns[i].ColumnName);
                    }
                    swOut.WriteLine();
                    for (int j = 0; j <= uploadresult.Rows.Count - 1; j++)
                    {
                        if (j > 0)
                        {
                            swOut.WriteLine();
                        }

                        duploadcsv = uploadresult.Rows[j];

                        for (int i = 0; i <= uploadresult.Columns.Count - 1; i++)
                        {
                            if (i > 0)
                            {
                                swOut.Write(",");
                            }

                            value = duploadcsv[i].ToString();
                            //replace comma's with spaces
                            value = value.Replace(',', ' ');
                            value = value.Replace(@"""", "");
                            //replace embedded newlines with spaces
                            value = value.Replace(Environment.NewLine, " ");

                            swOut.Write(value);
                        }
                    }
                    swOut.Close();
                }

                //UpdateProgress(70);
                //bgProgress.ReportProgress(70);
                // this.bgProgress.ReportProgress(100);

                // ReportProgress(100);

                //Task Childtask2 = new Task(() => ReportProgress(100));
                //Childtask2.Start();
                //if(Childtask2.IsCompleted==true)
                //{
                //  Childtask2.Dispose();

                //}
                //Childtask2.Dispose();
                //  Task.Factory.StartNew(() => ReportProgress(100));
                Thread Reportthread = new Thread(() => ReportProgress(100));
                //Thread Reportthread = new Thread(new ThreadStart(delegate () { ReportProgress(100); }));
                Reportthread.SetApartmentState(ApartmentState.STA);
                Reportthread.Start();



                // ReportProgress(100);

                SetControlPropertyThreadSafe(btnImport, "Enabled", true);
                SetControlPropertyThreadSafe(dgvResultUpload, "Enabled", true);

                SetControlPropertyThreadSafe(btnUpdate, "Enabled", true);
                SetControlPropertyThreadSafe(picUploadNotify, "Image", null);
                SetControlPropertyThreadSafe(lblUploadNotify, "Text", "Completed generating Csv file and saved at the location:" + uploadfilename);

                // Reportthread.Abort();
                //bgProgress.ReportProgress(100);
                //UpdateProgress(100);


            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

                //pgbUpdateIQCare.Invoke((Action)delegate { ReportProgress(0); });
                //Task Childtask3 = new Task(() => ReportProgress(0));
                //Childtask3.Start();

                //if(Childtask3.IsCompleted==true)
                // {
                //   Childtask3.Dispose();
                //}
                //  Task.Factory.ContinueWhenAny(() => ReportProgress(0));
                Thread Reportthread3 = new Thread(() => ReportProgress(0));
                Reportthread3.SetApartmentState(ApartmentState.STA);
                Reportthread3.Start();

                SetControlPropertyThreadSafe(btnImport, "Enabled", true);
                SetControlPropertyThreadSafe(dgvResultUpload, "Enabled", true);
                SetControlPropertyThreadSafe(pgbUpdateIQCare, "Visible", false);
                SetControlPropertyThreadSafe(btnUpdate, "Enabled", true);
                SetControlPropertyThreadSafe(lblUploadNotify, "Text", "");
                SetControlPropertyThreadSafe(lblUploadNotify, "Text", "");
                SetControlPropertyThreadSafe(picUploadNotify, "Image", null);
                //Reportthread3.Abort();


            }


        }


        private void ReportProgress(int p)
        {
            if (pgbUpdateIQCare.InvokeRequired)
            { pgbUpdateIQCare.Invoke(new MethodInvoker(delegate { pgbUpdateIQCare.Value = p; })); }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //bgProgress.WorkerReportsProgress = true;


            //if (bgProgress.IsBusy)
                //return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV|*.csv" })
            {
                DialogResult dialogResult = sfd.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    uploadfilename = sfd.FileName;
                    pgbUpdateIQCare.Visible = true;
                    pgbUpdateIQCare.Minimum = 0;
                    pgbUpdateIQCare.Value = 0;
                    

                    Thread UpdateThread = new Thread(() => UpdateData());
                    UpdateThread.SetApartmentState(ApartmentState.STA);
                    UpdateThread.Start();
                  
                }
                if (dialogResult == DialogResult.Cancel)
                {
                    SetControlPropertyThreadSafe(picUploadNotify, "Image", null);
                    SetControlPropertyThreadSafe(lblUploadNotify, "Text", "The operation has been cancelled");

                }


            }



        }

        

        private void txtSearchbyName_TextChanged(object sender, EventArgs e)
        {




            if (dgvResults.DataSource != null)
            {
               

                

                if (rdbName.Checked == true)
                {
                    if (txtSearchbyName.Text.Length > 0)
                    {


                        //store.Clear();
                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {

                            if (row.Cells["checkBoxColumn"].Value != null)
                            {
                                string selected = row.Cells["checkBoxColumn"].Value.ToString();
                                bool IsSelected;
                                if (!String.IsNullOrEmpty(selected))
                                {
                                    IsSelected = Convert.ToBoolean(selected);

                                    //  bool IsSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value.ToString());
                                    if (IsSelected)
                                    {
                                        if (!store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                                            store.Add(row.Cells["LabId"].Value.ToString(), bool.Parse(row.Cells["checkBoxColumn"].Value.ToString()));
                                        else
                                            store[row.Cells["LabId"].Value.ToString()] = bool.Parse(row.Cells["checkBoxColumn"].Value.ToString());

                                    }
                                }
                            }

                        }

                        (dgvResults.DataSource as DataTable).DefaultView.RowFilter = "FullName LIKE '%" + txtSearchbyName.Text + "%'";

                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {


                            if (row != null)
                            {

                                if (row.Cells["LabId"].Value != null)
                                {

                                    if (store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                                    {
                                        row.Cells["checkBoxColumn"].Value = true;
                                    }
                                }
                            }

                        }


                    }

                    else
                    {
                        (dgvResults.DataSource as DataTable).DefaultView.RowFilter = "";
                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {


                            if (row != null)
                            {

                                if (row.Cells["LabId"].Value != null)
                                {

                                    if (store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                                    {
                                        row.Cells["checkBoxColumn"].Value = true;
                                    }
                                }
                            }

                        }
                    }




                }






                else if (rdbClientIpNo.Checked == true)
                {



                    if (txtSearchbyName.Text.Length > 0)
                    {

                       // store.Clear();
                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {

                            if (row.Cells["checkBoxColumn"].Value != null)
                            {
                                string selected = row.Cells["checkBoxColumn"].Value.ToString();
                                bool IsSelected;
                                if (!String.IsNullOrEmpty(selected))
                                {
                                    IsSelected = Convert.ToBoolean(selected);

                                    //  bool IsSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value.ToString());
                                    if (IsSelected)
                                    {

                                        if (!store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                                            store.Add(row.Cells["LabId"].Value.ToString(), bool.Parse(row.Cells["checkBoxColumn"].Value.ToString()));
                                        else
                                            store[row.Cells["LabId"].Value.ToString()] = bool.Parse(row.Cells["checkBoxColumn"].Value.ToString());
                                    }
                                }
                            }

                        }


                        (dgvResults.DataSource as DataTable).DefaultView.RowFilter = "ClientIpNo LIKE '%" + txtSearchbyName.Text + "%'";

                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {


                            if (row != null)
                            {

                                if (row.Cells["LabId"].Value != null)
                                {

                                    if (store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                                    {
                                        row.Cells["checkBoxColumn"].Value = true;
                                    }
                                }
                            }

                        }



                    }


                    else
                    {
                    
                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {

                            if (row.Cells["checkBoxColumn"].Value != null)
                            {
                                string selected = row.Cells["checkBoxColumn"].Value.ToString();
                                bool IsSelected;
                                if (!String.IsNullOrEmpty(selected))
                                {
                                    IsSelected = Convert.ToBoolean(selected);

                                    //  bool IsSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value.ToString());
                                    if (IsSelected)
                                    {

                                        if (!store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                                            store.Add(row.Cells["LabId"].Value.ToString(), bool.Parse(row.Cells["checkBoxColumn"].Value.ToString()));
                                        else
                                            store[row.Cells["LabId"].Value.ToString()] = bool.Parse(row.Cells["checkBoxColumn"].Value.ToString());

                                    }
                                }
                            }

                        }



                        (dgvResults.DataSource as DataTable).DefaultView.RowFilter = "";
                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {


                            if (row != null)
                            {

                                if (row.Cells["LabId"].Value != null)
                                {

                                    if (store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                                    {
                                        row.Cells["checkBoxColumn"].Value = true;
                                    }
                                }
                            }

                        }
                    }



                }
                //else
                //{
                //    (dgvResults.DataSource as DataTable).DefaultView.RowFilter = "";
                //    foreach (DataGridViewRow row in dgvResults.Rows)
                //    {


                //        if (row != null)
                //        {

                //            if (row.Cells["LabId"].Value != null)
                //            {

                //                if (store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                //                {
                //                    row.Cells["checkBoxColumn"].Value = true;
                //                }
                //            }
                //        }

                //    }



                //}

                //foreach (DataGridViewRow row in dgvResults.Rows)
                //{


                //    if (row != null)
                //    {

                //        if (row.Cells["LabId"].Value != null)
                //        {

                //            if (store.ContainsKey(row.Cells["LabId"].Value.ToString()))
                //            {
                //                row.Cells["checkBoxColumn"].Value = true;
                //            }
                //        }
                //    }

                //}

            }
            //store.Clear();
           
        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splContainerView_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splContainerView_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }

        //private void dgvResults_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        //{

        //}

        //private void dgvResults_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        //{

        //    //store.Add(this.dgvResults[0, e.RowIndex].Value.ToString(), bool.Parse(e.Value.ToString()));
        //}
    }









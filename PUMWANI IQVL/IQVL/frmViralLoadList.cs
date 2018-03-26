using IQVL.BusinessLayer;
using IQVL.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IQVL
{
    public partial class frmViralLoadList : Form
    {
        string serverType = string.Empty;
        string emrType = string.Empty;
        public static string iqcareconnectionstring = Entity.GetConnString();
        
        public frmViralLoadList()
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

        public void GenerateVLlist()
        {
            try { 
            SetControlPropertyThreadSafe(pnlContent, "Visible", true);
            SetControlPropertyThreadSafe(pnlNavigation, "Visible", true);
            SetControlPropertyThreadSafe(pnlSearch, "Visible", true);
            SetControlPropertyThreadSafe(lblNotify, "Text", "Loading Data....");
            SetControlPropertyThreadSafe(picNotify, "Image", Properties.Resources.progressWheel5);
            SetControlPropertyThreadSafe(btnAddToList, "Enabled", false);
            SetControlPropertyThreadSafe(btnCreateLab, "Enabled", false);

            SetControlPropertyThreadSafe(dgvResult, "DataSource", null);
            SetControlPropertyThreadSafe(lblViralwithoutresults, "Enabled", false);


            

                if (clsGbl.dr != null)
                {
                    if (clsGbl.dr.Rows.Count > 0)
                    {

                        DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                        checkboxColumn.HeaderText = "";
                        checkboxColumn.Width = 30;
                        checkboxColumn.Name = "checkBoxColumn";

                        SetControlPropertyThreadSafe(dgvResult, "DataSource", clsGbl.dr);
                        // dgvResults.DataSource = dr;
                        dgvResult.Invoke((MethodInvoker)(() => dgvResult.Columns.Insert(0, checkboxColumn)));


                    }
                }

                else
                {

                    Entity en = new Entity();
                    string connstring = Entity.GetConnString();
                    string servertype = Entity.GetServerType();
                    string pid = clsGbl.PatientID;
                    string query = ViralLoadQuery.VlList.ToString();
                    query = query.Replace("@ptn_pk", pid);



                    clsGbl.dr = (DataTable)en.ReturnObject(connstring, ClsUtility.theParams, query, ClsUtility.ObjectEnum.DataTable, serverType);
                    DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                    checkboxColumn.HeaderText = "";
                    checkboxColumn.Width = 30;
                    checkboxColumn.Name = "checkBoxColumn";

                    SetControlPropertyThreadSafe(dgvResult, "DataSource", clsGbl.dr);
                    // dgvResults.DataSource = dr;
                    dgvResult.Invoke((MethodInvoker)(() => dgvResult.Columns.Insert(0, checkboxColumn)));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());


            }
            finally
            {
                SetControlPropertyThreadSafe(pnlContent, "Visible", true);
                SetControlPropertyThreadSafe(pnlNavigation, "Visible", true);
                SetControlPropertyThreadSafe(pnlSearch, "Visible", true);
                SetControlPropertyThreadSafe(lblNotify, "Text", dgvResult.Rows.Count-1 + "Records without Results");
               
                SetControlPropertyThreadSafe(btnAddToList, "Enabled", true);
                SetControlPropertyThreadSafe(btnCreateLab, "Enabled", true);
                SetControlPropertyThreadSafe(picNotify, "Image", null);
                SetControlPropertyThreadSafe(lblViralwithoutresults, "Enabled", true);

            }

        }

        private void frmViralLoadList_Load(object sender, EventArgs e)
        {
            try
            {
                clsGbl.frmViralloadlist = this;
                SetControlPropertyThreadSafe(pnlContent, "Visible", false);
                SetControlPropertyThreadSafe(pnlNavigation, "Visible", false);
                SetControlPropertyThreadSafe(pnlSearch, "Visible", false);
                if (!String.IsNullOrEmpty(clsGbl.PatientID))
                {

                    Thread runQueryThread = new Thread(() => GenerateVLlist());
                    runQueryThread.SetApartmentState(ApartmentState.STA);
                    runQueryThread.Start();

                }
                else
                {
                    SetControlPropertyThreadSafe(pnlContent, "Visible", true);
                    SetControlPropertyThreadSafe(pnlNavigation, "Visible", true);
                    SetControlPropertyThreadSafe(pnlSearch, "Visible", true);
                    SetControlPropertyThreadSafe(dgvResult, "DataSource", null);
                    SetControlPropertyThreadSafe(lblNotify, "Text", " 0 Records without Results");
                    SetControlPropertyThreadSafe(picNotify, "Image", null);
                    SetControlPropertyThreadSafe(lblViralwithoutresults, "Enabled", true);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                SetControlPropertyThreadSafe(pnlContent, "Visible", true);
                SetControlPropertyThreadSafe(pnlNavigation, "Visible", true);
                SetControlPropertyThreadSafe(pnlSearch, "Visible", true);
                SetControlPropertyThreadSafe(picNotify, "Image", null);
                SetControlPropertyThreadSafe(lblViralwithoutresults, "Enabled", true);
                this.Show();
            }
               
        }

        public DataTable GetSelectedList()
        {
            try
            {
                int jt;
                DataTable Result = new DataTable();
                if (dgvResult.ColumnCount == 0)
                {
                    return null;
                }
                for (jt = 1; jt <= dgvResult.Columns.Count - 1; jt++)
                {
                    Result.Columns.Add(dgvResult.Columns[jt].HeaderText);
                }


                for (int i = 0; i < dgvResult.RowCount - 1; i++)
                {

                    if (Convert.ToBoolean(dgvResult.Rows[i].Cells["checkBoxColumn"].Value))
                    {
                        DataRow row = Result.NewRow();
                        for (int j = 0; j <= Result.Columns.Count - 1; j++)
                        {

                            row[j] = dgvResult.Rows[i].Cells[j + 1].Value;

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
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                SetControlPropertyThreadSafe(btnAddToList, "Enabled", false);
                SetControlPropertyThreadSafe(btnCreateLab, "Enabled", false);
                SetControlPropertyThreadSafe(dgvResult, "Enabled", false);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Adding data to the list from main form....");
                SetControlPropertyThreadSafe(picNotify, "Image", Properties.Resources.progressWheel5);
                clsGbl.AddList = (DataTable)GetSelectedList();
                if (clsGbl.AddList != null && clsGbl.AddList.Rows.Count > 0)
                {   
                    clsGbl.firstload = false;
                    SetControlPropertyThreadSafe(lblNotify, "Text", "Completed adding data to the list");
                    Form frmMain = new frmMain();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    SetControlPropertyThreadSafe(lblNotify, "Text", "Select item from list");
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;

            }
            finally
            {
                SetControlPropertyThreadSafe(btnAddToList, "Enabled", true);
                SetControlPropertyThreadSafe(btnCreateLab, "Enabled", true);
                SetControlPropertyThreadSafe(dgvResult, "Enabled", true);
                
                SetControlPropertyThreadSafe(picNotify, "Image",null);
            }

           

        }

        private void btnCreateLab_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddLabOrder();
            frm.Show();
            this.Hide();
        }

        private void frmViralLoadList_FormClosed(object sender, FormClosedEventArgs e)
        {
          Form   frm =  new  frmSearchPatient();
            frm.Show();
            this.Hide();
            clsGbl.dr = null;
        }
    }
}

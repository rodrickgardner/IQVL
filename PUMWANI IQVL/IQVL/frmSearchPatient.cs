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
using IQVL.BusinessLayer;
using System.Data.SqlClient;

namespace IQVL
{
    public partial class frmSearchPatient : Form
    {
        string serverType = string.Empty;
        string emrType = string.Empty;
        public static string iqcareconnectionstring = Entity.GetConnString();
       
         
        public frmSearchPatient()
        {
            InitializeComponent();
        }

        private void frmSearchPatient_Load(object sender, EventArgs e)
        {
            try
            {
                SetControlPropertyThreadSafe(pnlContent, "Visible", false);
                SetControlPropertyThreadSafe(btnGenerateVLLab, "Enabled", false);

                activateSatelliteCombo();
                dtpDOB.Value = dtpDOB.MinDate;
                dtpRegDate.Value = dtpRegDate.MinDate;
                lblNotify.Text = "";
                picNotify.Image = null;
                dgvResults.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

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
        private void activateSatelliteCombo()
        {
            serverType = Entity.GetServerType();
            emrType = Entity.GetEMRType();
            if (emrType == "iqcare")
            {
                lblFacility.Visible = true;
                cboFacility.Visible = true;
                string sql = "Select FacilityName, FacilityID FROM mst_Facility WHERE DeleteFlag = 0";
                Entity en = new Entity();


                string emrConnString = iqcareconnectionstring.ToString();
                DataTable dt = (DataTable)en.ReturnObject(emrConnString, ClsUtility.theParams
                    , sql, ClsUtility.ObjectEnum.DataTable, serverType);
                DataTableReader dtr = dt.CreateDataReader();
                cboFacility.Items.Clear();
                cboFacility.DataSource = dt;
                cboFacility.DisplayMember = "FacilityName";
                cboFacility.ValueMember = "FacilityID";
                // while (dtr.Read())
                //{

                //  cboFacility.Items.Add(dtr[0].ToString());
                //}


            }
        }



      
        private void GetPatientSearchList(string firstname , string lastname, string middlename, string identificationno , DateTime? dob = null, DateTime? regdate = null,int? facilityid=null
            )
        {

            try {

                SetControlPropertyThreadSafe(txtFirstName, "Enabled", false);
                SetControlPropertyThreadSafe(txtLastName, "Enabled", false);
                SetControlPropertyThreadSafe(txtMiddleName, "Enabled", false);
                SetControlPropertyThreadSafe(dtpDOB, "Enabled", false);
                SetControlPropertyThreadSafe(dtpRegDate, "Enabled", false);
                SetControlPropertyThreadSafe(txtIdentificationNo, "Enabled", false);
                SetControlPropertyThreadSafe(dgvResults, "DataSource", null);

               DataTable dt = new DataTable();
                Entity en = new Entity();
                SqlConnection myconn = new SqlConnection();
                myconn.ConnectionString = iqcareconnectionstring;
                myconn.Open();
                SqlCommand mycomm = new SqlCommand("dbo.Pr_Clinical_GetPatientSearchresults", myconn);
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.Parameters.Add(new SqlParameter("@FirstName", firstname));
                mycomm.Parameters.Add(new SqlParameter("@LastName", lastname));
                mycomm.Parameters.Add(new SqlParameter("@MiddleName", middlename));
                mycomm.Parameters.Add(new SqlParameter("@enrollmentid", identificationno));
                mycomm.Parameters.Add(new SqlParameter("@enrollmentType", 9999));
                mycomm.Parameters.Add(new SqlParameter("@ModuleId", 999));
                mycomm.Parameters.Add(new SqlParameter("@password", clsGbl.DBSecurity));
                if (!dob.Equals(null))
                {
                    mycomm.Parameters.Add(new SqlParameter("@DOB", Convert.ToDateTime(dob.ToString())));
                }

                if(!regdate.Equals(null))
                {
                    mycomm.Parameters.Add(new SqlParameter("@RegistrationDate",Convert.ToDateTime(regdate.ToString())));
                }

                using (var da = new SqlDataAdapter(mycomm))
                {
                    da.Fill(dt);
                  }

               
                DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
                checkboxColumn.HeaderText = "";
                checkboxColumn.Width = 30;
                checkboxColumn.Name = "checkBoxColumn";


                SetControlPropertyThreadSafe(dgvResults, "DataSource", dt);
                // dgvResults.DataSource = dr;
                dgvResults.Invoke((MethodInvoker)(() => dgvResults.Columns.Insert(0, checkboxColumn)));
                /*ClsUtility.Init_Hashtable();


                ClsUtility.AddParameters("@FirstName", SqlDbType.VarChar, firstname);
                ClsUtility.AddParameters("@LastName", SqlDbType.VarChar, lastname);
                ClsUtility.AddParameters("@MiddleName", SqlDbType.VarChar, middlename);
                ClsUtility.AddParameters("@FacilityID", SqlDbType.VarChar, Convert.ToString(facilityid));
                ClsUtility.AddParameters("@enrollmentid", SqlDbType.VarChar, identificationno);
                ClsUtility.AddParameters("@enrollmentType", SqlDbType.Int, 9999);
                ClsUtility.AddParameters("@ModuleID", SqlDbType.Int, 999);
                ClsUtility.AddParameters("@password", SqlDbType.VarChar,clsGbl.DBSecurity);
                if (!dob.Equals(null) )
                {
                    ClsUtility.AddParameters("@DOB", SqlDbType.DateTime, dob.Value.ToString("dd - MM - yyyy"));
                }
                if (!regdate.Equals(null))
                { 
                    ClsUtility.AddParameters("@RegistrationDate", SqlDbType.DateTime, regdate.Value.ToString("dd - MM - yyyy"));
                }

                DataTable dr = (DataTable)en.ReturnObject(iqcareconnectionstring, ClsUtility.theParams, "Pr_Clinical_GetPatientSearchresults", ClsUtility.ObjectEnum.DataTable, "mssql");*/




            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            finally
            {

                SetControlPropertyThreadSafe(picNotify, "Image", null);
                SetControlPropertyThreadSafe(lblNotify, "Text", dgvResults.RowCount.ToString() + "Records found");
                SetControlPropertyThreadSafe(btnGenerateVLLab, "Enabled", true);
                SetControlPropertyThreadSafe(txtFirstName, "Enabled", true);
                SetControlPropertyThreadSafe(txtLastName, "Enabled", true);
                SetControlPropertyThreadSafe(txtMiddleName, "Enabled", true);
                SetControlPropertyThreadSafe(dtpDOB, "Enabled", true);
                SetControlPropertyThreadSafe(dtpRegDate, "Enabled", true);
                SetControlPropertyThreadSafe(txtIdentificationNo, "Enabled", true);
                SetControlPropertyThreadSafe(pnlContent, "Visible", true);
                SetControlPropertyThreadSafe(dgvResults, "Visible", true);
                SetControlPropertyThreadSafe(txtFirstName, "Text", "");
                SetControlPropertyThreadSafe(txtLastName, "Text", "");
                SetControlPropertyThreadSafe(txtMiddleName, "Text", "");
                SetControlPropertyThreadSafe(dtpDOB, "Value", dtpDOB.MinDate);
                SetControlPropertyThreadSafe(dtpRegDate, "Value", dtpRegDate.MinDate);
                SetControlPropertyThreadSafe(txtIdentificationNo, "Text", "");


            }



        }
        private void btnSearchPatient_Click(object sender, EventArgs e)
        {
            try
            {
                string firstname ;
                string lastname ;
                string middlename ;
                string identificationno ;
               DateTime?  dob = null;
                DateTime? regdate = null;
                int? facilityid ;
                dgvResults.DataSource = null;
                dgvResults.Columns.Clear();
                dgvResults.Refresh();

                SetControlPropertyThreadSafe(btnGenerateVLLab, "Enabled", false);
                SetControlPropertyThreadSafe(picNotify, "Image", Properties.Resources.progressWheel5);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Searching Patient ...");
                

                firstname = txtFirstName.Text.Trim();
                    
                
                
                    lastname = txtLastName.Text.Trim();


                
               
                    middlename = txtMiddleName.Text.Trim();

              
               
                    identificationno = txtIdentificationNo.Text.Trim();
               
                if(!String.IsNullOrWhiteSpace(dtpDOB.Text))
                {  if(dtpDOB.Value.ToString()==dtpDOB.MinDate.ToString())
                    {
                        dob = null;
                    }
                    else
                    {

                        dob = Convert.ToDateTime(dtpDOB.Value);
                    }
                  
                }
                if (!String.IsNullOrWhiteSpace(dtpRegDate.Text))
                {
                    if (dtpRegDate.Value == dtpRegDate.MinDate)
                    {
                        regdate = null;
                    }
                    else
                    {

                        regdate = Convert.ToDateTime(dtpRegDate.Value);
                    }

                }

                facilityid = Convert.ToInt32( cboFacility.SelectedValue);

                Thread runQueryThread = new Thread(() => GetPatientSearchList(firstname,lastname,middlename,identificationno,dob,regdate,facilityid));
                    runQueryThread.SetApartmentState(ApartmentState.STA);
                runQueryThread.Start();



            }
            catch
            {


            }
        }

        private void btnGenerateVLLab_Click(object sender, EventArgs e)
        {
            try
            {

                if (dgvResults.Rows.Count > 0)
                {
                    bool Selected = false;
                    
                    foreach (DataGridViewRow row in dgvResults.Rows)
                    {
                        bool isSelected = Convert.ToBoolean(row.Cells["checkboxColumn"].Value);
                        
                        if (isSelected)
                        {
                            clsGbl.PatientID = row.Cells["patientID"].Value.ToString();
                            if (String.IsNullOrWhiteSpace(clsGbl.PatientID))
                                {
                                lblNotify.Text = "The row is empty and patientID is empty";
                                Selected = false;
                                }
                            else {

                                lblNotify.Text = "One Item has been selected";
                                Selected = isSelected;
                            
                            }
                        }
                        

                    }

                    if (Selected == true)
                    {
                        Form tmp = new frmViralLoadList();
                        this.Hide();
                        tmp.ShowDialog();
                    }
                    else
                    {

                        lblNotify.Text = "Kindly select  one patient from the list to proceed or check if the record is not empty";
                        return;
                    }
                    
                }
                else
                {

                    lblNotify.Text = "There is no data in the datagrid";
                    return;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }

        private void dgvResults_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dgvResults.Rows[e.RowIndex].Cells["checkBoxColumn"].Value) == false)
                {
                    for (int i = 0; i <= dgvResults.Rows.Count - 1; i++)
                    {
                        dgvResults.Rows[i].Cells["checkBoxColumn"].Value = false;
                    }
                }
            }
        }

        private void AccessContol()
        {
            if (InvokeRequired)
            { this.Invoke(new MethodInvoker(delegate { this.Hide(); })); }
            else { this.Hide(); }
        }

        private void frmSearchPatient_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            clsGbl.frmMain.Show();
          
            this.Hide();
        }
    }
}

using IQVL.BusinessLayer;
using IQVL.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace IQVL
{
    public partial class frmAddLabOrder : Form
    {
        string serverType = string.Empty;
        string emrType = string.Empty;
        public static string iqcareconnectionstring = Entity.GetConnString();

        public frmAddLabOrder()
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
        private void frmAddLabOrder_Load(object sender, EventArgs e)
        {
            try
            {
                activateSatelliteCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void activateSatelliteCombo()
        {
            serverType = Entity.GetServerType();
            emrType = Entity.GetEMRType();
            if (emrType == "iqcare")
            {

                cboFacilityName.Visible = true;
                string sql = "Select FacilityName, FacilityID FROM mst_Facility WHERE DeleteFlag = 0";
                Entity en = new Entity();


                string emrConnString = iqcareconnectionstring.ToString();
                DataTable dt = (DataTable)en.ReturnObject(emrConnString, ClsUtility.theParams
                    , sql, ClsUtility.ObjectEnum.DataTable, serverType);
                DataTableReader dtr = dt.CreateDataReader();
                cboFacilityName.Items.Clear();
                cboFacilityName.DataSource = dt;
                cboFacilityName.DisplayMember = "FacilityName";
                cboFacilityName.ValueMember = "FacilityID";


               

                string sqlquery = "select usr.UserID,LTRIM(RTRIM(usr.UserLastName + '  ' + usr.UserFirstName + ' ' + '-' + ' ' + md.Name)) as EmployeeName,usr.Designation,md.Name from mst_User usr inner join mst_Designation md on md.Id = usr.Designation " +
                    " where usr.DeleteFlag = 0";
              
                DataTable userdt = (DataTable)en.ReturnObject(emrConnString, ClsUtility.theParams
                    , sqlquery, ClsUtility.ObjectEnum.DataTable, serverType);
                cboOrderedbyName.Items.Clear();
                cboOrderedbyName.DataSource = userdt;
                cboOrderedbyName.DisplayMember = "EmployeeName";
                cboOrderedbyName.ValueMember = "UserID";

                cboOrderedbyName.Visible = true;
                //string sql="Select UserName,UserID from mst_User where De  "
                // while (dtr.Read())
                //{

                //  cboFacility.Items.Add(dtr[0].ToString());
                //}


            }
        }

        private void btnCreateLab_Click(object sender, EventArgs e)
        {
            try
            {

                Entity en = new Entity();
                serverType = Entity.GetServerType();
                emrType = Entity.GetEMRType();

                SetControlPropertyThreadSafe(dtpLabDoneOn, "Enabled", false);
                SetControlPropertyThreadSafe(dtpOrderedbyDate, "Enabled", false);

                SetControlPropertyThreadSafe(btnCreateLab, "Enabled", false);
                SetControlPropertyThreadSafe(cboFacilityName, "Enabled", false);
                SetControlPropertyThreadSafe(cboOrderedbyName, "Enabled", false);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Adding viralload ordered in iqcare.....");
                SetControlPropertyThreadSafe(picNotify, "Image", Properties.Resources.progressWheel5);
                int Orderedbyid;
                DataTable reslaborderid = new DataTable();
                DateTime labdoneon = Convert.ToDateTime(dtpLabDoneOn.Value);
                DateTime orderedbydate = Convert.ToDateTime(dtpOrderedbyDate.Value);
                int patientid = Convert.ToInt32(clsGbl.PatientID);
                int FacilityID = Convert.ToInt32(cboFacilityName.SelectedValue.ToString());
                if (cboOrderedbyName.SelectedItem == null)
                {
                    MessageBox.Show("Kindly select the person who ordered the item");
                    cboOrderedbyName.Focus();
                    SetControlPropertyThreadSafe(dtpLabDoneOn, "Enabled", true);
                    SetControlPropertyThreadSafe(dtpOrderedbyDate, "Enabled", true);
                    SetControlPropertyThreadSafe(btnCreateLab, "Enabled", true);
                    SetControlPropertyThreadSafe(cboFacilityName, "Enabled", true);
                    SetControlPropertyThreadSafe(cboOrderedbyName, "Enabled", true);
                    SetControlPropertyThreadSafe(lblNotify, "Text", "Added viralload ordered in iqcare.");
                    SetControlPropertyThreadSafe(picNotify, "Image", null);
                    return;
                }
                else
                {
                    Orderedbyid = Convert.ToInt32(cboOrderedbyName.SelectedValue.ToString());
                }

                string emrConnString = iqcareconnectionstring.ToString();
                string labidqry = "select LabTestID from[dbo].[mst_LabTest] where LabName like '%Viral%'";
                DataTable dt = (DataTable)en.ReturnObject(emrConnString, ClsUtility.theParams
                    , labidqry, ClsUtility.ObjectEnum.DataTable, serverType);
                string labid = dt.Rows[0].ItemArray[0].ToString();
                string parameterquery = "select SubTestID from[dbo].lnk_TestParameter where SubTestName like 'Viral Load%'";
                DataTable dr = (DataTable)en.ReturnObject(emrConnString, ClsUtility.theParams
                , parameterquery, ClsUtility.ObjectEnum.DataTable, serverType);
                string parameterid = dr.Rows[0].ItemArray[0].ToString();

                SqlConnection myconn = new SqlConnection();
                myconn.ConnectionString = iqcareconnectionstring;
                myconn.Open();
                SqlCommand mycomm = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn);
                mycomm.CommandType = CommandType.StoredProcedure;
                mycomm.Parameters.Add(new SqlParameter("@Ptn_pk", patientid));
                mycomm.Parameters.Add(new SqlParameter("@LocationID", FacilityID));
                mycomm.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                mycomm.Parameters.Add(new SqlParameter("@ParameterID", '0'));
                mycomm.Parameters.Add(new SqlParameter("@OrderedByName", Orderedbyid));
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


                using (var da = new SqlDataAdapter(mycomm))
                {
                    da.Fill(reslaborderid);
                }

                string laborderid = reslaborderid.Rows[0].ItemArray[0].ToString();





                /* SqlConnection myconnnext = new SqlConnection();
                 myconnnext.ConnectionString = iqcareconnectionstring;
                 myconnnext.Open();*/


                SqlCommand mycommUpdate = new SqlCommand("Pr_IQTouch_Laboratory_AddLabOrderTests", myconn);
                mycommUpdate.CommandType = CommandType.StoredProcedure;
                mycommUpdate.Parameters.Add(new SqlParameter("@Ptn_pk", patientid));
                mycommUpdate.Parameters.Add(new SqlParameter("@LocationID", FacilityID));
                mycommUpdate.Parameters.Add(new SqlParameter("@UserId", clsGbl.loggedInUser.UserID));
                mycommUpdate.Parameters.Add(new SqlParameter("@ParameterID", parameterid));
                mycommUpdate.Parameters.Add(new SqlParameter("@OrderedByName", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@OrderedByDate", orderedbydate));
                mycommUpdate.Parameters.Add(new SqlParameter("@Flag", '1'));
                mycommUpdate.Parameters.Add(new SqlParameter("@LabID", labid));
                mycommUpdate.Parameters.Add(new SqlParameter("@FlagExist", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@PreClinicLabDate", orderedbydate));
                mycommUpdate.Parameters.Add(new SqlParameter("@ReportedBy", clsGbl.loggedInUser.UserID));
                mycommUpdate.Parameters.Add(new SqlParameter("@LabOrderId", laborderid));
                mycommUpdate.Parameters.Add(new SqlParameter("@TestResults", ""));
                mycommUpdate.Parameters.Add(new SqlParameter("@TestResultId", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@DeleteFlag", 'N'));
                mycommUpdate.Parameters.Add(new SqlParameter("@SystemId", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@UrgentFlag", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@Justification", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@LabReportByDate", labdoneon));
                mycommUpdate.Parameters.Add(new SqlParameter("@LabReportByName", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@Confirmed", '0'));
                mycommUpdate.Parameters.Add(new SqlParameter("@Confirmedby", '0'));

                DataTable res = new DataTable();
                using (var da = new SqlDataAdapter(mycommUpdate))
                {
                    da.Fill(res);
                }
                string laborderedid = res.Rows[0].ItemArray[0].ToString();
                if (!string.IsNullOrEmpty(laborderedid))

                {
                    Entity ent = new Entity();
                    string connstring = Entity.GetConnString();
                    string servertype = Entity.GetServerType();

                    string query = ViralLoadQuery.VlLabList.ToString();

                    query = query.Replace("@LabOrderId", laborderedid);
                    DataTable daddlab = (DataTable)ent.ReturnObject(connstring, ClsUtility.theParams, query, ClsUtility.ObjectEnum.DataTable, serverType);

                    if (daddlab != null)
                    {
                        if (daddlab.Rows.Count > 0)
                        {
                            foreach (DataRow row in daddlab.Rows)
                            {
                                clsGbl.dr.Rows.Add(row.ItemArray);

                            }


                        }


                    }





                }


                SetControlPropertyThreadSafe(dtpLabDoneOn, "Enabled", true);
                SetControlPropertyThreadSafe(dtpOrderedbyDate, "Enabled", true);
                SetControlPropertyThreadSafe(btnCreateLab, "Enabled", true);
                SetControlPropertyThreadSafe(cboFacilityName, "Enabled", true);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Added viralload ordered in iqcare.");
                SetControlPropertyThreadSafe(picNotify, "Image", null);
                SetControlPropertyThreadSafe(cboOrderedbyName, "Enabled", true);

                clsGbl.frmViralloadlist.Show();
                this.Hide();
            




            }

            catch (Exception ex){
                MessageBox.Show(ex.Message.ToString());
                SetControlPropertyThreadSafe(dtpLabDoneOn, "Enabled", true);
                SetControlPropertyThreadSafe(dtpOrderedbyDate, "Enabled", true);
                SetControlPropertyThreadSafe(btnCreateLab, "Enabled", true);
                SetControlPropertyThreadSafe(cboFacilityName, "Enabled", true);
                SetControlPropertyThreadSafe(lblNotify, "Text", "Error creating the lab form.");
                SetControlPropertyThreadSafe(picNotify, "Image", null);
                SetControlPropertyThreadSafe(cboOrderedbyName, "Enabled", true);
            }
            finally
            {

            }
            
        }

        private void frmAddLabOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            clsGbl.frmViralloadlist.Show();
            this.Hide();

        }
    }
}

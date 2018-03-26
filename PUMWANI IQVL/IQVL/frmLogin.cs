using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IQVL.DataLayer;
using System.Data.SqlClient;
using IQVL.BusinessLayer;
using System.Security.Principal;

namespace IQVL
{
    public partial class frmLogin : Form

    {
        string serverType = string.Empty;
        string emrType = string.Empty;
        public static string iqcareconnectionstring = null;
            
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

        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

            InitializeForm();
        }

        public static bool ValidateSettings()
        {
            try
            {

                SqlConnection con = new SqlConnection(iqcareconnectionstring + ";Connection Timeout=5");
                con.Open();
                con.Close();

                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Unknown database"))
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }



        }
        public void InitializeForm()
        {
            try
            {
                serverType = Entity.GetServerType();
                emrType = Entity.GetEMRType();
                iqcareconnectionstring = Entity.GetConnString();
                if (iqcareconnectionstring != string.Empty)
                {

                    if (ValidateSettings() == false)
                    {
                        clsGbl.SettingsValid = false;

                        lblLoad.Text = "Invalid Settings";
                        picLoad.Image = Properties.Resources.wrong;



                    }
                    else
                    {
                        clsGbl.SettingsValid = true;

                        iqcareconnectionstring = Entity.GetConnString();
                        lblLoad.Text = "Ready";
                        picLoad.Image = Properties.Resources.right;
                        activateSatelliteCombo();


                    }




                }
            }
            catch (Exception ex){

                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void activateSatelliteCombo()
        {
            if (emrType == "iqcare")
            {
                SetControlPropertyThreadSafe(lblFacility, "Visible", true);
                SetControlPropertyThreadSafe(cboFacility, "Visible", true);
                
                string sql = "Select FacilityName, FacilityID FROM mst_Facility WHERE DeleteFlag = 0";
                Entity en = new Entity();


                string emrConnString = iqcareconnectionstring.ToString();
                DataTable dt = (DataTable)en.ReturnObject(emrConnString, ClsUtility.theParams
                    , sql, ClsUtility.ObjectEnum.DataTable, serverType);
                DataTableReader dtr = dt.CreateDataReader();
                // cboFacility.Items.Clear();
                cboFacility.Invoke((MethodInvoker)(() => cboFacility.Items.Clear()));
                //SetControlPropertyThreadSafe(cboFacility, "Items", Clear());
                while (dtr.Read())
                {

                 cboFacility.Invoke((MethodInvoker)(()=> cboFacility.Items.Add(dtr[0].ToString())));
                }


            }
        }

        private void tcLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcLogin.SelectedTab == tpSettings)
            {
                /* cboDatabase.DataSource = null;
                 cboDatabase.Items.Clear();
                 txtPassword.Clear();
                 txtUserNameServer.Clear();*/



                Thread g = new Thread(() => GetSqlServers());
                g.SetApartmentState(ApartmentState.STA);
                g.Start();

            }
            if (tcLogin.SelectedTab == tpLogin)
            {
                iqcareconnectionstring = Entity.GetConnString();
                InitializeForm();
            }


        }

        private void GetSqlServers()
        {
            if (cboServer.InvokeRequired)
            {

                cboServer.Invoke(new MethodInvoker(delegate
                {
                    cboServer.Items.Clear();
                }));
            }
            else
            {
                cboServer.Items.Clear();

            }

            SetControlPropertyThreadSafe(lblSaveProgress, "Text", "Getting  List of SQl Server");
            SetControlPropertyThreadSafe(picSettingsProgress, "Image", Properties.Resources.progress4);
            SetControlPropertyThreadSafe(cboServer, "DataSource", null);
            SetControlPropertyThreadSafe(cboServer, "Enabled", false);
            DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
            if (servers.Rows.Count > 0)
            {
                string displayMember = string.Empty;
                for (int i = 0; i < servers.Rows.Count; i++)
                {
                    if ((servers.Rows[i]["Version"].ToString()) != string.Empty)
                    {
                        if ((servers.Rows[i]["InstanceName"].ToString()) != string.Empty)
                        {
                            if (cboServer.InvokeRequired)
                            {
                                cboServer.Invoke(new MethodInvoker(delegate
                                {
                                    cboServer.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                                }));
                            }
                            else
                            {
                                cboServer.Items.Add(servers.Rows[i]["ServerName"] + "\\" + servers.Rows[i]["InstanceName"]);
                            }
                        }

                        else
                        {
                            if (cboServer.InvokeRequired)
                            {
                                cboServer.Invoke(new MethodInvoker(delegate
                                {
                                    cboServer.Items.Add(servers.Rows[i]["ServerName"]);
                                }));
                            }
                            else
                            {
                                cboServer.Items.Add(servers.Rows[i]["ServerName"]);
                            }
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show("No Named SQL Server Instances Were Found. Please check that the SQL Server Browser Service is running. " +
                 " You may still be able to connect by manually typing the Instance Name into the SQL Server Drop Down Box."
                 , "IQTools | Server Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            SetControlPropertyThreadSafe(lblSaveProgress, "Text", "Done");
            SetControlPropertyThreadSafe(cboServer, "Enabled", true);
            SetControlPropertyThreadSafe(picSettingsProgress, "Image", Properties.Resources.right);



        }

        private void cboDatabase_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string connString = string.Empty;
                if (cboServer.Text.Trim() != string.Empty && txtUserNameServer.Text.Trim() != string.Empty
                    && txtPassword.Text != string.Empty && cboDatabase.Text != string.Empty)
                {
                    connString = CreateConnectionString(cboServer.Text.Trim(), txtUserNameServer.Text, txtPassword.Text, cboDatabase.Text);
                    string IQCareVersion = GetIQCareVersion(connString);
                    if (IQCareVersion != string.Empty && IQCareVersion.ToLower() != "Not An IQCare DB")
                    {
                        picIQCareDatabase.Image = Properties.Resources.right;
                        lblIQCareVersion.Text = IQCareVersion;

                    }
                    else
                    {
                        picIQCareDatabase.Image = Properties.Resources.wrong;
                        lblIQCareVersion.Text = IQCareVersion;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private string GetIQCareVersion(string connString)
        {
            string IQCareVersion = string.Empty;
            try
            {
                Entity en = new Entity();
                DataRow dr = (DataRow)en.ReturnObject(connString, null, "SELECT TOP 1 AppVer FROM AppAdmin"
                    , ClsUtility.ObjectEnum.DataRow, serverType);
                IQCareVersion = dr["AppVer"].ToString();
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("not exist"))
                    return "Not An IQCare DB";
            }
            return IQCareVersion;
        }
        private DataTable GetIQCareDBs(string connString)
        {
            Entity en = new Entity();
            DataTable dt = (DataTable)en.ReturnObject(connString, null
                        , "SELECT d.name IQCareDB, f.name logicalName FROM master..sysaltfiles f " +
                        "INNER JOIN master..sysdatabases d ON f.dbid = d.dbid " +
                        "Where f.name like '%iqcare%' and f.fileid = 1"
                        , ClsUtility.ObjectEnum.DataTable, serverType);
            return dt;

        }
        private string CreateConnectionString(string server, string username, string pass, string db)
        {
            if (db != string.Empty)
            {
                return string.Format("server = {0}; user id={1}; password={2};initial catalog={3}", server, username, pass, db);
            }
            else
                return string.Format("server = {0}; user id={1}; password={2}", server, username, pass);


        }

        private void cboDatabase_Enter(object sender, EventArgs e)
        {
            try {
                string connString = string.Empty;
                if (cboServer.Text.Trim() != string.Empty && txtUserNameServer.Text != String.Empty
                    && txtPassword.Text != string.Empty)
                {
                    connString = CreateConnectionString(cboServer.Text.Trim(), txtUserNameServer.Text.Trim(), txtPassword.Text, string.Empty);
                    cboDatabase.DataSource = new BindingSource(GetIQCareDBs(connString), null);
                    cboDatabase.DisplayMember = "IQCareDB";
                    cboDatabase.SelectedIndex = -1;
                    picServer.Image = Properties.Resources.right;
                    picUserName.Image = Properties.Resources.right;
                    picPassword.Image = Properties.Resources.right;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("login failed"))
                {
                    picServer.Image = Properties.Resources.right;
                    picUserName.Image = Properties.Resources.right;
                    picPassword.Image = Properties.Resources.wrong;

                }
                MessageBox.Show(ex.Message);
            }
        }

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

               

              string server = cboServer.Text.Trim();
                    string serverUserName = txtUserNameServer.Text.Trim();
                    string serverPassword = txtPassword.Text;
                    string iqcareDB = cboDatabase.Text.Trim();
                    string serverIP = string.Empty;
                    if (server.IndexOf("\\") != -1)
                    {
                        serverIP = server.Substring(0, server.IndexOf("\\"));
                    }
                    else
                    {

                        serverIP = server;
                    }
                    if (serverIP == ".")
                    {
                        serverIP = "localhost";
                    }
                    Thread saveSettingsT = new Thread(() => SaveSettings(server, serverIP, serverUserName, serverPassword, iqcareDB));
                    saveSettingsT.SetApartmentState(ApartmentState.STA);
                    saveSettingsT.Start();
                

                

            }
            catch(Exception ex)
            {

                if (ex.Message.Contains("Access"))
                {
                    MessageBox.Show("Kindly run as an administrator  to save the correct settings in the database");

                   
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString());
                    // this.Close();
                }

                SetControlPropertyThreadSafe(picSettingsProgress, "Image", Properties.Resources.wrong);
                SetControlPropertyThreadSafe(btnSave, "Enabled", true);
                SetControlPropertyThreadSafe(lblSaveProgress, "Text", "Settings  Not Successfully Saved");
                SetControlPropertyThreadSafe(tcLogin, "SelectedTab", tpSettings);
                SetControlPropertyThreadSafe(picLoad, "Image", Properties.Resources.wrong);
                SetControlPropertyThreadSafe(lblLoad, "Text", "Settings  Not Successfully Saved");
                return;

            }

        }

        private void SaveSettings(string server, string serverIP, string serverUserName, string serverPassword, string iqcareDB)
        {
            try
            {
                SetControlPropertyThreadSafe(picSettingsProgress, "Image", Properties.Resources.progress4);
                SetControlPropertyThreadSafe(lblSaveProgress, "Text", "Saving...");
                SetControlPropertyThreadSafe(btnSave, "Enabled", false);
                string iqcareconnstring = CreateConnectionString(server, serverUserName, serverPassword, iqcareDB);
                Entity.SetConnString(iqcareconnstring);
                SetControlPropertyThreadSafe(picSettingsProgress, "Image", null);
                SetControlPropertyThreadSafe(btnSave, "Enabled", true);
                SetControlPropertyThreadSafe(lblSaveProgress, "Text", "");
                SetControlPropertyThreadSafe(tcLogin, "SelectedTab", tpLogin);
                SetControlPropertyThreadSafe(picLoad, "Image", Properties.Resources.right);
                SetControlPropertyThreadSafe(lblLoad, "Text", "Settings Successfully Saved");
                activateSatelliteCombo();
                clsGbl.SettingsValid = true;
            }

            catch(Exception ex)
            {

               MessageBox.Show(ex.Message.ToString());

                SetControlPropertyThreadSafe(picSettingsProgress, "Image", null);
                SetControlPropertyThreadSafe(btnSave, "Enabled", true);
                SetControlPropertyThreadSafe(lblSaveProgress, "Text", "");
                SetControlPropertyThreadSafe(tcLogin, "SelectedTab", tpSettings);
                SetControlPropertyThreadSafe(picLoad, "Image", Properties.Resources.wrong);
                SetControlPropertyThreadSafe(lblLoad, "Text", "Settings  Not Successfully Saved");
                return;
                   // this.Close();
                
            }
        }

        private void tlpLogin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private bool loginEMR( string username, string password, string facilityname)
        {

            DataRow dr;
            Entity en = new Entity();
            string connstring = Entity.GetConnString().ToString();

            ClsUtility.Init_Hashtable();
            string sPassword = ClsUtility.Encrypt(password);
            string sSQL = "SELECT top 1 a.userID, a.UserName, a.Password, a.UserFirstName, a.UserLastName, c.GroupName, f.FacilityID, f.SatelliteID MFLCode FROM " +
                            "(Select FacilityID, SatelliteID FROM mst_Facility WHERE FacilityName = '" + facilityname + "') f, " +
                            "mst_user a " +
                            "INNER JOIN dbo.lnk_UserGroup b ON a.UserID = b.UserID " +
                            "INNER JOIN dbo.mst_Groups c ON b.GroupID = c.GroupID " +
                            "WHERE a.DeleteFlag = 0 AND a.UserName = '" + username + "' AND Password = '" + sPassword + "'";
            try {
                 dr = (DataRow)en.ReturnObject(connstring, ClsUtility.theParams, sSQL, ClsUtility.ObjectEnum.DataRow, serverType);

            }
            catch(Exception ex) {
                if (ex.Message.Contains("There is no row at position 0"))
                {
                    MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show(ex.Message, Assets.Messages.ErrorHeader);
                    return false;

                }

            }
            if (dr.Table.Rows.Count >= 1)
            {
                clsGbl.loggedInUser.UserID = Convert.ToInt16(dr["userID"]);
                clsGbl.loggedInUser.UserName = dr["UserName"].ToString();
                clsGbl.loggedInUser.Password = dr["Password"].ToString();
                clsGbl.loggedInUser.FirstName = dr["UserFirstName"].ToString();
                clsGbl.loggedInUser.LastName = dr["UserLastName"].ToString();
                clsGbl.loggedInUser.Group = dr["GroupName"].ToString();
                clsGbl.loggedInUser.FacilityID = Convert.ToInt16(dr["FacilityID"]);
                clsGbl.loggedInUser.FacilityName = facilityname;
                clsGbl.loggedInUser.MFLCode = dr["MFLCode"].ToString();
                return true;
            }
            else
            {
                MessageBox.Show(Assets.Messages.InvalidUser, Assets.Messages.ErrorHeader);
                return false;
            }


        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string selectedFacility = "";
            if (clsGbl.SettingsValid == false)
            {
                MessageBox.Show(Assets.Messages.InvalidSettings, Assets.Messages.InfoHeader, MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (txtUser.Text != "" && txtPasswordLogin.Text != "")
                {
                    if (cboFacility.SelectedIndex > -1)
                        selectedFacility = cboFacility.SelectedItem.ToString();

                    else
                    {
                        MessageBox.Show("Please Select A Facility To Proceed", Assets.Messages.InfoHeader
                               , MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    if (loginEMR(txtUser.Text, txtPasswordLogin.Text, selectedFacility))
                    {
                        Thread loadThread = new Thread(() => LoadMainForm());
                        loadThread.SetApartmentState(ApartmentState.STA);
                        loadThread.Start();

                    }
                }
                else
                {
                    MessageBox.Show(Assets.Messages.MissingCredentials, Assets.Messages.InfoHeader
                        , MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                   
               

                }

            }

        private void LoadMainForm()
        {
            try
            {
                SetControlPropertyThreadSafe(btnLogin, "Enabled", false);
                SetControlPropertyThreadSafe(picLoad, "Image", Properties.Resources.progress4);
                SetControlPropertyThreadSafe(lblLoad, "Text", "Loading, Please Wait...");
                Form tmp = new frmMain();
                AccessContol();
                Application.Run(tmp);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("There Was A Problem Accessing The EMR Database"
                                        , "VLSystem", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                SetControlPropertyThreadSafe(btnLogin, "Enabled", true);
                SetControlPropertyThreadSafe(picLoad, "Image", null);
                SetControlPropertyThreadSafe(lblLoad, "Text", "");
                return;
            }
        }
        private void AccessContol()
        {
            if (InvokeRequired)
            { this.Invoke(new MethodInvoker(delegate { this.Hide(); })); }
            else { this.Hide(); }
        }

    }
    }
      

        
    

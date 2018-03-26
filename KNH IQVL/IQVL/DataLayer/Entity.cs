using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace IQVL.DataLayer
{
   public class Entity:ProcessBase
    {

        public Entity()
        {

        }
        public static string GetEMRType()
        {
            //TODO
            return "iqcare";
        }

        public static void SetConnString(string ConnectionString)
        {

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            var appSettings = configFile.AppSettings.Settings;


            //appSettings["ConnectionString"].Value = ClsUtility.Encrypt(ConnectionString);
            XmlDocument XmlDoc = new XmlDocument();
            //Loading the Config file
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "appSettings")
                {
                    //setting the coonection string
                    xElement.FirstChild.Attributes[1].Value = ClsUtility.Encrypt(ConnectionString);
                }
            }
            //writing the connection string in config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
           // configFile.AppSettings.SectionInformation.ForceSave = true;
            //configFile.Save(ConfigurationSaveMode.Modified);
            //ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            //Application.UserAppDataRegistry.SetValue("ConnectionString", ClsUtility.Encrypt(ConnectionString));


        }
        public static string GetServerType()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            return appSettings["ServerType"].Value.ToLower();
        }
        public static String GetConnString()
        {
             var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettings = configFile.AppSettings.Settings;
            return ClsUtility.Decrypt(appSettings["ConnectionString"].Value);

            /*string versionDependent = Application.UserAppDataRegistry.Name;
            string versionIndependent = versionDependent.Substring(0, versionDependent.LastIndexOf("\\"));


            string ConnectionString = String.Empty;
            //if (Application.UserAppDataRegistry.GetValue("ConnectionString") != null)
            //return ClsUtility.Decrypt(Application.UserAppDataRegistry.GetValue("ConnectionString").ToString());
            if (Registry.GetValue(versionIndependent, "ConnectionString", null) != null)
                return ClsUtility.Decrypt(Registry.GetValue(versionIndependent, "ConnectionString", null).ToString());
            else return ConnectionString;*/

        }
        
        public object ReturnObject(string ConString, Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj, string pmmsType)
        {
            switch (pmmsType.Trim().ToLower())

            {
                case "mssql":
                    {
                        return MsSQLObject(ConString, Params, CommandText, Obj);
                    }
                //case "mysql":
                //    {
                //        return MySQLObject(ConString, Params, CommandText, Obj);
                //    }
               // case "pgsql":
                //{
                //    return PgSQLObject(ConString, Params, CommandText, Obj);
                //}
                //case "access":
                  //  {
                        //return AccessObject(ConString, Params, CommandText, Obj);
                    //}
                default:
                    {
                        return MsSQLObject(ConString, Params, CommandText, Obj);
                    }

            }

        }
        public static object GetConnection(string ConString, string dbType)
        {
            switch (dbType)
            {
                case "mssql":
                    {
                        SqlConnection connection = new SqlConnection(ConString);
                        connection.Open();
                        return connection;
                    }
                //case "mysql":
                //    {
                //        MySqlConnection connection = new MySqlConnection(ConString);
                //        connection.Open();
                //        return connection;
                //    }

               // case "msaccess":
                 //   {
                   //     OleDbConnection connection = new OleDbConnection(ConString);
                     //   connection.Open();
                       // return connection;
                    //}
                //case "pgsql":
                //    {
                //        NpgsqlConnection connection = new NpgsqlConnection(ConString);
                //        connection.Open();
                //        return connection;
                //    }
                default:
                    {
                        SqlConnection connection = new SqlConnection(ConString);
                        connection.Open();
                        return connection;
                    }
            }
        }
        private object MsSQLObject(string ConString, Hashtable Params, string CommandText, ClsUtility.ObjectEnum Obj)
        {
            int i;
            string cmdpara, cmdvalue, cmddbtype;
            SqlCommand theCmd = new SqlCommand();
            SqlTransaction theTran = (SqlTransaction)this.Transaction;
            SqlConnection cnn;

            if (null == this.Connection)
            {
                cnn = (SqlConnection)GetConnection(ConString, "mssql");
            }
            else
            {
                cnn = (SqlConnection)this.Connection;
            }

            if (null == this.Transaction)
            {
                theCmd = new SqlCommand(CommandText, cnn);
            }
            else
            {
                theCmd = new SqlCommand(CommandText, cnn, theTran);
            }
            if (Params != null)
            {
                for (i = 1; i <= Params.Count;)
                {
                    cmdpara = Params[i].ToString();
                    cmddbtype = Params[i + 1].ToString();
                    cmdvalue = Params[i + 2].ToString();
                    theCmd.Parameters.AddWithValue(cmdpara, cmddbtype).Value = cmdvalue;
                    i = i + 3;
                }
            }
            theCmd.CommandTimeout = 0;
            theCmd.CommandType = CommandType.StoredProcedure;
            string theSubstring = CommandText.Substring(0, 6).ToUpper();
            switch (theSubstring)
            {
                case "SELECT":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "UPDATE":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "RESTOR":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "INSERT":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DELETE":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "CREATE":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DROP S":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DROP V":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DBCC C":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "DBCC S":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "BACKUP":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "EXEC S":
                    theCmd.CommandType = CommandType.Text;
                    break;
                case "SET DA":
                    theCmd.CommandType = CommandType.Text;
                    break;

                 default:
                    theCmd.CommandType = CommandType.Text;
                    break;
                    //case "WITH I"://TODO DONE for common table expressions start with an I for the CTE name
                    //    theCmd.CommandType = CommandType.Text;
                    //    break;
            }
            if (CommandText.Substring(0, 4).ToUpper() == "WITH") //CTE
                theCmd.CommandType = CommandType.Text;
            if (CommandText.IndexOf("SET OFFLINE") > 0 || CommandText.IndexOf("SET ONLINE") > 0)
                theCmd.CommandType = CommandType.Text;
            if (CommandText.Length >= 15)
            { if (CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [TMP" || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [MGR" || CommandText.Substring(0, 15).ToUpper() == "DROP TABLE [TPS") theCmd.CommandType = CommandType.Text; }
            if (CommandText.Length >= 10)
            { if (CommandText.Substring(0, 10).ToUpper() == "DROP SYNON") theCmd.CommandType = CommandType.Text; }
            if (CommandText.Length >= 22)
            { if (CommandText.Substring(0, 22).ToUpper() == "DROP TABLE MST_PATIENT") theCmd.CommandType = CommandType.Text; }
            if (CommandText.Length >= 30)
            { if (CommandText.Substring(0, 30).ToUpper() == "DROP TABLE DTL_PATIENTCONTACTS") theCmd.CommandType = CommandType.Text; }



            theCmd.Connection = cnn;

            try
            {
                SqlCommand cm;
                if (ClsUtility.SDate != "")
                {
                    cm = new SqlCommand("SET Dateformat " + ClsUtility.SDate, cnn);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                }
                cm = null;
                if (Obj == ClsUtility.ObjectEnum.DataSet)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataSet theDS = new DataSet();
                    //theDS.Tables[0].BeginLoadData();
                    theAdpt.Fill(theDS);
                    //theDS.Tables[0].EndLoadData();
                    return theDS;
                }

                if (Obj == ClsUtility.ObjectEnum.DataTable)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theDT.BeginLoadData();
                    theAdpt.Fill(theDT);
                    theDT.EndLoadData();
                    return theDT;
                }

                if (Obj == ClsUtility.ObjectEnum.DataRow)
                {
                    SqlDataAdapter theAdpt = new SqlDataAdapter(theCmd);
                    DataTable theDT = new DataTable();
                    theDT.BeginLoadData();
                    theAdpt.Fill(theDT);
                    theDT.EndLoadData();
                    return theDT.Rows[0];
                }

                if (Obj == ClsUtility.ObjectEnum.ExecuteNonQuery)
                {
                    int NoRowsAffected = theCmd.ExecuteNonQuery();
                    return NoRowsAffected;
                }

                if (null == this.Connection)
                    cnn.Close();
                return 0;
            }
            catch (Exception err)
            {
                throw err;
                //return null;
            }

            finally
            {
                if (null != cnn)
                    if (null == this.Connection)
                        cnn.Close();
            }
        }


    }
}

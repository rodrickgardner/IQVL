using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IQVL.BusinessLayer
{
    public class clsGbl
    {
        public static string DBSecurity = "'ttwbvXWpqb5WOLfLrBgisw=='";
        public static bool SettingsValid = true;
        //EMR user
        public static User loggedInUser = new User();
        public static string PatientID;
        public static DataTable dr;
        public static DataTable AddList;
        public static bool firstload = true;
        public static Form frm;
        public static Form frmMain;
        public static DataGridView dgvView;
        public static Form frmViralloadlist;


        public static DataTable VLDataTable;
        public static DataTable VLWithoutDataTable;

        public  static string MakeDate(string theDate)
        {
            string date = theDate;
            if (theDate != "")
            {
                string theDay, theMonth, theYear;
                string[] theDT, theDT2;
                theDT = theDate.Split(Convert.ToChar("-"));
                if (theDT.Length > 1)
                {
                    theDay = theDT[0];
                    theMonth = theDT[1];
                    theYear = theDT[2];
                }
                else
                {
                    theDT = theDate.Split(Convert.ToChar("/"));
                    theDay = theDT[1];
                    theMonth = theDT[0];
                    theDT2 = theDT[2].Split(Convert.ToChar(" "));
                    theYear = theDT2[0];
                }

                string.Format("{0}/{1}/{2}", theMonth, theDay, theYear);

            }
            
                return date;
            
        

        }
    }
}

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
    }
}

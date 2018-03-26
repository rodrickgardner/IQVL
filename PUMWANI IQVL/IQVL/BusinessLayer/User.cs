using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQVL.BusinessLayer
{
   public  class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string MFLCode { get; set; }


    }
}

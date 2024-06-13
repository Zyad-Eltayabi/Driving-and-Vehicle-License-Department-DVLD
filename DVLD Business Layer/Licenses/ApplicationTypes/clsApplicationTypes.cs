using DVLD_Database_Layer.Licenses.ApplicationTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Presentation_layer.Licenses.ApplicationTypes
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public float ApplicationFees { get; set; }

        public clsApplicationTypes()
        {
             this.ApplicationTypeID = 0;
            this.ApplicationTypeTitle = string.Empty;
            this.ApplicationFees = 0;
        }

        private clsApplicationTypes(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            ApplicationTypeID = applicationTypeID;
            ApplicationTypeTitle = applicationTypeTitle;
            ApplicationFees = applicationFees;
        }

        public static DataTable GetApplicationTypes()
        {
            return clsApplicationTypesDB.GetApplicationTypes();
        }

        public bool UpdateApplicationType()
        {
            return clsApplicationTypesDB.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationFees);
        }

        public static clsApplicationTypes GetApplicationType(int applicationTypeID)
        {
            string applicationTypeTitle = " ";
            float applicationFees = 0;

            if(clsApplicationTypesDB.GetApplicationType(applicationTypeID,ref applicationTypeTitle,ref applicationFees))
                return new clsApplicationTypes(applicationTypeID,applicationTypeTitle,applicationFees);

            return null;
        }

    }
}

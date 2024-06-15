using DVLD_Business_Layer.Licenses.Applications;
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

        public static float GetFees(clsApplications.ApplicationTypes applicationTypes)
        {
            string applicationTypetitle = GetApplicationTypeTitle(applicationTypes);
            return clsApplicationTypesDB.GetFees(applicationTypetitle);
        }

        private static string GetApplicationTypeTitle(clsApplications.ApplicationTypes applicationTypes)
        {
            string title = "";
            switch (applicationTypes)
            {
                case clsApplications.ApplicationTypes.NewLocalDrivingLicenseService:
                    title = "New Local Driving License Service";
                    break;
                case clsApplications.ApplicationTypes.RenewDrivingLicenseService:
                    title = "Renew Driving License Service";
                    break;
                case clsApplications.ApplicationTypes.ReplacementforaLostDrivingLicense:
                    title = "Replacement for a Lost Driving License";
                    break;
                case clsApplications.ApplicationTypes.ReplacementforaDamagedDrivingLicens:
                    title = "Replacement for a Damaged Driving License";
                    break;
                case clsApplications.ApplicationTypes.ReleaseDetainedDrivingLicsense:
                    title = "Release Detained Driving Licsense";
                    break;
                case clsApplications.ApplicationTypes.NewInternationalLicense:
                    title = "New International License";
                    break;
                case clsApplications.ApplicationTypes.RetakeTest:
                    title = "Retake Test";
                    break;
                default:
                    break;
            }
            return title;
        }
    }
}

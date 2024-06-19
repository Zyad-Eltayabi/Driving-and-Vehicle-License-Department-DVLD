using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Database_Layer.Licenses.Local_Licence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Licenses.Local_License
{
    public class clsLocalLicense : clsApplications
    {

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        public Mode enMode { get; set; }

        public clsLocalLicense()
        {
            LocalDrivingLicenseApplicationID = 0;
            LicenseClassID = 1;
            enMode = Mode.New;
        }

        public enum ClassName
        {
            Class1 = 1,
            Class2,
            Class3,
            Class4,
            Class5,
            Class6,
            Class7,
        }
        public enum Mode
        {
            New = 1,
            Update
        }
        private bool AddNewLocalLicense()
        {
            bool saveApplicationInGeneralTable = base.AddNewApplication();

            if (saveApplicationInGeneralTable)
            {
                this.LocalDrivingLicenseApplicationID = clsLocalLicenseDB.AddNewLocalLicense(ApplicationID, LicenseClassID);
                return this.LocalDrivingLicenseApplicationID != -1;
            }

            return false;
        }


        public bool Save()
        {
            switch (enMode)
            {
                case Mode.New:
                    enMode = Mode.Update;
                    return AddNewLocalLicense();
                default:
                    return true;
            }
        }

        public static bool IsPersonHasALocalLicenseOfTheSameLicenseClass(int applicantPersonID, int licenseClassID)
        {
            return clsLocalLicenseDB.IsPersonHasALocalLicenseOfTheSameLicenseClass(applicantPersonID, licenseClassID);
        }

        public static bool VerifyAValidLicense(int applicantPersonID, int licenseClassID)
        {
            return clsLocalLicenseDB.VerifyAValidLicense(applicantPersonID, licenseClassID);
        }

        public static DataTable GetLocalDrivingLicenses()
        {
            return clsLocalLicenseDB.GetLocalDrivingLicenses();
        }
    }
}

using DVLD_Database_Layer.Licenses.InternationalLicenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business_Layer.Licenses.InternationalLicenses
{
    public class clsInternationalLicenses
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public Mode enMode { get; set; }
        public enum Mode
        {
            New = 1,
            Update
        }

        public clsInternationalLicenses(int applicationID, int driverID,
            int issuedUsingLocalLicenseID, int createdByUserID, DateTime expirationDate, bool isActive)
        {
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            CreatedByUserID = createdByUserID;
            IssueDate = DateTime.Now;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            this.enMode = Mode.New;
        }

        public static DataTable GetLicensesByDriverID(int driverID)
        {
            return clsInternationalLicensesDB.GetLicensesByDriverID(driverID);
        }

        private bool AddNewInternationalLicense()
        {
            this.InternationalLicenseID = clsInternationalLicensesDB.AddNewInternationalLicense(this.ApplicationID,
                this.DriverID,this.IssuedUsingLocalLicenseID, this.CreatedByUserID, this.ExpirationDate, this.IsActive);

            return this.InternationalLicenseID != -1;
        }


        public bool SaveInternationalLicense()
        {
            switch (enMode)
            {
                case Mode.New:
                    enMode = Mode.Update;
                    return AddNewInternationalLicense();
                default:
                   return false;
            }
        }

        public static bool IsPersonHasAnActiveInternationalLicense(int localLicenseID)
        {
            return clsInternationalLicensesDB.IsPersonHasAnActiveInternationalLicense(localLicenseID);
        }

        public static DataTable GetLicenseByInternationalLicenseID(int internationalLicenseID)
        {
            return clsInternationalLicensesDB.GetLicenseByInternationalLicenseID(internationalLicenseID);
        }













    }
}

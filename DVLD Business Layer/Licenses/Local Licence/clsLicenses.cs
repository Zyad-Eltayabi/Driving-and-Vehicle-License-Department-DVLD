using DVLD_Database_Layer.Licenses.Drivers;
using DVLD_Database_Layer.Licenses.Local_Licence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business_Layer.Licenses.Local_Licence
{
    public class clsLicenses
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public bool IsActive { get; set; }
        public int IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public float PaidFees { get; set; }
        public enum Mode { New = 1, Update = 2 }
        public Mode enMode { get; set; }
        public clsLicenses(int applicationID, int driverID, int licenseClass,
            int issueReason, int createdByUserID, DateTime expirationDate, string notes, float paidFees)
        {
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IsActive = true;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
            IssueDate = DateTime.Now;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            enMode = Mode.New;
        }

        public enum IssueReasons
        {
            FirstTime = 1,
            Renew, 
            ReplacementforDamaged,
            ReplacementforLost
        }
        private bool AddNewLicense()
        {
            this.LicenseID = clsLicensesDB.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClass,
             this.IssueReason, this.CreatedByUserID, this.ExpirationDate, this.Notes, this.PaidFees);

            return this.LicenseID != -1;
        }

        public bool SaveLicense()
        {
            switch (enMode)
            {
                case Mode.New:
                    enMode = Mode.Update;
                    return AddNewLicense();
                default:
                    return false;
            }
        }

        public static DataTable GetLicense(int localDrivingAppID)
        {
            return clsLicensesDB.GetLicense(localDrivingAppID);
        }
    }
}

using DVLD_Database_Layer.Licenses.Detained_Licenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Licenses.Detained_Licenses
{
    public class clsDetainedLicenses
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public int CreatedByUserID { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }
        DateTime DetainDate { get; set; }
        DateTime ReleaseDate { get; set; }
        public float FineFees { get; set; }
        public bool IsReleased { get; set; }
        public enum Mode { New = 1, Update = 2 }
        public Mode enMode { get; set; }

        public clsDetainedLicenses(int licenseID, int createdByUserID, float fineFees)
        {
            LicenseID = licenseID;
            CreatedByUserID = createdByUserID;
            DetainDate = DateTime.Now;
            FineFees = fineFees;
            IsReleased = false;
            enMode = Mode.New;
        }

        public static bool IsLicenseDetained(int licenseID)
        {
            return clsDetainedLicensesDB.IsLicenseDetained(licenseID);
        }

        private bool DetainLicense()
        {
            this.DetainID = clsDetainedLicensesDB.DetainLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased);
            return this.DetainID != -1;
        }

        public bool SaveDetain()
        {
            switch (enMode)
            {
                case Mode.New:
                    enMode = Mode.Update;
                    return DetainLicense();
                default:
                    return false;
            }
        }
    }
}

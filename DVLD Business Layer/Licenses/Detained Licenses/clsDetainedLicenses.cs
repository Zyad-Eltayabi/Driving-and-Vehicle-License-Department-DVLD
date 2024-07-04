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
        public DateTime DetainDate { get; set; }
        public DateTime ReleaseDate { get; set; }
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

        private clsDetainedLicenses(int detainID, int licenseID, int createdByUserID, int releasedByUserID,
            int releaseApplicationID, DateTime detainDate, DateTime releaseDate, float fineFees, bool isReleased)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            CreatedByUserID = createdByUserID;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            DetainDate = detainDate;
            ReleaseDate = releaseDate;
            FineFees = fineFees;
            IsReleased = isReleased;
            this.enMode = Mode.Update;
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

        public static clsDetainedLicenses GetDetainedLicenseByLicenseID(int licenseID)
        {
            int detainID = 0; int createdByUserID = 0; int releasedByUserID = 0; int releaseApplicationID = 0;
            DateTime detainDate = DateTime.Now; DateTime releaseDate = DateTime.Now; float fineFees = 0;
            bool isReleased = false;

            if (clsDetainedLicensesDB.GetDetainedLicenseByLicenseID(ref detainID, ref licenseID, ref createdByUserID, ref releasedByUserID,
            ref releaseApplicationID, ref detainDate, ref releaseDate, ref fineFees, ref isReleased))
            {
                return new clsDetainedLicenses(detainID, licenseID, createdByUserID, releasedByUserID,
             releaseApplicationID, detainDate, releaseDate, fineFees, isReleased);
            }

            return null;
        }

        private bool UpdateDetainedLicense()
        {
            return clsDetainedLicensesDB.UdpateDetainedLicense(DetainID, LicenseID, CreatedByUserID, ReleasedByUserID,
             ReleaseApplicationID, DetainDate, ReleaseDate, FineFees, IsReleased);
        }

        public bool SaveDetain()
        {
            switch (enMode)
            {
                case Mode.New:
                    enMode = Mode.Update;
                    return DetainLicense();
                default:
                    return UpdateDetainedLicense();
            }
        }
    }
}

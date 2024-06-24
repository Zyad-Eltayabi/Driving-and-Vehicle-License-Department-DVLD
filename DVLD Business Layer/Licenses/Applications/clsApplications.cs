using DVLD_Database_Layer.Licenses.Applications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DVLD_Business_Layer.Licenses.Applications.clsApplications;

namespace DVLD_Business_Layer.Licenses.Applications
{
    public class clsApplications
    {
        public clsApplications()
        {
            ApplicationID = 0;
            ApplicantPersonID = 0;
            ApplicationTypeID = 0;
            ApplicationStatus = 1;
            CreatedByUserID = 0;
            PaidFees = 0;
            ApplicationDate = DateTime.Now;
            LastStatusDate = DateTime.Now;
            enMode = Mode.New;
        }

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public int CreatedByUserID { get; set; }
        public float PaidFees { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public Mode enMode { get; set; }

        public enum Mode
        {
            New = 1,
            Update
        }

        public enum ApplicationTypes
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService,
            ReplacementforaLostDrivingLicense,
            ReplacementforaDamagedDrivingLicens,
            ReleaseDetainedDrivingLicsense,
            NewInternationalLicense,
            RetakeTest
        }

        public enum ApplicationsStatus
        {
            New = 1,
            Cancelled,
            Completed
        }



        public bool AddNewApplication()
        {
            this.ApplicationID = clsApplicationsDB.AddNewApplication(ApplicantPersonID, ApplicationTypeID, ApplicationStatus,
             CreatedByUserID, PaidFees);

            return ApplicationID != -1;
        }

        public static DataTable GetApplicationInfo(int applicationID)
        {
            return clsApplicationsDB.GetApplicationInfo(applicationID);
        }

        public bool SaveApplication()
        {
            switch (enMode)
            {
                case Mode.New:
                    return AddNewApplication();
                default:
                    return false;
            }
        }

    }
}

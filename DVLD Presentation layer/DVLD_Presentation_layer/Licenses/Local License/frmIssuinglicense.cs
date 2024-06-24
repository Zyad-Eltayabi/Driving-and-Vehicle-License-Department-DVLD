using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Drivers;
using DVLD_Business_Layer.Licenses.Local_Licence;
using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Login;
using DVLD_Presentation_layer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.Licenses.Local_License
{
    public partial class frmIssuinglicense : Form
    {
        public frmIssuinglicense(int localDrivingAppID, int applicationID)
        {
            InitializeComponent();
            this.localDrivingAppID = localDrivingAppID;
            this.applicationID = applicationID;
            this.personID = -1;
            clsPublicUtilities.CenterForm(this);
        }

        private int localDrivingAppID, applicationID, personID;

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int GetDriverID()
        {
            int driverID = clsDrivers.GetDriverID(this.personID);
            if (driverID != -1) // that mean the person is already driver in a system
                return driverID;

            // save a new driver in system
            clsDrivers driver = new clsDrivers(this.personID, clsLogin.userID);
            if (driver.SaveDriver())
                return driver.DriverID;

            clsPublicUtilities.ErrorMessage("Data failed to save");
            return 0;
        }

        private bool SaveNewLicense(int driverID)
        {
            if (driverID == 0)
                return false;

            // LicenseClass  ExpirationDate  PaidFees
            int licenseClass = clsLocalLicense.GetLicenseClassID(this.localDrivingAppID);
            int defaultValidityLength = clsLocalLicense.GetDefaultValidityLength(licenseClass);
            DateTime expirationDate = DateTime.Now.AddYears(defaultValidityLength);
            float classFees = clsLocalLicense.GetClassFees(licenseClass);

            clsLicenses license = new clsLicenses(this.applicationID, driverID, licenseClass,
                (int)clsLicenses.IssueReasons.FirstTime, clsLogin.userID, expirationDate,
                tbNotes.Text.ToString(), classFees);

            if (license.SaveLicense())
                return true;

            clsPublicUtilities.ErrorMessage("Data failed to save");
            return false;
        }

        private void UpdateApplicationStatus()
        {
            if (clsApplications.UpdateApplicationStatus(this.applicationID, (int)clsApplications.ApplicationsStatus.Completed))
            {
                clsPublicUtilities.InformationMessage("License saved successfully");
                return;
            }
            clsPublicUtilities.ErrorMessage("Data failed to save");
        }
        private void IssueLicense()
        {
            int driverID = GetDriverID();

            if (!SaveNewLicense(driverID))
                return;

            // update here the main application
            UpdateApplicationStatus();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            IssueLicense();
        }

        private void frmIssuinglicense_Load(object sender, EventArgs e)
        {
            LoadPersonInfo();
        }

        private void LoadPersonInfo()
        {
            ucApplicationFullInfo1.LoadTestData(localDrivingAppID, applicationID);
            this.personID = clsLocalLicense.GetApplicantPersonID(localDrivingAppID);
        }




    }
}

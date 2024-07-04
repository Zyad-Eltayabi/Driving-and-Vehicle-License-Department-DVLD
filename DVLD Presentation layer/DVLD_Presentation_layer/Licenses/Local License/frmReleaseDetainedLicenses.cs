using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Detained_Licenses;
using DVLD_Business_Layer.Licenses.Local_Licence;
using DVLD_Business_Layer.Login;
using DVLD_Presentation_layer.Licenses.ApplicationTypes;
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
    public partial class frmReleaseDetainedLicenses : Form
    {
        clsLicenses license;
        clsDetainedLicenses detainedLicense;
        clsApplications releaseApplication;
        public frmReleaseDetainedLicenses()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool GetLicense()
        {
            license = clsLicenses.GetLicenseByID(int.Parse(tbFilter.Text));

            if (license == null)
            {
                clsPublicUtilities.ErrorMessage("There is no license with this number.");
                return false;
            }
            return true;
        }

        private bool ValidateLicense()
        {
            int ID =int.Parse( tbFilter.Text.ToString());
            if (!clsDetainedLicenses.IsLicenseDetained(ID))
            {
                clsPublicUtilities.WarningMessage("This license is not detained , choose another license.");
                return false;
            }

            return true;
        }

        private void SetLicenseInfo()
        {
            int personID = clsApplications.GetPersonID(license.ApplicationID);
            ucShowLicense1.LoadLicenseInfo(license.ApplicationID, personID);
        }

        private void SetFees()
        {
            lbFineFees.Text = detainedLicense.FineFees.ToString();
            lbApplicationFess.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReleaseDetainedDrivingLicsense).ToString();
            lbTotalFess.Text = (detainedLicense.FineFees + float.Parse(lbApplicationFess.Text.ToString())).ToString();
        }

        private void SetReleaseInfo()
        {
            lbCreatedBy.Text = clsLogin.userName;
            lbIocalID.Text = license.LicenseID.ToString();
            lbReleaseDate.Text = DateTime.Now.ToString();
            SetFees();
            btnRelease.Enabled = true;
        }

        private void SetDetainedLicense()
        {
            detainedLicense = clsDetainedLicenses.GetDetainedLicenseByLicenseID(int.Parse(tbFilter.Text.ToString()));
        }

        private void GetLicenseInfo()
        {
            if (!ValidateLicense())
                return;

            if (!GetLicense())
                return;

            SetDetainedLicense();

            SetLicenseInfo();

            SetReleaseInfo();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnRelease.Enabled = false;
            if (int.Parse(tbFilter.Text) < 1)
            {
                clsPublicUtilities.WarningMessage("Enter a valid license number , it should be greater than 0");
                return;
            }
            GetLicenseInfo();
        }
        private void PrintWrongMessage()
        {
            clsPublicUtilities.ErrorMessage("failed to save data");
        }
        private bool CreateReleaseApplication()
        {
            int personID = clsApplications.GetPersonID(license.ApplicationID);
            float fees = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReleaseDetainedDrivingLicsense);

            releaseApplication = new clsApplications(personID,(int)clsApplications.ApplicationTypes.ReleaseDetainedDrivingLicsense
                ,(int)clsApplications.ApplicationsStatus.Completed,clsLogin.userID, fees);

            if(!releaseApplication.SaveApplication())
            {
                PrintWrongMessage();
                return false;
            }
            return true;
        }

        private void UpdateDetainedLicense()
        {
            detainedLicense.IsReleased = true;
            detainedLicense.ReleasedByUserID = clsLogin.userID;
            detainedLicense.ReleaseDate = DateTime.Now;
            detainedLicense.ReleaseApplicationID = releaseApplication.ApplicationID;

            if(detainedLicense.SaveDetain())
            {
                clsPublicUtilities.InformationMessage("license released successfully.");
                return;
            }
            PrintWrongMessage();
        }

        private void ReleaseLicense()
        {
            if (!CreateReleaseApplication())
                return;

            UpdateDetainedLicense();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            ReleaseLicense();
        }
    }
}

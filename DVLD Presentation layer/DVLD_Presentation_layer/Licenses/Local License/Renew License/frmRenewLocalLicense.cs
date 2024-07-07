using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Drivers;
using DVLD_Business_Layer.Licenses.Local_Licence;
using DVLD_Business_Layer.Licenses.Local_License;
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
    public partial class frmRenewLocalLicense : Form
    {
        clsLicenses oldLicense;
        clsApplications renewApplication;

        public frmRenewLocalLicense()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private bool GetLicenseToRenew()
        {
            oldLicense = clsLicenses.GetLicenseByID(int.Parse(tbFilter.Text));

            if (oldLicense == null)
            {
                clsPublicUtilities.ErrorMessage("There is no license with this number.");
                return false;
            }
            return true;
        }

        private void SetLicenseInfo()
        {
            int personID = clsApplications.GetPersonID(oldLicense.ApplicationID);
            ucShowLicense1.LoadLicenseInfo(oldLicense.ApplicationID, personID);
        }

        private bool ValidateLicense()
        {
            if (oldLicense.ExpirationDate > DateTime.Now)
            {
                clsPublicUtilities.WarningMessage("Your license is not expired, you don't need to renew it "
                               + " and it will be expire on " + $"{oldLicense.ExpirationDate}");
                return false;
            }

            if (!oldLicense.IsActive)
            {
                clsPublicUtilities.ErrorMessage("This license isn't active you may have an active license of this type of licenses");
                return false;
            }
            return true;
        }

        private void SetNewApplicationInfo()
        {
            lbApplicationDate.Text = lbIssueDate.Text = DateTime.Now.ToShortDateString();
            lbExpirationDate.Text = DateTime.Now.AddYears(clsLocalLicense.GetDefaultValidityLength(oldLicense.LicenseClass)).ToString();
            lbApplicationFess.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.RenewDrivingLicenseService).ToString();
            lbLicenseFees.Text = clsLocalLicense.GetClassFees(oldLicense.LicenseClass).ToString();
            lbTotalFees.Text = (int.Parse(lbLicenseFees.Text.ToString()) + int.Parse(lbApplicationFess.Text.ToString())).ToString();
            lbCreatedBy.Text = clsLogin.userName;
            lbOldIocalID.Text = oldLicense.LicenseID.ToString();
            btnRenew.Enabled = true;
        }
        private void GetLicenseInfo()
        {
            if (!GetLicenseToRenew())
                return;

            if (!ValidateLicense())
                return;

            SetLicenseInfo();

            SetNewApplicationInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnRenew.Enabled = false;
            if (int.Parse(tbFilter.Text) < 1)
            {
                clsPublicUtilities.WarningMessage("Enter a valid license number , it should be greater than 0");
                return;
            }
            GetLicenseInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintWrongMessage()
        {
            clsPublicUtilities.ErrorMessage("License renewal failed");
        }
        private bool CreateNewApplication()
        {
            float fees = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.RenewDrivingLicenseService);
            int personID = clsApplications.GetPersonID(oldLicense.ApplicationID);

            renewApplication = new clsApplications(personID, (int)clsApplications.ApplicationTypes.RenewDrivingLicenseService
                , (int)clsApplications.ApplicationsStatus.Completed, clsLogin.userID, fees);

            if (!renewApplication.SaveApplication())
            {
                PrintWrongMessage();
                return false;
            }

            lbRenewApplicationID.Text = renewApplication.ApplicationID.ToString();
            return true;
        }

        private bool CreateNewLicense()
        {
            DateTime expDate = DateTime.Now.AddYears(clsLocalLicense.GetDefaultValidityLength(oldLicense.LicenseClass));
            float fees = clsLocalLicense.GetClassFees(oldLicense.LicenseClass);
            string notes = tbNotes.Text.ToString();

            clsLicenses newLicense = new clsLicenses(renewApplication.ApplicationID, oldLicense.DriverID,
                oldLicense.LicenseClass, (int)clsLicenses.IssueReasons.Renew, clsLogin.userID, expDate, notes, fees);

            if (!newLicense.SaveLicense())
            {
                PrintWrongMessage();
                return false;
            }

            lbRenewedLicenseID.Text = newLicense.LicenseID.ToString();
            return true;
        }

        private bool DeactivateOldLicense()
        {
            oldLicense.IsActive = false;

            if (!oldLicense.SaveLicense())
            {
                PrintWrongMessage();
                return false;
            }

            SetLicenseInfo();
            return true;
        }

        private void RenewLicense()
        {
            if (!CreateNewApplication())
                return;

            if (!CreateNewLicense())
                return;

            if (!DeactivateOldLicense())
                return;
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            RenewLicense();
        }
    }
}

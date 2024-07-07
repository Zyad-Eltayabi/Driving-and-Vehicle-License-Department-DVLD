using DVLD_Business_Layer.Licenses.Applications;
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
    public partial class frmReplacementForDamagedOrLostLicenses : Form
    {
        clsLicenses oldLicense;
        clsApplications renewApplication;

        enum Mode { Damaged = 1, Lost }
        Mode enMode;
        public frmReplacementForDamagedOrLostLicenses()
        {
            InitializeComponent();
            enMode = Mode.Damaged;
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        private bool GetOldLicense()
        {
            oldLicense = clsLicenses.GetLicenseByID(int.Parse(tbFilter.Text));

            if (oldLicense == null)
            {
                clsPublicUtilities.ErrorMessage("There is no license with this number.");
                return false;
            }
            return true;
        }

        private bool ValidateLicense()
        {
            if (!oldLicense.IsActive)
            {
                clsPublicUtilities.WarningMessage("Your license is not active, choose an active license");
                return false;
            }
            return true;
        }

        private void SetLicenseInfo()
        {
            int personID = clsApplications.GetPersonID(oldLicense.ApplicationID);
            ucShowLicense1.LoadLicenseInfo(oldLicense.ApplicationID, personID);
        }

        private void SetNewApplicationInfo()
        {
            lbApplicationDate.Text = DateTime.Now.ToShortDateString();
            switch (enMode)
            {
                case Mode.Damaged:
                    lbApplicationFess.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReplacementforaDamagedDrivingLicens).ToString();
                    break;
                default:
                    lbApplicationFess.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReplacementforaLostDrivingLicense).ToString();
                    break;
            }
            lbCreatedBy.Text = clsLogin.userName;
            lbOldIocalID.Text = oldLicense.LicenseID.ToString();
            btnSave.Enabled = true;
        }

        private void GetLicenseInfo()
        {
            if (!GetOldLicense())
                return;

            if (!ValidateLicense())
                return;

            SetLicenseInfo();

            SetNewApplicationInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (int.Parse(tbFilter.Text) < 1)
            {
                clsPublicUtilities.WarningMessage("Enter a valid license number , it should be greater than 0");
                return;
            }
            GetLicenseInfo();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            enMode = Mode.Damaged;
            lbTitle.Text = " Replacement for Damaged Licenses";
            lbApplicationFess.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReplacementforaDamagedDrivingLicens).ToString();

        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            enMode = Mode.Lost;
            lbTitle.Text = " Replacement for Lost Licenses";
            lbApplicationFess.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReplacementforaLostDrivingLicense).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintWrongMessage()
        {
            clsPublicUtilities.ErrorMessage("failed to save data");
        }
        private bool CreateNewApplication()
        {
            float fees = 0;
            int applicationType = 0;
            switch (enMode)
            {
                case Mode.Damaged:
                    fees = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReplacementforaDamagedDrivingLicens);
                    applicationType = (int)clsApplications.ApplicationTypes.ReplacementforaDamagedDrivingLicens;
                    break;
                default:
                    fees = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.ReplacementforaLostDrivingLicense);
                    applicationType = (int)clsApplications.ApplicationTypes.ReplacementforaLostDrivingLicense;
                    break;
            }
           
            int personID = clsApplications.GetPersonID(oldLicense.ApplicationID);

            renewApplication = new clsApplications(personID, applicationType , (int)clsApplications.ApplicationsStatus.Completed,
                clsLogin.userID, fees);

            if (!renewApplication.SaveApplication())
            {
                PrintWrongMessage();
                return false;
            }

            lbReplacementApplicationID.Text = renewApplication.ApplicationID.ToString();
            return true;
        }

        private bool CreateNewLicense()
        {
            DateTime expDate = DateTime.Now.AddYears(clsLocalLicense.GetDefaultValidityLength(oldLicense.LicenseClass));
            float fees = clsLocalLicense.GetClassFees(oldLicense.LicenseClass);
            string notes = tbNotes.Text.ToString();
            int issueReason = 0;

            switch (enMode)
            {
                case Mode.Damaged:
                    issueReason = (int)clsLicenses.IssueReasons.ReplacementforDamaged;
                    break;
                default:
                    issueReason = (int)clsLicenses.IssueReasons.ReplacementforLost;
                    break;
            }

            clsLicenses newLicense = new clsLicenses(renewApplication.ApplicationID, oldLicense.DriverID,
                oldLicense.LicenseClass, issueReason, clsLogin.userID, expDate, notes, fees);

            if (!newLicense.SaveLicense())
            {
                PrintWrongMessage();
                return false;
            }

            lbReplacmentLicenseID.Text = newLicense.LicenseID.ToString();
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

        private void IssuingANewLicense()
        {
            if (!CreateNewApplication())
                return;

            if (!CreateNewLicense())
                return;

            if (!DeactivateOldLicense())
                return;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IssuingANewLicense();
        }
    }
}

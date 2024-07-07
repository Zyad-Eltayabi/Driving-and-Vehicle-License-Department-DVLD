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
    public partial class frmDetainLicense : Form
    {
        clsLicenses license;
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        private void tbFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
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
            if (!license.IsActive)
            {
                clsPublicUtilities.WarningMessage("Your license is not active, choose an active license");
                return false;
            }

            if (clsDetainedLicenses.IsLicenseDetained(license.LicenseID))
            {
                clsPublicUtilities.WarningMessage("This license is already detained , choose another license.");
                return false;
            }

            return true;
        }

        private void SetLicenseInfo()
        {
            int personID = clsApplications.GetPersonID(license.ApplicationID);
            ucShowLicense1.LoadLicenseInfo(license.ApplicationID, personID);
        }

        private void SetNewApplicationInfo()
        {
            lbDetainDate.Text = DateTime.Now.ToShortDateString();
            lbCreatedBy.Text = clsLogin.userName;
            lbIocalID.Text = license.LicenseID.ToString();
            btnDetain.Enabled = true;
        }

        private void GetLicenseInfo()
        {
            if (!GetLicense())
                return;

            if (!ValidateLicense())
                return;

            SetLicenseInfo();

            SetNewApplicationInfo();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnDetain.Enabled = false;
            if (int.Parse(tbFilter.Text) < 1)
            {
                clsPublicUtilities.WarningMessage("Enter a valid license number , it should be greater than 0");
                return;
            }
            GetLicenseInfo();
        }

        private bool ValidateFees()
        {

            if (string.IsNullOrEmpty(tbFees.Text.ToString()) || int.Parse(tbFees.Text.ToString()) < 1)
            {
                clsPublicUtilities.WarningMessage("Please enter a valid fees");
                return false;
            }
            return true;
        }

        private void PrintWrongMessage()
        {
            clsPublicUtilities.ErrorMessage("failed to save data");
        }

        private void Detain()
        {
            float fees = float.Parse(tbFees.Text.ToString());
            clsDetainedLicenses detainedLicense = new clsDetainedLicenses(license.LicenseID, clsLogin.userID, fees);

            if (detainedLicense.SaveDetain())
            {
                clsPublicUtilities.InformationMessage("license detained successfully");
                lbDetainID.Text = detainedLicense.DetainID.ToString();
                SetLicenseInfo();
                return;
            }
            PrintWrongMessage();
        }

        private void DetainLicense()
        {
            if (!ValidateFees())
                return;

            Detain();

        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            DetainLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

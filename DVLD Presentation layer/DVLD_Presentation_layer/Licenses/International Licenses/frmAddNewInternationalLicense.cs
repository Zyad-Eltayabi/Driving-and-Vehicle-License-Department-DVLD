using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Drivers;
using DVLD_Business_Layer.Licenses.InternationalLicenses;
using DVLD_Business_Layer.Licenses.Local_Licence;
using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Login;
using DVLD_Presentation_layer.Licenses.ApplicationTypes;
using DVLD_Presentation_layer.Licenses.Local_License;
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
using static DVLD_Presentation_layer.People.ucAdd_EditPerson;

namespace DVLD_Presentation_layer.Licenses.International_Licenses
{
    public partial class frmAddNewInternationalLicense : Form
    {
        // start local variables
        private int localLicenseID, licenseClass, localLicenseApplicationID, personID, driverID, internationalLicenseID;
        bool isActive;
        // end local variables

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (!char.IsDigit(e.KeyChar));
        }

        public frmAddNewInternationalLicense()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }


        private bool GetLocalLicense(int licenseID)
        {
            DataTable localLicense = clsLicenses.GetLicenseByLicenseID(licenseID);

            if (localLicense.Rows.Count == 0)
            {
                clsPublicUtilities.WarningMessage("There is no local license with this ID number");
                return false;
            }

            this.localLicenseID = int.Parse(localLicense.Rows[0]["LicenseID"].ToString());
            this.localLicenseApplicationID = int.Parse(localLicense.Rows[0]["ApplicationID"].ToString());
            this.licenseClass = int.Parse(localLicense.Rows[0]["LicenseClass"].ToString());
            this.isActive = Boolean.Parse(localLicense.Rows[0]["IsActive"].ToString());
            this.personID = clsApplications.GetPersonID(this.localLicenseApplicationID);
            this.driverID = int.Parse(localLicense.Rows[0]["DriverID"].ToString());
            return true;
        }

        private void SetLocalLicenseInfo()
        {
            ucShowLicense1.LoadLicenseInfo(this.localLicenseApplicationID, this.personID);
        }

        private bool ValidateLocalLicense()
        {
            if (!this.isActive)
            {
                clsPublicUtilities.ErrorMessage("Sorry , this license is not active , choose another one.");
                return false;
            }

            if (this.licenseClass != (int)clsLocalLicense.ClassName.Class3)
            {
                clsPublicUtilities.ErrorMessage("Sorry , this license is not an Ordinary driving license .");
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void SetApplicationInfo()
        {
            lbLocalLicense.Text = this.localLicenseID.ToString();
            lbFees.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.NewInternationalLicense).ToString();
            lbApplicationDate.Text = lbIsuue.Text = DateTime.Now.ToShortDateString();
            lbExp.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lbCreatedBy.Text = clsLogin.userName;
        }
        private void GetLocalLicenseInfo(int licenseID)
        {
            btnIssue.Enabled = false;

            if (licenseID < 1)
                return;

            if (!GetLocalLicense(licenseID))
                return;

            if (!ValidateLocalLicense())
                return;

            SetLocalLicenseInfo();

            SetApplicationInfo();

            btnIssue.Enabled = true;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            GetLocalLicenseInfo(int.Parse(tbFilter.Text.ToString()));
        }

        private int SaveNewApplication()
        {
            float fees = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.NewInternationalLicense);
            clsApplications applications = new clsApplications(this.personID,
                (int)clsApplications.ApplicationTypes.NewInternationalLicense,
                (int)clsApplications.ApplicationsStatus.Completed, clsLogin.userID, fees);

            if (applications.SaveApplication())
                lbAppID.Text = applications.ApplicationID.ToString();

            return applications.ApplicationID;
        }

        private void NewInternationalLicense(int applicationID)
        {
            int driverID = clsDrivers.GetDriverID(personID);
            DateTime expDate = DateTime.Now.AddYears(1);
            clsInternationalLicenses internationalLicenses = new clsInternationalLicenses(applicationID, driverID,
                 this.localLicenseID, clsLogin.userID, expDate, true);

            if (internationalLicenses.SaveInternationalLicense())
            {
                lbInternationalID.Text = internationalLicenses.InternationalLicenseID.ToString();
                clsPublicUtilities.InformationMessage("Data saved successfully");
                lkShowLicenseInfo.Visible = true;
                this.internationalLicenseID = internationalLicenses.InternationalLicenseID;
                return;
            }
            clsPublicUtilities.ErrorMessage("Sorry,operation was failed");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo showInternationalLicenseInfo = new frmShowInternationalLicenseInfo(16);
            showInternationalLicenseInfo.ShowDialog();
        }

        private void lkShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (btnIssue.Enabled)
            {
                frmShowLicensesHistory showLicensesHistory = new frmShowLicensesHistory(this.personID);
                showLicensesHistory.ShowDialog();
            }
        }

        private void lkShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo showInternationalLicenseInfo = new frmShowInternationalLicenseInfo(this.internationalLicenseID);
            showInternationalLicenseInfo.ShowDialog();
        }

        private bool IsPersonHasAlreadyInternationalLicense()
        {
            if (clsInternationalLicenses.IsPersonHasAnActiveInternationalLicense(this.driverID))
            {
                clsPublicUtilities.WarningMessage("Sorry ,  this person has already an active international license.");
                return false;
            }
            return true;
        }

        private void SaveNewInternationalLicense()
        {
            if (!IsPersonHasAlreadyInternationalLicense())
                return;

            int applicationID = SaveNewApplication();

            if (applicationID == -1)
                return;


            NewInternationalLicense(applicationID);

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            SaveNewInternationalLicense();
            btnIssue.Enabled = false;
        }
    }
}

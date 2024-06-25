using DVLD_Business_Layer.Licenses.Detained_Licenses;
using DVLD_Business_Layer.Licenses.Local_Licence;
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
    public partial class ucShowLicense : UserControl
    {
        public ucShowLicense()
        {
            InitializeComponent();
        }

     
        private void GetLicenseDetails(int applicationID)
        {
            DataTable license = clsLicenses.GetLicense(applicationID);
            lbLicAppID.Text = license.Rows[0]["LicenseID"].ToString();
            lbDriver.Text = license.Rows[0]["DriverID"].ToString();
            lbAppID.Text = license.Rows[0]["ApplicationID"].ToString();
            lbClass.Text = license.Rows[0]["ClassName"].ToString();
            lbIsuue.Text = license.Rows[0]["IssueDate"].ToString();
            lbExp.Text = license.Rows[0]["ExpirationDate"].ToString();
            lbReason.Text = license.Rows[0]["IssueReason"].ToString();
            lbActive.Text = license.Rows[0]["IsActive"].ToString();
            lbNotes.Text = license.Rows[0]["Notes"].ToString();
            int licenseID = int.Parse(license.Rows[0]["LicenseID"].ToString());
            lbDetained.Text = clsDetainedLicenses.IsLicenseDetained(licenseID) ? "Yes" : "No";
        }

        public void LoadLicenseInfo(int applicationID, int personID)
        {
            ucPersonDetails1.LoadPersonDetails(personID);
            GetLicenseDetails(applicationID);
        }
    }
}

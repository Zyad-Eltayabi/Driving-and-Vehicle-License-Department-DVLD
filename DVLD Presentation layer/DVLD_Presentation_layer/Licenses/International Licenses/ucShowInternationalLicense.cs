using DVLD_Business_Layer.Licenses.InternationalLicenses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.Licenses.International_Licenses
{
    public partial class ucShowInternationalLicense : UserControl
    {
        public ucShowInternationalLicense()
        {
            InitializeComponent();
        }

        public void LoadLicenseInfo(int interNationalLicenseID)
        {
            DataTable license = clsInternationalLicenses.GetLicenseByInternationalLicenseID(interNationalLicenseID);

            if (license.Rows.Count == 0)
                return;

            lbName.Text = license.Rows[0]["FullName"].ToString();
            lbIntLicenseID.Text = license.Rows[0]["InternationalLicenseID"].ToString();
            lbIocalID.Text = license.Rows[0]["IssuedUsingLocalLicenseID"].ToString();
            lbNational.Text = license.Rows[0]["NationalNo"].ToString();
            lbGendor.Text = license.Rows[0]["Gendor"].ToString();
            lbIssueDate.Text = license.Rows[0]["IssueDate"].ToString();
            lbApplicationID.Text = license.Rows[0]["ApplicationID"].ToString();
            lbIsActive.Text = license.Rows[0]["IsActive"].ToString();
            lbDateOfBirth.Text = license.Rows[0]["DateOfBirth"].ToString();
            lbDriverID.Text = license.Rows[0]["DriverID"].ToString();
            lbExpirationDate.Text = license.Rows[0]["ExpirationDate"].ToString();

            if (!string.IsNullOrEmpty(license.Rows[0]["ImagePath"].ToString()))
                picPerson.Image = Image.FromFile($@"C:\DVLD-People-Images\{license.Rows[0]["ImagePath"].ToString()}");
        }
    }
}

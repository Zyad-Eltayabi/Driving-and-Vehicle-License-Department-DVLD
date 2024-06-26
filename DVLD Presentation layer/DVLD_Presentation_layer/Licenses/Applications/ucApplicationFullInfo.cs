using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Login;
using DVLD_Business_Layer.Users;
using DVLD_Presentation_layer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.Licenses.Applications
{
    public partial class ucApplicationFullInfo : UserControl
    {
        public ucApplicationFullInfo()
        {
            InitializeComponent();
        }
        private int personID;

        private void LoadLicenseData(int localDrivingAppID)
        {
            DataTable localLicense = clsLocalLicense.GetLocalDrivingLicense(localDrivingAppID);
            if (localLicense.Rows.Count > 0)
            {
                lbID.Text = localLicense.Rows[0]["L.D.L.AppID"].ToString();
                lbClass.Text = localLicense.Rows[0]["ClassName"].ToString();
                lbTest.Text = localLicense.Rows[0]["PassedTests"].ToString();
            }
        }

       private string GetUserName(int applicationID)
        {
            int userID = clsApplications.GetCreatedByUserID(applicationID);
            return clsUsers.GetUserName(userID);
        }

        private void LoadApplicationData(int applicationID)
        {
            DataTable application = clsApplications.GetApplicationInfo(applicationID);
            if (application.Rows.Count > 0)
            {
                lbAppID.Text = application.Rows[0]["ApplicationID"].ToString();
                lbType.Text = application.Rows[0]["ApplicationTypeTitle"].ToString();
                lbFees.Text = application.Rows[0]["ApplicationFees"].ToString();
                lbStatus.Text = application.Rows[0]["ApplicationStatus"].ToString();
                lbFullName.Text = application.Rows[0]["FullName"].ToString();
                lbDate.Text = application.Rows[0]["ApplicationDate"].ToString();
                lbUserName.Text = GetUserName(applicationID);
                personID = int.Parse(application.Rows[0]["ApplicantPersonID"].ToString());
            }
        }
        public void LoadTestData(int localDrivingAppID, int applicationID)
        {
            LoadLicenseData(localDrivingAppID);
            LoadApplicationData(applicationID);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            frmPersonDetails personDetails = new frmPersonDetails(this.personID);
            personDetails.ShowDialog();
        }
    }
}

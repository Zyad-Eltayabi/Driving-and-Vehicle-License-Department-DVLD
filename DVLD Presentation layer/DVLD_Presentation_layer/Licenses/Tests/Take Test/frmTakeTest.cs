using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Licenses.Tests;
using DVLD_Business_Layer.Tests;
using DVLD_Presentation_layer.Licenses.Tests.VisionTest;
using DVLD_Presentation_layer.Properties;
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
using static DVLD_Business_Layer.Tests.clsTestTypes;

namespace DVLD_Presentation_layer.Licenses.Tests.Take_Test
{
    public partial class frmTakeTest : Form
    {
        private int localDrivingAppID;
        private int AppointmentID;
        private clsTestTypes.TestsType enTestType { get; set; }

        public frmTakeTest(int localDrivingAppID, int AppointmentID, TestsType enTestType)
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            this.localDrivingAppID = localDrivingAppID;
            this.AppointmentID = AppointmentID;
            this.enTestType = enTestType;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            LoadTestInfo();
        }

        private void LoadTestInfo()
        {
            SetTestHeader();
            SetLicenseInfo();
            SetTestInfo();
        }

        private void SetTestHeader()
        {
            switch (enTestType)
            {
                case clsTestTypes.TestsType.VisionTest:
                    picTest.Image = Resources.vision;
                    break;
                case clsTestTypes.TestsType.WrittenTest:
                    picTest.Image = Resources.written;
                    break;
                case clsTestTypes.TestsType.StreetTest:
                    picTest.Image = Resources.street_light;
                    break;
            }
        }

        private void SetLicenseInfo()
        {
            DataTable localLicense = clsLocalLicense.GetLocalDrivingLicense(localDrivingAppID);
            if (localLicense.Rows.Count > 0)
            {
                lbID.Text = localLicense.Rows[0]["L.D.L.AppID"].ToString();
                lbClass.Text = localLicense.Rows[0]["ClassName"].ToString();
                lbFullName.Text = localLicense.Rows[0]["FullName"].ToString();
            }
        }

        private void SetTestInfo()
        {

            lbtrials.Text = frmTest.trials.ToString();
            float testFees = clsTestTypes.GetTestFees((int)enTestType);
            lbFees.Text = testFees.ToString();
            lbDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTestResult()
        {
            if (clsTestAppointments.LockTestAppointment(this.AppointmentID))
            {
                bool testResult = (rdPass.Checked) ? true : false;
                if (clsTests.UpdateTest(this.AppointmentID, testResult, tbNotes.Text.ToString()))
                {
                    clsPublicUtilities.InformationMessage("Data saved successfully");
                    return;
                }
            }

            clsPublicUtilities.ErrorMessage("Date didn't saved successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetTestResult();
        }
    }
}

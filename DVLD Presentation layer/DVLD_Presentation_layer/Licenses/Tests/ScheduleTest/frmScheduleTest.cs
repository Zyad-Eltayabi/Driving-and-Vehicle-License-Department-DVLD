using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Licenses.Tests;
using DVLD_Business_Layer.Login;
using DVLD_Business_Layer.Tests;
using DVLD_Presentation_layer.Licenses.ApplicationTypes;
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

namespace DVLD_Presentation_layer.Licenses.Tests.ScheduleTest
{
    public partial class frmScheduleTest : Form
    {
        private int localDrivingAppID;
        private clsTestTypes.TestsType enTestType { get; set; }

        private bool editMode = false;
        private bool isLocked = false;
        private int testAppointmentID { get; set; }
        private DateTime testDate { get; set; }

        public frmScheduleTest(int localDrivingAppID, clsTestTypes.TestsType enTestType)
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            this.localDrivingAppID = localDrivingAppID;
            this.enTestType = enTestType;
        }

        public frmScheduleTest(int localDrivingAppID, clsTestTypes.TestsType enTestType,
            int testAppointmentID, DateTime testDate, bool isLocked)
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            this.localDrivingAppID = localDrivingAppID;
            this.enTestType = enTestType;

            this.editMode = true;
            this.testAppointmentID = testAppointmentID;
            this.isLocked = isLocked;
            this.testDate = testDate;
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            LoadTestInformation();
        }


        private void LoadTestInformation()
        {
            SetTestHeader();
            SetLicenseInfo();
            SetTestInfo();
            SetRetakeTestInfo();
            CheckEditMode();
        }

        private void LockTest()
        {
            lbTestTitle.Text = "Edit Test Date";
            gbLicenseInfo.Enabled = false;
            gbRetake.Enabled = false;
            btnSave.Enabled = false;
            clsPublicUtilities.WarningMessage("this person already taken this test , you can not edit it");
        }
        private void CheckEditMode()
        {
            if (editMode)
            {
                date.Value = this.testDate;

                if (this.isLocked)
                    LockTest();
                else
                    gbRetake.Enabled = false;
            }
        }

        private void SetTestHeader()
        {
            switch (enTestType)
            {
                case clsTestTypes.TestsType.VisionTest:
                    picTest.Image = Resources.vision;
                    lbTestTitle.Text = "Vision Test";
                    break;
                case clsTestTypes.TestsType.WrittenTest:
                    picTest.Image = Resources.written;
                    lbTestTitle.Text = "Written Test";
                    break;
                case clsTestTypes.TestsType.StreetTest:
                    picTest.Image = Resources.street_light;
                    lbTestTitle.Text = "Street Test";
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
            if(!editMode)
                date.MinDate = DateTime.Now;
            lbtrials.Text = frmTest.trials.ToString();
            float testFees = clsTestTypes.GetTestFees((int)enTestType);
            lbFees.Text = testFees.ToString();
        }

        private void SetRetakeTestInfo()
        {
            if (frmTest.trials > 0 && !editMode)
            {
                gbRetake.Enabled = true;
                float retakeTestFees = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.RetakeTest);
                lbRetakeFees.Text = retakeTestFees.ToString();
                lbTotalFees.Text = (retakeTestFees + float.Parse(lbFees.Text.ToString())).ToString();
                switch (enTestType)
                {
                    case clsTestTypes.TestsType.VisionTest:
                        lbTestTitle.Text = "Retake Vision Test";
                        break;
                    case clsTestTypes.TestsType.WrittenTest:
                        lbTestTitle.Text = "Retake Written Test";
                        break;
                    case clsTestTypes.TestsType.StreetTest:
                        lbTestTitle.Text = "Retake Street Test";
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTestAppointment(ref clsTests test)
        {
            test.appointments.TestTypeID = (int)enTestType;
            test.appointments.LocalDrivingLicenseApplicationID = this.localDrivingAppID;
            test.appointments.AppointmentDate = date.Value;
            test.appointments.PaidFees = float.Parse(lbFees.Text.ToString());
            test.appointments.CreatedByUserID = clsLogin.userID;
            test.appointments.IsLocked = false;
        }

        private void SetTest(ref clsTests test)
        {
            test.TestResult = false;
            test.CreatedByUserID = clsLogin.userID;
        }

        private void AddNewTest()
        {
            clsTests test = new clsTests();
            SetTestAppointment(ref test);
            SetTest(ref test);

            if (test.SaveTest())
            {
                frmTest.trials++;
                clsPublicUtilities.InformationMessage("Data Saved Successfully");
            }
        }

        private void UpdateAppointmentDate()
        {
            this.testDate = date.Value;
            if (clsTestAppointments.UpdateDate(this.testAppointmentID, this.testDate))
            {
                clsPublicUtilities.InformationMessage("Date updated successfully");
            }
            else
                clsPublicUtilities.ErrorMessage(@"Date didn't updated successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editMode)
            {
                UpdateAppointmentDate();
                return;
            }
            AddNewTest();
        }




    }
}

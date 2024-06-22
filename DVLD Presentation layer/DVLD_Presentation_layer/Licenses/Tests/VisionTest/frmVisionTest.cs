using DVLD_Business_Layer.Licenses.Tests;
using DVLD_Business_Layer.Tests;
using DVLD_Presentation_layer.Licenses.Tests.ScheduleTest;
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

namespace DVLD_Presentation_layer.Licenses.Tests.VisionTest
{
    public partial class frmVisionTest : Form
    {
        private int localDrivingAppID, applicationID;
        public static int trials = 0;
        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            ucApplicationFullInfo1.LoadTestData(localDrivingAppID, applicationID);
            GetAppointmentsDetails();
        }


        private void GetAppointmentsDetails()
        {
            dgvAppointments.DataSource = clsTestAppointments.GetAppointmentDetails(this.localDrivingAppID);
            lbRecords.Text = dgvAppointments.RowCount.ToString();
            trials = int.Parse(dgvAppointments.RowCount.ToString());
        }

        private bool CheckPreviousTest()
        {
            DataTable appointment = clsTestAppointments.GetAppointmentFullDetails(localDrivingAppID,
                (int)clsTestTypes.TestsType.VisionTest);

            if (appointment.Rows.Count == 0)
                return true;

            bool isLocked = Convert.ToBoolean(appointment.Rows[0]["IsLocked"]);

            if (!isLocked)
            {
                clsPublicUtilities.ErrorMessage("Person have  already an active appointment for this test," +
                                                 " you can not add new appointment");
                return false;
            }

            bool result = Convert.ToBoolean(appointment.Rows[0]["TestResult"]);

            if (result)
            {
                clsPublicUtilities.ErrorMessage("Person already passed this test , you can not add new appointment");
                return false;
            }

            return true;
        }

        private void btnAddNewAppointment_Click(object sender, EventArgs e)
        {
            if (!CheckPreviousTest())
                return;

            frmScheduleTest scheduleTest = new frmScheduleTest(localDrivingAppID, clsTestTypes.TestsType.VisionTest);
            scheduleTest.ShowDialog();
            GetAppointmentsDetails();
        }

        public frmVisionTest(int localDrivingAppID, int applicationID)
        {
            InitializeComponent();
            this.localDrivingAppID = localDrivingAppID;
            this.applicationID = applicationID;
            clsPublicUtilities.CenterForm(this);
        }
    }
}

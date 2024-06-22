using DVLD_Database_Layer.Licenses.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Licenses.Tests
{
    public class clsTests
    {
        public int TestID { get; set; }
        public int CreatedByUserID { get; set; }
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public Mode enMode { get; set; }

        public clsTestAppointments appointments { get; set; }

        public enum Mode
        {
            New = 1,
            Update
        }
        public clsTests()
        {
            TestID = 0;
            CreatedByUserID = 0;
            TestResult = false;
            Notes = "";
            enMode = Mode.New;
            appointments = new clsTestAppointments();
        }

        private bool AddNewTest()
        {
            if (this.appointments.SaveAppointment())
            {
                this.TestID = clsTestsDB.AddNewTest(this.appointments.TestAppointmentID,CreatedByUserID,TestResult,Notes);
                return this.TestID != -1;
            }
            return false;
        }

        public bool SaveTest()
        {
            switch (enMode)
            {
                case Mode.New:
                    enMode = Mode.Update;
                    return AddNewTest();
                default:
                    return false;
            }
        }
    }
}

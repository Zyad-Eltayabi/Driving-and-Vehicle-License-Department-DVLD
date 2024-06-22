using DVLD_Database_Layer.Tests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Tests
{
    public class clsTestTypes
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }

        public clsTestTypes()
        {
            this.TestTypeID = -1;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
        }

        public enum TestsType
        {
            VisionTest = 1,
            WrittenTest,
            StreetTest
        }

        private clsTestTypes(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            TestTypeID = testTypeID;
            TestTypeTitle = testTypeTitle;
            TestTypeDescription = testTypeDescription;
            TestTypeFees = testTypeFees;
        }

        public static DataTable GetTestTypes()
        {
            return clsTestTypesDB.GetTestTypes();
        }

        public bool UpdateTestType()
        {
            return clsTestTypesDB.UpdateTestType(this.TestTypeID, this.TestTypeTitle, this.TestTypeDescription,
                this.TestTypeFees);
        }

        public static clsTestTypes GetTestType(int testTypeID)
        {
            string testTypeTitle = "";
            string testTypeDescription = "";
            float testTypeFees = 0;

            if(clsTestTypesDB.GetTestType(testTypeID,ref testTypeTitle,ref testTypeDescription,ref testTypeFees))
                return new clsTestTypes(testTypeID, testTypeTitle, testTypeDescription, testTypeFees);

            return null;
        }

        public static float GetTestFees(int testTypeID)
        {
            return clsTestTypesDB.GetTestFees(testTypeID);
        }
    }
}

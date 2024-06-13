using DVLD_Business_Layer.Tests;
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
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation_layer.Licenses.Tests
{
    public partial class frmUpdateTestType : Form
    {
        clsTestTypes testType {  get; set; }    
        public frmUpdateTestType(int testTypeID)
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            testType = clsTestTypes.GetTestType(testTypeID);
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            LoadTestDetails();
        }

        private void LoadTestDetails()
        {
            lbID.Text = testType.TestTypeID.ToString();
            tbTitle.Text = testType.TestTypeTitle.ToString();
            tbDesc.Text = testType.TestTypeDescription.ToString();
            nudFees.Value = decimal.Parse(testType.TestTypeFees.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AssignNewValues();
            SaveUpdate();
        }

        private void AssignNewValues()
        {
            testType.TestTypeTitle = tbTitle.Text.ToString();
            testType.TestTypeFees = float.Parse(nudFees.Value.ToString());
            testType.TestTypeDescription = tbDesc.Text.ToString();
        }

        private void SaveUpdate()
        {
            if (testType.UpdateTestType())
            {
                clsPublicUtilities.InformationMessage("Data saved successfully");
                return;
            }

            clsPublicUtilities.ErrorMessage("failed update the data");
        }

    }
}

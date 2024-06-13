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

namespace DVLD_Presentation_layer.Licenses.ApplicationTypes
{
    public partial class frmUpdateApplicationType : Form
    {
        private clsApplicationTypes application { get; set; }
        public frmUpdateApplicationType(int applicationTypeID)
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            application = clsApplicationTypes.GetApplicationType(applicationTypeID);
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            LoadApplicationDetails();
        }

        private void LoadApplicationDetails()
        {
            lbID.Text = application.ApplicationTypeID.ToString();
            tbTitle.Text = application.ApplicationTypeTitle.ToString();
            nudFees.Value = decimal.Parse(application.ApplicationFees.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AssignNewValues();
            SaveUpdate();
        }

        private void AssignNewValues()
        {
            application.ApplicationTypeTitle = tbTitle.Text.ToString();
            application.ApplicationFees = float.Parse(nudFees.Value.ToString());
        }

        private void SaveUpdate()
        {
            if (application.UpdateApplicationType())
            {
                clsPublicUtilities.InformationMessage("Data saved successfully");
                return;
            }

            clsPublicUtilities.ErrorMessage("failed update the data");
        }
    }
}

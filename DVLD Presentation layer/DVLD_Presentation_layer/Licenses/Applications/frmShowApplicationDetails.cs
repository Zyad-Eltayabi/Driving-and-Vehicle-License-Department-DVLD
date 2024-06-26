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

namespace DVLD_Presentation_layer.Licenses.Applications
{
    public partial class frmShowApplicationDetails : Form
    {
        private int localDrivingAppID, applicationID;
        public frmShowApplicationDetails(int localDrivingAppID, int applicationID)
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            this.localDrivingAppID = localDrivingAppID;
            this.applicationID = applicationID;
        }

        private void frmShowApplicationDetails_Load(object sender, EventArgs e)
        {
            ucApplicationFullInfo1.LoadTestData(this.localDrivingAppID,this.applicationID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

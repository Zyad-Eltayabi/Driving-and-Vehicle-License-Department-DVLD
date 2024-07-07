using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.Licenses.Local_License
{
    public partial class frmShowLicense : Form
    {
        private int applicationID, personID;

        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            ucShowLicense1.LoadLicenseInfo(applicationID, personID);
        }

        public frmShowLicense(int applicationID,int personID)
        {
            InitializeComponent();
            this.applicationID = applicationID;
            this.personID = personID;
        }
    }
}

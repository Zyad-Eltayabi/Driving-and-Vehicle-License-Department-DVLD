using DVLD_Business_Layer.Licenses.Drivers;
using DVLD_Business_Layer.Licenses.InternationalLicenses;
using DVLD_Business_Layer.Licenses.Local_Licence;
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
    public partial class ucDriverLicenses : UserControl
    {
        public ucDriverLicenses()
        {
            InitializeComponent();
        }

        public void LoadLicenses(int personID)
        {
            int driverID = clsDrivers.GetDriverID(personID);

            if (driverID == -1)
                return;

            GetLocalLicenses(driverID);
            GetInternationalLicenses(driverID);
        }

        private void GetLocalLicenses(int driverID)
        {
            dgvLocal.DataSource = clsLicenses.GetLicensesByDriverID(driverID);
            lbLocalRecords.Text = dgvLocal.RowCount.ToString();
        }

        private void GetInternationalLicenses(int driverID)
        {
            dgvInternational.DataSource = clsInternationalLicenses.GetLicensesByDriverID(driverID);
            lbInternationalRecords.Text = dgvInternational.RowCount.ToString();
        }
    }
}

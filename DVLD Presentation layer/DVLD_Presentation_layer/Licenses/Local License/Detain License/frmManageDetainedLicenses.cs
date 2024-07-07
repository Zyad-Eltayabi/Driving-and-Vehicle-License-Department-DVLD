using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Detained_Licenses;
using DVLD_Business_Layer.Licenses.InternationalLicenses;
using DVLD_Business_Layer.Licenses.Local_Licence;
using DVLD_Presentation_layer.People;
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

namespace DVLD_Presentation_layer.Licenses.Local_License
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            GetDetainedLicenses();
        }

        private void GetDetainedLicenses()
        {
            dgvLicenses.DataSource = clsDetainedLicenses.GetDetainedLicenses();
            lbRecords.Text = dgvLicenses.RowCount.ToString();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense detainLicense = new frmDetainLicense();
            detainLicense.ShowDialog();
            GetDetainedLicenses();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenses releaseDetainedLicenses = new frmReleaseDetainedLicenses();
            releaseDetainedLicenses.ShowDialog();
            GetDetainedLicenses();
        }

        // Handle Filter

        private void ShowClearTextButton()
        {
            if (string.IsNullOrEmpty(tbFilter.Text.ToString()))
                btnClearTxt.Visible = false;
            else
                btnClearTxt.Visible = true;

            btnClearTxt.BringToFront();

            tbFilter.Focus();
        }

        private void SetFilter(string colName, string colValue)
        {
            DataTable Licenses = clsDetainedLicenses.GetDetainedLicenses();
            DataView dv = new DataView();
            dv = Licenses.DefaultView;
            dv.RowFilter = string.Format(@"CONVERT([{0}], System.String) LIKE '{1}%'", colName, colValue);
            dgvLicenses.DataSource = dv;
        }

        private void FilterDataGridTable()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    SetFilter("LicenseID", tbFilter.Text.ToString());
                    break;
                case 2:
                    SetFilter("FullName", tbFilter.Text.ToString());
                    break;
                default:
                    dgvLicenses.DataSource = clsDetainedLicenses.GetDetainedLicenses();
                    break;
            }
        }

        private void cbFilter_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
                tbFilter.Visible = false;
            else
                tbFilter.Visible = true;

            tbFilter.Clear();
        }
        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    e.Handled = (!char.IsDigit(e.KeyChar));
                    break;
                default:
                    e.Handled = (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ');
                    break;
            }
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            ShowClearTextButton();
            FilterDataGridTable();
        }

        private void btnClearTxt_Click(object sender, EventArgs e)
        {
            tbFilter.Clear();
        }

        private int GetApplicationID()
        {
            int licenseID = int.Parse(dgvLicenses.SelectedRows[0].Cells["LicenseID"].Value.ToString());
            DataTable license = clsLicenses.GetLicenseByLicenseID(licenseID);
            int applicationID = int.Parse(license.Rows[0]["ApplicationID"].ToString());
            return applicationID;
        }

        private int GetPersonID()
        {
            int personID = clsApplications.GetPersonID(GetApplicationID());
            return personID;
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonDetails personDetails = new frmPersonDetails(GetPersonID());
            personDetails.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicense showLicense = new frmShowLicense(GetApplicationID(), GetPersonID());
            showLicense.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicensesHistory showLicensesHistory = new frmShowLicensesHistory(GetPersonID());
            showLicensesHistory.ShowDialog();
        }

        private bool IsReleased()
        {
            if (Boolean.Parse(dgvLicenses.SelectedRows[0].Cells["IsReleased"].Value.ToString()))
            {
                clsPublicUtilities.WarningMessage("This license is already released");
                return true;
            }
            return false;
        }

        private int GetDetainedLicenseID()
        {
            return int.Parse(dgvLicenses.SelectedRows[0].Cells["LicenseID"].Value.ToString());
        }

        private void OpenReleaseDetainedLicenseForm()
        {
            frmReleaseDetainedLicenses releaseDetainedLicenses = new frmReleaseDetainedLicenses(GetDetainedLicenseID());
            releaseDetainedLicenses.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsReleased())
                return;

            OpenReleaseDetainedLicenseForm();

            GetDetainedLicenses();
        }
    }
}

using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.InternationalLicenses;
using DVLD_Business_Layer.Licenses.Local_License;
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
    public partial class frmActiveLicensesList : Form
    {
        public frmActiveLicensesList()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void GetActiveLicenses()
        {
            dgvLicenses.DataSource = clsLocalLicense.GetActiveLicenses();
            lbRecords.Text = dgvLicenses.RowCount.ToString();
        }

        private void frmActiveLicensesList_Load(object sender, EventArgs e)
        {
            GetActiveLicenses();
        }

        private int GetApplicationID()
        {
            int applicationID = int.Parse(dgvLicenses.SelectedRows[0].Cells["ApplicationID"].Value.ToString());
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
            frmShowLicensesHistory frmShowLicensesHistory = new frmShowLicensesHistory(GetPersonID());
            frmShowLicensesHistory.ShowDialog();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
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
                    e.Handled = (!char.IsLetterOrDigit(e.KeyChar));
                    break;
            }
        }

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
            DataTable Licenses = clsLocalLicense.GetActiveLicenses();
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
                    dgvLicenses.DataSource = clsLocalLicense.GetActiveLicenses();
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
    }
}

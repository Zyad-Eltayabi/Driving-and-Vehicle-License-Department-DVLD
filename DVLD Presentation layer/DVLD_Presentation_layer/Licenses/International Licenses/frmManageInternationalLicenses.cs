using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Drivers;
using DVLD_Business_Layer.Licenses.InternationalLicenses;
using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Presentation_layer.Licenses.Local_License;
using DVLD_Presentation_layer.People;
using DVLD_Presentation_layer.Users;
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

namespace DVLD_Presentation_layer.Licenses.International_Licenses
{
    public partial class frmManageInternationalLicenses : Form
    {
        public frmManageInternationalLicenses()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void GetInternationalLicenses()
        {
            dgvLicenses.DataSource = clsInternationalLicenses.GetInternationalLicenses();
            lbRecords.Text = dgvLicenses.RowCount.ToString();
        }

        private void frmManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            GetInternationalLicenses();
        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense addNewInternationalLicense = new frmAddNewInternationalLicense();
            addNewInternationalLicense.ShowDialog();
            GetInternationalLicenses();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverID = int.Parse(dgvLicenses.SelectedRows[0].Cells["ApplicationID"].Value.ToString());
            int personID = clsApplications.GetPersonID(driverID);
            frmPersonDetails personDetails = new frmPersonDetails(personID);
            personDetails.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int internationalLicenseID = int.Parse(dgvLicenses.SelectedRows[0].Cells["InternationalLicenseID"].Value.ToString());
            frmShowInternationalLicenseInfo internationalLicenseInfo = new frmShowInternationalLicenseInfo(internationalLicenseID);   
            internationalLicenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverID = int.Parse(dgvLicenses.SelectedRows[0].Cells["ApplicationID"].Value.ToString());
            int personID = clsApplications.GetPersonID(driverID);
            frmShowLicensesHistory showLicensesHistory = new frmShowLicensesHistory(personID);
            showLicensesHistory.ShowDialog();

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
            DataTable Licenses = clsInternationalLicenses.GetInternationalLicenses();
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
                    SetFilter("InternationalLicenseID", tbFilter.Text.ToString());
                    break;
                case 2:
                    SetFilter("FullName", tbFilter.Text.ToString());
                    break;
                default:
                    dgvLicenses.DataSource = clsInternationalLicenses.GetInternationalLicenses();
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

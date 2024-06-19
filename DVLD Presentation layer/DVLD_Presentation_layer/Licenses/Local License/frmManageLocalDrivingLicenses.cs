using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Users;
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
    public partial class frmManageLocalDrivingLicenses : Form
    {
        public frmManageLocalDrivingLicenses()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplication licenseApplication = new frmLocalDrivingLicenseApplication();
            licenseApplication.ShowDialog();
        }

        private void frmListLocalDrivingLicenses_Load(object sender, EventArgs e)
        {
            GetLocalLicenses();
        }

        private void GetLocalLicenses()
        {
            dgvLicenses.DataSource = clsLocalLicense.GetLocalDrivingLicenses();
            lbRecords.Text = dgvLicenses.RowCount.ToString();
        }

        // <========= handle filter =========>
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
                tbFilter.Visible = false;
            else tbFilter.Visible = true;
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
            DataTable localLicenses = clsLocalLicense.GetLocalDrivingLicenses();
            DataView dv = new DataView();
            dv = localLicenses.DefaultView;
            dv.RowFilter = string.Format(@"CONVERT([{0}], System.String) LIKE '{1}%'", colName, colValue);
            dgvLicenses.DataSource = dv;
        }

        private void FilterDataGridTable()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    SetFilter("L.D.L.AppID", tbFilter.Text.ToString());
                    break;
                case 2:
                    SetFilter("NationalNo", tbFilter.Text.ToString());
                    break;
                case 3:
                    SetFilter("FullName", tbFilter.Text.ToString());
                    break;
                case 4:
                    SetFilter("ApplicationStatus", tbFilter.Text.ToString());
                    break;
                default:
                    dgvLicenses.DataSource = clsLocalLicense.GetLocalDrivingLicenses();
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
            tbFilter.Text = string.Empty;
        }
    }
}

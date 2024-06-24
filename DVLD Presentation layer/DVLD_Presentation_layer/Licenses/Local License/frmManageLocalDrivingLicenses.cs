using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Tests;
using DVLD_Business_Layer.Users;
using DVLD_Presentation_layer.Licenses.Tests.VisionTest;
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
            if (dgvLicenses.Rows.Count > 0)
            {
                dgvLicenses.Rows[0].Selected = false;
                SetDefaultSettingsInContextMenu(false);
            }
        }

        private void GetLocalLicenses()
        {
            dgvLicenses.DataSource = clsLocalLicense.GetLocalDrivingLicenses();
            lbRecords.Text = dgvLicenses.RowCount.ToString();
        }

        // <========= handle filter =========>
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
                tbFilter.Visible = false;
            else
                tbFilter.Visible = true;
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

        // Handle Show licenses 
        private void CheckPassedTest()
        {
            string TestResult = dgvLicenses.SelectedRows[0].Cells["PassedTests"].Value.ToString();
            switch (TestResult)
            {
                case "0":
                    visionTestToolStripMenuItem.Enabled = true;
                    writtenTestToolStripMenuItem.Enabled = false;
                    streetTestToolStripMenuItem.Enabled = false;
                    break;
                case "1":
                    visionTestToolStripMenuItem.Enabled = false;
                    writtenTestToolStripMenuItem.Enabled = true;
                    streetTestToolStripMenuItem.Enabled = false;
                    break;
                case "2":
                    visionTestToolStripMenuItem.Enabled = false;
                    writtenTestToolStripMenuItem.Enabled = false;
                    streetTestToolStripMenuItem.Enabled = true;
                    break;
                default:
                    takeTestsToolStripMenuItem.Enabled = false;
                    break;
            }
        }

        private void CheckCompleted()
        {
            string status = dgvLicenses.SelectedRows[0].Cells["ApplicationStatus"].Value.ToString();
            string TestResult = dgvLicenses.SelectedRows[0].Cells["PassedTests"].Value.ToString();

            switch (status)
            {
                case "completed":
                    issueToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = false;
                    cancelToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                    break;
                case "new":
                    showLicenseToolStripMenuItem.Enabled = false;
                    deleteToolStripMenuItem.Enabled = true;
                    cancelToolStripMenuItem.Enabled = true;

                    if (TestResult == "3")
                        issueToolStripMenuItem.Enabled = true;
                    else
                        issueToolStripMenuItem.Enabled = false;

                    break;
                default:
                    SetDefaultSettingsInContextMenu(false);
                    showDetailsToolStripMenuItem.Enabled = true;
                    break;
            }

        }

        private void SetDefaultSettingsInContextMenu(bool mode)
        {
            foreach (var item in guna2ContextMenuStrip1.Items)
            {
                try
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)item;
                    toolStripMenuItem.Enabled = mode;
                }
                catch (Exception)
                {

                }
            }
        }

        private void dgvLicenses_MouseClick(object sender, MouseEventArgs e)
        {
            if (dgvLicenses.SelectedRows.Count > 0)
            {
                SetDefaultSettingsInContextMenu(true);
                CheckPassedTest();
                CheckCompleted();
                return;
            }
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDrivingAppID = int.Parse(dgvLicenses.SelectedRows[0].Cells["L.D.L.AppID"].Value.ToString());
            int applicationID = int.Parse(dgvLicenses.SelectedRows[0].Cells["ApplicationID"].Value.ToString());

            frmTest visionTest = new frmTest(localDrivingAppID, applicationID,clsTestTypes.TestsType.VisionTest);
            visionTest.ShowDialog();
            GetLocalLicenses();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDrivingAppID = int.Parse(dgvLicenses.SelectedRows[0].Cells["L.D.L.AppID"].Value.ToString());
            int applicationID = int.Parse(dgvLicenses.SelectedRows[0].Cells["ApplicationID"].Value.ToString());

            frmTest writtenTest = new frmTest(localDrivingAppID, applicationID, clsTestTypes.TestsType.WrittenTest);
            writtenTest.ShowDialog();
            GetLocalLicenses();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int localDrivingAppID = int.Parse(dgvLicenses.SelectedRows[0].Cells["L.D.L.AppID"].Value.ToString());
            int applicationID = int.Parse(dgvLicenses.SelectedRows[0].Cells["ApplicationID"].Value.ToString());

            frmTest streetTest = new frmTest(localDrivingAppID, applicationID, clsTestTypes.TestsType.StreetTest);
            streetTest.ShowDialog();
            GetLocalLicenses();
        }
    }
}


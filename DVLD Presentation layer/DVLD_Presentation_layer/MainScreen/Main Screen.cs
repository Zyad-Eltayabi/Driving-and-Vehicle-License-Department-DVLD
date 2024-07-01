using DVLD_Business_Layer.Login;
using DVLD_Presentation_layer.Drivers;
using DVLD_Presentation_layer.Licenses.ApplicationTypes;
using DVLD_Presentation_layer.Licenses.International_Licenses;
using DVLD_Presentation_layer.Licenses.Local_License;
using DVLD_Presentation_layer.Licenses.Tests;
using DVLD_Presentation_layer.People;
using DVLD_Presentation_layer.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace DVLD_Presentation_layer.MainScreen
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 1);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            frmAddNewInternationalLicense addNewInternationalLicense = new frmAddNewInternationalLicense();
            addNewInternationalLicense.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsPeople_Click(object sender, EventArgs e)
        {
            frmMangePeople frmMangePeople = new frmMangePeople();
            frmMangePeople.ShowDialog();
        }

        private void tsUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frmShowUserDetails = new frmShowUserDetails(clsLogin.userID);
            frmShowUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePassword = new frmChangePassword(clsLogin.userID);
            frmChangePassword.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsManageApplicationsTypes_Click(object sender, EventArgs e)
        {
            frmApplicationTypes frmApplicationTypes = new frmApplicationTypes();
            frmApplicationTypes.ShowDialog();
        }

        private void tsManageTestTypes_Click(object sender, EventArgs e)
        {
            frmTestType testTypes = new frmTestType();
            testTypes.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplication frmLocalDriving = new frmLocalDrivingLicenseApplication();
            frmLocalDriving.ShowDialog();
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDrivingLicenses frmListLocalDrivingLicenses = new frmManageLocalDrivingLicenses();
            frmListLocalDrivingLicenses.ShowDialog();
        }

        private void tsDrivers_Click(object sender, EventArgs e)
        {
            frmDrivers drivers = new frmDrivers();
            drivers.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationalLicense addNewInternationalLicense = new frmAddNewInternationalLicense();
            addNewInternationalLicense.ShowDialog();
        }
    }
}

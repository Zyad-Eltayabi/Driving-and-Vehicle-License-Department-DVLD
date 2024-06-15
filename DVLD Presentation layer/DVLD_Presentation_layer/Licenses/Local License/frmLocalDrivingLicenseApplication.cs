using DVLD_Business_Layer.Licenses.Applications;
using DVLD_Business_Layer.Licenses.Local_License;
using DVLD_Business_Layer.Login;
using DVLD_Presentation_layer.Licenses.ApplicationTypes;
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
    public partial class frmLocalDrivingLicenseApplication : Form
    {
        clsLocalLicense localLicense { get; set; }

        public frmLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            ucAddUserWithFilter.personID = -1;
            localLicense = new clsLocalLicense();
        }

        private void frmLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {
            SetDefaultSettingsForApplicationInfo();
        }

        private void SetDefaultSettingsForApplicationInfo()
        {
            lbDate.Text = DateTime.Now.ToShortDateString();
            lbUser.Text = clsLogin.userName;
            lbFees.Text = clsApplicationTypes.GetFees(clsApplications.ApplicationTypes.NewLocalDrivingLicenseService).ToString();
        }

        private bool IsPersonFound()
        {
            if (ucAddUserWithFilter.personID == -1)
            {
                clsPublicUtilities.ErrorMessage("Please choose the person");
                return false;
            }
            return true;
        }

        private clsLocalLicense.ClassName GetLicenseClass()
        {
            switch (cbClass.SelectedIndex)
            {
                case 0:
                    return clsLocalLicense.ClassName.Class1;
                case 1:
                    return clsLocalLicense.ClassName.Class2;
                case 2:
                    return clsLocalLicense.ClassName.Class3;
                case 3:
                  return  clsLocalLicense.ClassName.Class4;
                case 4:
                   return  clsLocalLicense.ClassName.Class5;
                case 5:
                    return  clsLocalLicense.ClassName.Class6;
                default:
                   return clsLocalLicense.ClassName.Class7;
            }
        }

        private void AssignValues()
        {
            localLicense.ApplicantPersonID = ucAddUserWithFilter.personID;
            localLicense.ApplicationStatus = (int)clsApplications.ApplicationsStatus.New;
            localLicense.ApplicationTypeID = (int)clsApplications.ApplicationTypes.NewLocalDrivingLicenseService;
            localLicense.CreatedByUserID = clsLogin.userID;
            localLicense.PaidFees = float.Parse(lbFees.Text.ToString());
            localLicense.LicenseClassID = (int)GetLicenseClass();
        }

        private bool ValidateLicenseClass()
        {
            if (clsLocalLicense.IsPersonHasALocalLicenseOfTheSameLicenseClass(ucAddUserWithFilter.personID,
                (int)GetLicenseClass()))
            {
                if(clsLocalLicense.VerifyAValidLicense(ucAddUserWithFilter.personID,
                (int)GetLicenseClass()))
                {
                    clsPublicUtilities.ErrorMessage("you have a new order or current License of this License class , choose another License class");
                    return false;
                }
            }
            return true;
        }

        private void AddNewLocalLicense()
        {
            if(!ValidateLicenseClass())
                return;

            AssignValues();

            if(localLicense.Save())
            {
                clsPublicUtilities.InformationMessage("Data saved Successfully");
                lbID.Text = localLicense.LocalDrivingLicenseApplicationID.ToString();
                return;
            }

            clsPublicUtilities.ErrorMessage("Error operation !!");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsPersonFound())
                return;

            AddNewLocalLicense();
        }
    }
}

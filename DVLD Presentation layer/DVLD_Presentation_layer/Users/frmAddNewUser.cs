using DVLD_Business_Layer.Users;
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
using static DVLD_Presentation_layer.People.ucAdd_EditPerson;

namespace DVLD_Presentation_layer.Users
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        public frmAddNewUser(int userID)
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
            editMode = true;
            this.userID = userID;
        }

        private clsUsers user = new clsUsers();
        private int userID;
        private bool editMode = false;

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!FoundPerson())
                return;

            ClearLoginInformation();

            tbForm.SelectedTab = tbForm.TabPages[1];
        }

        private void tbForm_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tbForm.SelectedTab == tbForm.TabPages[1])
            {
                FoundPerson();
                return;
            }
            ClearLoginInformation();
        }

        private void ClearLoginInformation()
        {
            if (user.enMode == clsUsers.Mode.Add)
                tbUserName.Text = tbPassword.Text = lbID.Text = string.Empty;
        }
        private bool FoundPerson()
        {

            if (ucAddUserWithFilter.personID == -1)
            {
                clsPublicUtilities.ErrorMessage("Please first choose the person");
                tbForm.SelectedTab = tbForm.TabPages[0];
                return false;
            }
            return true;
        }

        private void AddUser()
        {
            if (user.PersonID != ucAddUserWithFilter.personID)
            {
                user = new clsUsers();
            }

            AssignValue();

            if (user.Save())
            {
                clsPublicUtilities.InformationMessage("Data saved successfully");
                lbID.Text = user.UserID.ToString();
            }
            else
                clsPublicUtilities.ErrorMessage("Failed operation");

        }

        private void AssignValue()
        {
            user.UserName = tbUserName.Text.Trim().ToString();
            user.Password = tbPassword.Text.ToString();
            user.IsActive = (cbIsActive.Checked);
            user.PersonID = ucAddUserWithFilter.personID;
        }

        private bool IsPersonAlreadyUser()
        {
            if (clsUsers.IsPersonAlreadyUser(ucAddUserWithFilter.personID))
            {
                clsPublicUtilities.ErrorMessage("This person is already a user in system,choose another one");
                ucAddUserWithFilter.personID = -1;
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(tbUserName.Text.Trim()) || string.IsNullOrEmpty(tbPassword.Text.ToString()))
            {
                clsPublicUtilities.WarningMessage("Fill the required field");
                return; 
            }

            if(ValidatePerson())
                return;

            AddUser();
        }

        private bool ValidatePerson()
        {
            if(ucAddUserWithFilter.personID == -1)
            {
                clsPublicUtilities.ErrorMessage("First choose the person");
                return true;
            }

            if(!editMode)
                if (IsPersonAlreadyUser())
                    return true;

            return false;
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            if (editMode)
            {
                user = clsUsers.GetUserByID(this.userID);

                if (user == null)
                {
                    clsPublicUtilities.ErrorMessage("Failed to upload user data");
                    return;
                }

                ucAddUserWithFilter.personID = user.PersonID;

                // disable filter search option 
                ucAddUserWithFilter1.DisableFilterSearch();

                // load person data
                ucAddUserWithFilter1.LoadPersonData(user.PersonID);

                // load user data
                LoadUserDate();
            }
        }

        private void LoadUserDate()
        {
            lbID.Text = user.UserID.ToString();
            tbUserName.Text = user.UserName.ToString();
            tbPassword.Text = user.Password.ToString();
            cbIsActive.Checked = user.IsActive;
        }
    }
}

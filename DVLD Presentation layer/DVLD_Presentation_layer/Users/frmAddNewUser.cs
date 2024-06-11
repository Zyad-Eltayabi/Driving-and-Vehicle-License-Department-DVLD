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

namespace DVLD_Presentation_layer.Users
{
    public partial class frmAddNewUser : Form
    {
        public frmAddNewUser()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private clsUsers user = new clsUsers();

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            AddUser();
        }
    }
}

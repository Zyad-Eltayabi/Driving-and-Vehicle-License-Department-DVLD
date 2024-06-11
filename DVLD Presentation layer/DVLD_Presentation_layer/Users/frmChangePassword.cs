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

namespace DVLD_Presentation_layer.Users
{
    public partial class frmChangePassword : Form
    {
        private clsUsers user;
        public frmChangePassword(int userID)
        {
            InitializeComponent();
            user = clsUsers.GetUserByID(userID);
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ucChangePassword1.LoadUserData(ref user);
        }

        private bool IsPasswordValid(string password)
        {
            if (user.Password.Equals(password))
                return true;

            clsPublicUtilities.ErrorMessage("please enter a valid password !!");
            return false;

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsPasswordValid(tbCurrentPassword.Text.ToString()))
                return;

            if (string.IsNullOrEmpty(tbNewPassword.Text))
            {
                clsPublicUtilities.WarningMessage("Password can not be empty !");
                return;
            }

            SavePassword();
        }

        private void SavePassword()
        {
            user.Password = tbNewPassword.Text.ToString();

            if (user.Save())
                clsPublicUtilities.InformationMessage("Data saved successfully");
        }
    }
}

using DVLD_Business_Layer.Login;
using DVLD_Presentation_layer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsUserExists()
        {
            if (!clsLogin.IsExists(tbUserName.Text.ToString(), tbPassword.Text.ToString()))
            {
                clsPublicUtilities.ErrorMessage(@"Incorrect password/username");
                return false;
            }
            return true;
        }

        private bool IsUserActive()
        {
            if (!clsLogin.IsActive(tbUserName.Text.ToString(), tbPassword.Text.ToString()))
            {
                clsPublicUtilities.ErrorMessage("The user is inactive, please contact the admin");
                return false;
            }

            return true;
        }


        private void RememberMe()
        {

            DirectoryInfo parentDirectory =clsPublicUtilities.GetParentDirectory();

            string utilitiesFolderPath = $@"{parentDirectory}\Utilities";

            string rememberMeFile = $@"{utilitiesFolderPath}\RememberMe.txt";

            if (File.Exists(rememberMeFile))
            {
                string[] userInformation = new string[3];
                userInformation[0] = clsLogin.userName;
                userInformation[1] = clsLogin.password;
                userInformation[2] = (cbRememberMe.Checked) ? "1" : "0";

                File.WriteAllLines(rememberMeFile, userInformation);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // check if user exists and active
            if (!IsUserExists())
                return;

            if (!IsUserActive())
                return;

            RememberMe();

            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            DirectoryInfo parentDirectory = clsPublicUtilities.GetParentDirectory();

            string utilitiesFolderPath = $@"{parentDirectory}\Utilities";
            string rememberMeFile = $@"{utilitiesFolderPath}\RememberMe.txt";

            if (File.Exists(rememberMeFile))
            {
                string[] readUserInformation = File.ReadAllLines(rememberMeFile);

                if (readUserInformation[2] == "1")
                {
                    tbUserName.Text = readUserInformation[0];
                    tbPassword.Text = readUserInformation[1];
                }
            }
        }


    }
}

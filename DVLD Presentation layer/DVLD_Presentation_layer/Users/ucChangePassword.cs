using DVLD_Business_Layer.Users;
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
    public partial class ucChangePassword : UserControl
    {
        private clsUsers user { get; set; }

        public ucChangePassword()
        {
            InitializeComponent();
        }

        public void LoadUserData(ref clsUsers user)
        {
            this.user = user;
            ucPersonDetails1.LoadPersonDetails(user.PersonID);
            SetUserData();
        }

        private void SetUserData()
        {
            lbID.Text = user.UserID.ToString();
            lbUserName.Text = user.UserName.ToString();
            lbActive.Text = (user.IsActive) ? "Yes" : "No";
        }
    }
}

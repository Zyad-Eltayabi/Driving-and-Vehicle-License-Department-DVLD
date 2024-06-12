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
    public partial class frmShowUserDetails : Form
    {
        private clsUsers user;
        public frmShowUserDetails(int userID)
        {
            InitializeComponent();
            user = clsUsers.GetUserByID(userID);
        }

        private void frmShowUserDetails_Load(object sender, EventArgs e)
        {
            ucChangePassword1.LoadUserData(ref this.user);
        }
    }
}

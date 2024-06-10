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

namespace DVLD_Presentation_layer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 1);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            btnAdmins.PerformClick();
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            frmMangePeople frmMangePeople = new frmMangePeople();
            frmMangePeople.ShowDialog();
        }

        private void btnAdmins_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.ShowDialog();
        }
    }
}

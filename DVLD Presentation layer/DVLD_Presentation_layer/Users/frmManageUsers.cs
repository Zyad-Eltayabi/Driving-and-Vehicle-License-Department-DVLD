using DVLD_Business_Layer.People;
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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            GetAllUsers();
        }

        private void GetAllUsers()
        {
            dgvUsers.DataSource = clsUsers.GetUsers();
            lbRecords.Text = dgvUsers.RowCount.ToString();
        }


        // <=== Handle Filter ===>
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = string.Empty;

            if (cbFilter.SelectedIndex == 0)
            {
                tbFilter.Visible = false;
                cbActive.Visible = false;
            }
            else if (cbFilter.SelectedIndex == 5)
            {
                tbFilter.Visible = false;
                cbActive.Visible = true;
            }
            else
            {
                tbFilter.Visible = true;
                cbActive.Visible = false;
            }
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                case 4:
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
            DataTable users = clsUsers.GetUsers();
            DataView dv = new DataView();
            dv = users.DefaultView;
            dv.RowFilter = string.Format(@"CONVERT([{0}], System.String) LIKE '{1}%'", colName, colValue);
            dgvUsers.DataSource = dv;
        }

        private void IsActiveFilter()
        {
            switch (cbActive.SelectedIndex)
            {
                case 1:
                    SetFilter("IsActive", "true");
                    break;
                case 2:
                    SetFilter("IsActive", "false");
                    break;
                default:
                    dgvUsers.DataSource = clsUsers.GetUsers();
                    break;
            }
        }

        private void FilterDataGridTable()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    SetFilter("UserID", tbFilter.Text.ToString());
                    break;
                case 2:
                    SetFilter("Full Name", tbFilter.Text.ToString());
                    break;
                case 3:
                    SetFilter("UserName", tbFilter.Text.ToString());
                    break;
                case 4:
                    SetFilter("PersonID", tbFilter.Text.ToString());
                    break;
                default:
                    dgvUsers.DataSource = clsUsers.GetUsers();
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

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            IsActiveFilter();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frmAddNewUser = new frmAddNewUser();
            frmAddNewUser.ShowDialog();
            GetAllUsers();  
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString());
            frmAddNewUser frmAddNewUser = new frmAddNewUser(userID);
            frmAddNewUser.ShowDialog();
            GetAllUsers();
        }

        private void ChangePasswordStripMenuItem1_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString());
            frmChangePassword frmChangePassword = new frmChangePassword(userID);
            frmChangePassword.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString());
            frmShowUserDetails frmShowUserDetails = new frmShowUserDetails(userID);
            frmShowUserDetails.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(dgvUsers.SelectedRows[0].Cells[0].Value.ToString());
            DeleteUser(userID);
            GetAllUsers();  
        }

        private void DeleteUser(int userID)
        {
            if (clsUsers.DeleteUser(userID))
                clsPublicUtilities.InformationMessage("User has been deleted successfully");
            else
                clsPublicUtilities.ErrorMessage("You can not delete this person, please contact the admin");
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintMessageAboutFeature();
        }

        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintMessageAboutFeature();
        }

        public void PrintMessageAboutFeature()
        {
            clsPublicUtilities.WarningMessage("This feature is not implemented yet.");
        }
    }
}

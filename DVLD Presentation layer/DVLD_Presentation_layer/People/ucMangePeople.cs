using DVLD_Business_Layer.People;
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

namespace DVLD_Presentation_layer.People
{
    public partial class ucManagePeople : UserControl
    {
        public ucManagePeople()
        {
            InitializeComponent();
        }

        private void ucManagePeople_Load(object sender, EventArgs e)
        {
            GetAllpeople();
        }

        private void GetAllpeople()
        {
            DataTable GetPeople = clsPeople.GetAllPeople();
            dgvPeople.DataSource = GetPeople;
            lbRecords.Text = GetPeople.Rows.Count.ToString();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frmAdd = new frmAdd_EditPerson();
            frmAdd.ShowDialog();
            GetAllpeople();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frmAdd = new frmAdd_EditPerson(int.Parse(dgvPeople.SelectedRows[0].Cells[0].Value.ToString()));
            frmAdd.ShowDialog();
            GetAllpeople();
        }

        void DeleteImage()
        {
            string imageName = dgvPeople.SelectedRows[0].Cells[12].Value.ToString();

            var filePath = $@"C:\DVLD-People-Images\{imageName}";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(dgvPeople.SelectedRows[0].Cells[0].Value.ToString());

            if (MessageBox.Show($"Are you sure to delete this person where ID = {personID}", "Info", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsPeople.DeletePerson(personID))
                {
                    MessageBox.Show($"Deleted successfully", "Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                    DeleteImage();
                }
                else
                    MessageBox.Show($"you can not delete this person because he has a data linked to him", "Info", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                GetAllpeople();
            }
        }

        public void PrintMessageAboutFeature()
        {
            MessageBox.Show($"This feature is not implemented yet.", "Not Ready Yet!", MessageBoxButtons.OK,
               MessageBoxIcon.Warning);
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintMessageAboutFeature();
        }

        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintMessageAboutFeature();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(dgvPeople.SelectedRows[0].Cells[0].Value.ToString());
            frmPersonDetails frmPerson = new frmPersonDetails(personID);
            frmPerson.ShowDialog();
        }


        // <=== Handle Filter ===>
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = string.Empty;

            if (cbFilter.SelectedIndex == 0)
                tbFilter.Visible = false;
            else
                tbFilter.Visible = true;

        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 1)
            {
                if (!char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
            else if (cbFilter.SelectedIndex == 10) // handle Email 
            {
                if (e.KeyChar == '@' || e.KeyChar == '.')
                {
                    e.Handled = false;
                    return;
                }

                if (!char.IsLetterOrDigit(e.KeyChar))
                    e.Handled = true;
            }
            else
            {
                if (!char.IsLetterOrDigit(e.KeyChar))
                    e.Handled = true;
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
            DataTable people = clsPeople.GetAllPeople();
            DataView dv = new DataView();
            dv = people.DefaultView;
            dv.RowFilter = string.Format("CONVERT({0},System.String) LIKE '{1}%'", colName, colValue);
            dgvPeople.DataSource = dv;
        }

        private void FilterDataGridTable()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    SetFilter("PersonID", tbFilter.Text.ToString());
                    break;
                case 2:
                    SetFilter("NationalNo", tbFilter.Text.ToString());
                    break;
                case 3:
                    SetFilter("FirstName", tbFilter.Text.ToString());
                    break;
                case 4:
                    SetFilter("SecondName", tbFilter.Text.ToString());
                    break;
                case 5:
                    SetFilter("ThirdName", tbFilter.Text.ToString());
                    break;
                case 6:
                    SetFilter("LastName", tbFilter.Text.ToString());
                    break;
                case 7:
                    SetFilter("CountryName", tbFilter.Text.ToString());
                    break;
                case 8:
                    SetFilter("Gendor", tbFilter.Text.ToString());
                    break;
                case 9:
                    SetFilter("Phone", tbFilter.Text.ToString());
                    break;
                case 10:
                    SetFilter("Email", tbFilter.Text.ToString());
                    break;
                default:
                    dgvPeople.DataSource = clsPeople.GetAllPeople();
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
    }
}

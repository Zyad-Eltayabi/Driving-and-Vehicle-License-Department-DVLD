using DVLD_Business_Layer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = int.Parse(dgvPeople.SelectedRows[0].Cells[0].Value.ToString());

            if (MessageBox.Show($"Are you sure to delete this person where ID = {personID}", "Info", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsPeople.DeletePerson(personID))
                    MessageBox.Show($"Deleted successfully", "Info", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
    }
}

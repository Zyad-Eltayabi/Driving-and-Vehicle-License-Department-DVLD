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

namespace DVLD_Presentation_layer.People
{
    public partial class ucAddUserWithFilter : UserControl
    {
        public ucAddUserWithFilter()
        {
            InitializeComponent();
        }

        public static int personID = -1;

        private string ColumnNameInFilterComboBox()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    return "PersonID";
                default:
                    return "NationalNo";
            }
        }

        private bool IsPersonExists()
        {
            string columnName = ColumnNameInFilterComboBox();

            personID = clsPeople.GetPersonID(columnName, tbFilter.Text.ToString());

            if (personID == -1)
            {
                clsPublicUtilities.ErrorMessage("Person is not found");
                return false;
            }

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFilter.Text))
                return;

            if (!IsPersonExists())
                return;

            // now we sure that the person is found and he does not a user in system
            ucPersonDetails1.LoadPersonDetails(ucAddUserWithFilter.personID);
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                e.Handled = (!char.IsDigit(e.KeyChar));
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbFilter.Text = string.Empty;
        }

        public void DisableFilterSearch()
        {
            gbFilter.Enabled = false;
        }

        public void LoadPersonData(int personID)
        {
            ucPersonDetails1.LoadPersonDetails(personID);
            ucAddUserWithFilter.personID = personID;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAdd_EditPerson frmAdd_EditPerson = new frmAdd_EditPerson();
            frmAdd_EditPerson.ucAdd_EditPerson.delegatePersonID += LoadPersonData;
            frmAdd_EditPerson.ShowDialog();
        }

        
    }
}

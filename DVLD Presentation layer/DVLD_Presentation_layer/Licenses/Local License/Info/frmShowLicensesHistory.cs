using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.Licenses.Local_License
{
    public partial class frmShowLicensesHistory : Form
    {
        private int personID;
        public frmShowLicensesHistory(int personID)
        {
            InitializeComponent();
            this.personID = personID;
        }

        private void frmShowLicensesHistory_Load(object sender, EventArgs e)
        {
            LoadPersonInfo();
        }

        private void LoadPersonInfo()
        {
            ucPersonDetails1.LoadPersonDetails(personID);
            ucDriverLicenses1.LoadLicenses(personID);
        }
    }
}

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

namespace DVLD_Presentation_layer.Licenses.ApplicationTypes
{
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {
            GetApplicationTypes();
        }

        private void GetApplicationTypes()
        {
            dgvTypes.DataSource = clsApplicationTypes.GetApplicationTypes();
            lbRecords.Text = dgvTypes.RowCount.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int applicationTypeID = int.Parse(dgvTypes.SelectedRows[0].Cells[0].Value.ToString());
            frmUpdateApplicationType frmUpdate = new frmUpdateApplicationType(applicationTypeID);
            frmUpdate.ShowDialog();
            GetApplicationTypes();
        }

    }
}

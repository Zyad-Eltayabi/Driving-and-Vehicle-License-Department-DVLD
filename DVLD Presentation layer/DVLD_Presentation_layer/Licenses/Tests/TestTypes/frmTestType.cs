using DVLD_Business_Layer.Tests;
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

namespace DVLD_Presentation_layer.Licenses.Tests
{
    public partial class frmTestType : Form
    {
        public frmTestType()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int testTypeID = int.Parse(dgvTypes.SelectedRows[0].Cells[0].Value.ToString());
            frmUpdateTestType frmUpdateTestType = new frmUpdateTestType(testTypeID);
            frmUpdateTestType.ShowDialog();
            GetTestTypes();
        }

        private void frmTestType_Load(object sender, EventArgs e)
        {
            GetTestTypes();
        }

        private void GetTestTypes()
        {
            dgvTypes.DataSource = clsTestTypes.GetTestTypes();
            lbRecords.Text = dgvTypes.RowCount.ToString();
        }
    }
}

using DVLD_Business_Layer.Licenses.Drivers;
using DVLD_Business_Layer.Licenses.Local_License;
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

namespace DVLD_Presentation_layer.Drivers
{
    public partial class frmDrivers : Form
    {
        public frmDrivers()
        {
            InitializeComponent();
            clsPublicUtilities.CenterForm(this);
        }

        private void GetDrivers()
        {
            dgvDrivers.DataSource = clsDrivers.GetDrivers();
            lbRecords.Text = dgvDrivers.RowCount.ToString();
        }
        private void frmDrivers_Load(object sender, EventArgs e)
        {
            GetDrivers();
        }

        // Handle Filter
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
                tbFilter.Visible = false;
            else
                tbFilter.Visible = true;

            tbFilter.Clear();
        }

        private void tbFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                case 2:
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
            DataTable drivers = clsDrivers.GetDrivers();
            DataView dv = new DataView();
            dv = drivers.DefaultView;
            dv.RowFilter = string.Format(@"CONVERT([{0}], System.String) LIKE '{1}%'", colName, colValue);
            dgvDrivers.DataSource = dv;
        }

        private void FilterDataGridTable()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 1:
                    SetFilter("DriverID", tbFilter.Text.ToString());
                    break;
                case 2:
                    SetFilter("PersonID", tbFilter.Text.ToString());
                    break;
                case 3:
                    SetFilter("NationalNo", tbFilter.Text.ToString());
                    break;
                case 4:
                    SetFilter("FullName", tbFilter.Text.ToString());
                    break;
                default:
                    dgvDrivers.DataSource = clsDrivers.GetDrivers();
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
            tbFilter.Clear();
        }
    }
}

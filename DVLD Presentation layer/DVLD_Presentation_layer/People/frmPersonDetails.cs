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
    public partial class frmPersonDetails : Form
    {
        private int personID = 0;
        public frmPersonDetails(int personID)
        {
            InitializeComponent();
            this.personID = personID;   
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ucPersonDetails personDetails = new ucPersonDetails(personID);
            this.Controls.Add(personDetails);
            personDetails.Location = new Point(0, 0);
        }
    }
}

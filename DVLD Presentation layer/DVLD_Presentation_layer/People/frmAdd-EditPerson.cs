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
    public partial class frmAdd_EditPerson : Form
    {
        public ucAdd_EditPerson ucAdd_EditPerson { get; set; }

        public frmAdd_EditPerson()
        {
            InitializeComponent();
            ucAdd_EditPerson = new ucAdd_EditPerson();
        }
        
        public frmAdd_EditPerson(int personID)
        {
            InitializeComponent();
            ucAdd_EditPerson = new ucAdd_EditPerson(personID);
        }

        private void frmAdd_EditPerson_Load(object sender, EventArgs e)
        {
            ucAdd_EditPerson.Location = new Point(0, 0);
            this.Controls.Add(ucAdd_EditPerson);
        }
    }
}

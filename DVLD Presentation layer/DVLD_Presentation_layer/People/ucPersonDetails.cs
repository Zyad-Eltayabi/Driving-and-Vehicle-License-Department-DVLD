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

    public partial class ucPersonDetails : UserControl
    {
        private DataTable person = new DataTable();

        public ucPersonDetails()
        {
            InitializeComponent();
        }

        public void LoadPersonDetails(int personID)
        {
            person = clsPeople.GetPersonDetails(personID);
            SetPersonInformation();
        }

        private void SetPersonInformation()
        {
            lbID.Text = person.Rows[0][0].ToString();
            lbNationalNo.Text = person.Rows[0][1].ToString();
            lbName.Text = $@"{person.Rows[0][2].ToString()} {person.Rows[0][3].ToString()} {person.Rows[0][4].ToString()} {person.Rows[0][5].ToString()}";
            lbDateOfBirth.Text = person.Rows[0][6].ToString();
            lbGendor.Text = (person.Rows[0][7].ToString() == "0") ? "Male" : "Female";
            lbAddress.Text = person.Rows[0][8].ToString();
            lbPhone.Text = person.Rows[0][9].ToString();
            lbEmail.Text = person.Rows[0][10].ToString();
            lbCountry.Text = clsPeople.GetCountryName((int.Parse(person.Rows[0][11].ToString())));
            SetImage();
        }

        private void SetImage()
        {
            string imageName = person.Rows[0][12].ToString();

            if (string.IsNullOrEmpty(imageName))
            {
                picPersonPic.Image = Properties.Resources.card;
                return;
            }
            else
            {
                using (var stream = File.Open($@"C:\DVLD-People-Images\{imageName}", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    if (stream != null)
                    {
                        picPersonPic.Image = new Bitmap(stream);
                    }
                    else
                        picPersonPic.Image = Properties.Resources.card;
                }
            }
        }
    }
}

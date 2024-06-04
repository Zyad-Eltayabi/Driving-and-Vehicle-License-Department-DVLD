using DVLD_Business_Layer.Countries;
using DVLD_Business_Layer.People;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation_layer.People
{
    public partial class ucAdd_EditPerson : UserControl
    {
        public ucAdd_EditPerson()
        {
            InitializeComponent();
        }

        private bool validNationalNumber = false;
        private bool validEmail = true;

        // VALIDATE TEXT BOXES IN FORM
        private void ValidateTextBox(ref Guna.UI2.WinForms.Guna2TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
                errorProvider1.SetError(textBox, "This field is required");
            else
                errorProvider1.SetError(textBox, "");
        }

        private void tbCountry_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox(ref tbLast);
        }

        private void tbFirst_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox(ref tbFirst);
        }

        private void tbSecond_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox(ref tbSecond);
        }

        private void tbAddress_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox(ref tbAddress);
        }


        private void tbPhone_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox(ref tbPhone);
        }

        private void tbThird_Validating(object sender, CancelEventArgs e)
        {
            ValidateTextBox(ref tbThird);
        }

        private void tbNational_Validating(object sender, CancelEventArgs e)
        {
            if (clsPeople.IsNationalityNumberExists(tbNational.Text.ToString()))
            {
                errorProvider1.SetError(tbNational, "Please choose another No number");
                validNationalNumber = false;
            }
            else
            {
                errorProvider1.SetError(tbNational, null);
                validNationalNumber = true;
            }
        }

        // Validate Email
        private bool IsvalidEmail(string email)
        {
            return email.Contains("@gmail.com") || email.Contains("@yahoo.com");
        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbEmail.Text))
            {
                if (!IsvalidEmail(tbEmail.Text))
                {
                    errorProvider1.SetError(tbEmail, "please enter a valid email");
                    validEmail = false;
                    return;
                }
            }
            errorProvider1.SetError(tbEmail, "");
            validEmail = true;
        }

        // Validate Date of Birth
        private void ValidateDate()
        {
            DateTime dateTime = DateTime.Now.Date;
            dateTime = dateTime.AddYears(-18);
            dtpDateOfBirth.MaxDate = dateTime;
        }

        private void ucAdd_EditPerson_Load(object sender, EventArgs e)
        {
            ValidateDate();
            SetCountriesInCountriesComboBox();
        }

        // Get All Countries
        private void SetCountriesInCountriesComboBox()
        {
            DataTable Countries = clsCountries.GetAllCountries();
            cbCountry.DataSource = Countries;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.SelectedIndex = 50;
        }

        // Handle Person Image
        private void CopyImage(string imagePath, ref string nameOfNewImage)
        {
            Guid guid = Guid.NewGuid();
            nameOfNewImage += guid.ToString();
            nameOfNewImage += imagePath.Contains(".png") ? ".png" : ".jpg";
            File.Copy(imagePath, $@"C:\DVLD-People-Images\{nameOfNewImage}");
        }

        private void SetNewImage(string imagePath)
        {
            picPersonPic.Image = new Bitmap(imagePath);
        }

        private void DeleteOldImage(string imageName)
        {
            if (File.Exists($@"C:\DVLD-People-Images\{imageName}"))
                File.Delete($@"C:\DVLD-People-Images\{imageName}");
        }

        private void DefaultSettingInOpenFileDialog1()
        {
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Image Files";
            openFileDialog1.Filter = "JPG (*.jpg)|*.jpg|PNG (*.PNG)|*.png";
        }
        private void lkAddPic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DefaultSettingInOpenFileDialog1();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lkRemovePic.Visible = true;

                SetNewImage(openFileDialog1.FileName);

                string nameOfNewImage = "";

                CopyImage(openFileDialog1.FileName.ToString(), ref nameOfNewImage);

                if (picPersonPic.Tag != null)
                    DeleteOldImage(picPersonPic.Tag.ToString());

                picPersonPic.Tag = nameOfNewImage.ToString();
            }
        }

        private void lkRemovePic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DeleteOldImage(picPersonPic.Tag.ToString());
            picPersonPic.Tag = null;
            lkRemovePic.Visible = false;
            Bitmap pic = new Bitmap(Properties.Resources.card);
            picPersonPic.Image = pic;
        }

        private bool ValidateTextBox()
        {
            return string.IsNullOrEmpty(tbFirst.Text) || string.IsNullOrEmpty(tbSecond.Text) || string.IsNullOrEmpty(tbThird.Text) ||
                string.IsNullOrEmpty(tbLast.Text) || string.IsNullOrEmpty(tbAddress.Text) || string.IsNullOrEmpty(tbPhone.Text);
        }

        private void PrintWarningMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private bool ValidateUserInputs()
        {
            if (!validNationalNumber)
            {
                PrintWarningMessage("Please enter a valid national number");
                return false;
            }

            if (!validEmail)
            {
                PrintWarningMessage("Please enter a valid email");
                return false;
            }

            if (ValidateTextBox())
            {
                PrintWarningMessage("Some Fields in form are required");
                return false;
            }

            return true;
        }

        private void TrimUserInputs()
        {
            tbFirst.Text = tbFirst.Text.Trim();
            tbSecond.Text = tbSecond.Text.Trim();
            tbThird.Text = tbThird.Text.Trim();
            tbLast.Text = tbLast.Text.Trim();
            tbAddress.Text = tbAddress.Text.Trim();
            tbPhone.Text = tbPhone.Text.Trim();
            tbNational.Text = tbNational.Text.Trim();
            tbEmail.Text = tbEmail.Text.Trim();
        }

        private void AssignValues(ref clsPeople addNewPerson)
        {
            if(lbID.Text.ToString() != "ID")
                addNewPerson.enMode = clsPeople.Mode.Update;
            addNewPerson.NationalNo = tbNational.Text.ToString();
            addNewPerson.FirstName = tbFirst.Text.ToString();
            addNewPerson.SecondName = tbSecond.Text.ToString();
            addNewPerson.ThirdName = tbThird.Text.ToString();
            addNewPerson.LastName = tbLast.Text.ToString();
            addNewPerson.Phone = tbPhone.Text.ToString();
            addNewPerson.Address = tbAddress.Text.ToString();
            addNewPerson.Gendor = (rbMale.Checked == true) ? 0 : 1;
            addNewPerson.DateOfBirth = DateTime.Parse(dtpDateOfBirth.Value.ToShortDateString().ToString());
            addNewPerson.Email = tbEmail.Text.ToString();
            addNewPerson.NationalityCountryID = (cbCountry.SelectedIndex) + 1;
            addNewPerson.ImagePath = (picPersonPic.Tag == null) ? null : picPersonPic.Tag.ToString();
        }
        private void SaveNewPerson()
        {
            TrimUserInputs();
            clsPeople addNewPerson = new clsPeople();
            AssignValues(ref addNewPerson);
            if (addNewPerson.Save())
            {
                MessageBox.Show("Info", "Successful operation", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                lbID.Text = addNewPerson.PersonID.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateUserInputs())
                return;
            SaveNewPerson();
        }
    }
}

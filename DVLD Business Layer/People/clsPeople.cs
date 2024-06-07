using DVLD_Database_Layer.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.People
{
    public class clsPeople
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public enum Mode
        {
            Add = 0,
            Update = 1
        }

        public Mode enMode { get; set; }

        private clsPeople(int personID, string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, int gendor, string address, string phone,
            string email, int nationalityCountryID, string imagePath)
        {
            PersonID = personID;
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gendor = gendor;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            enMode = Mode.Update;
        }

        public clsPeople()
        {
            this.PersonID = -1;
            this.NationalityCountryID = 0;
            this.NationalNo = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = 0;
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Phone = "";
            this.Email = "";
            this.Address = "";
            this.ImagePath = "";
            enMode = Mode.Add;
        }

        public static DataTable GetAllPeople()
        {
            return clsPeopleDB.GetAllPeople();
        }

        public static bool IsNationalityNumberExists(string nationalityNumber)
        {
            return clsPeopleDB.IsNationalityNumberExists(nationalityNumber);
        }

        private bool AddNewPerson()
        {
            this.PersonID = clsPeopleDB.AddNewPerson(this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);

            return this.PersonID != -1;
        }
        private bool UpdatePerson()
        {
            return clsPeopleDB.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);
        }
        public static clsPeople GetPersonByID(int PersonID)
        {

            string nationalNo = ""; string firstName = ""; string secondName = "";
            string thirdName = ""; string lastName = ""; DateTime dateOfBirth = DateTime.Now; int gendor = 0; string address = ""; string phone = "";
            string email = ""; int nationalityCountryID = -1; string imagePath = "";

            if (clsPeopleDB.GetPersonByID(PersonID, ref nationalNo, ref firstName, ref secondName,
           ref thirdName, ref lastName, ref dateOfBirth, ref gendor, ref address, ref phone,
           ref email, ref nationalityCountryID, ref imagePath))
            {
                return new clsPeople(PersonID, nationalNo, firstName, secondName,
            thirdName, lastName, dateOfBirth, gendor, address, phone,
            email, nationalityCountryID, imagePath);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePerson(int personID)
        {
            return clsPeopleDB.DeletePerson(personID);
        }

        public static DataTable GetPersonDetails(int personID)
        {
            return clsPeopleDB.GetPersonDetails(personID);
        }

        public static string GetCountryName(int countryID)
        {
            return clsPeopleDB.GetCountryName(countryID);
        }
        public bool Save()
        {
            switch (enMode)
            {
                case Mode.Add:
                    enMode = Mode.Update;
                    return AddNewPerson();
                case Mode.Update:
                    return UpdatePerson();
                default:
                    return false;
            }
        }
    }
}

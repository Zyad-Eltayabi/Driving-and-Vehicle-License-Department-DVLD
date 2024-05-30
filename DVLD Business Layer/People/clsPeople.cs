using DVLD_Database_Layer.People;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.People
{
    public class clsPeople
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set;}
        public string SecondName { get; set;}
        public string ThirdName { get; set;}
        public string LastName { get; set;}
        public DateTime DateOfBirth { get; set;}
        public int Gendor {  get; set;}
        public string Address { get; set;}
        public string Phone { get; set;}
        public string Email { get; set;}
        public int NationalityCountryID { get; set;}
        public string ImagePath { get;set;}

        public static DataTable GetAllPeople()
        {
            return clsPeopleDB.GetAllPeople();
        }
    }
}

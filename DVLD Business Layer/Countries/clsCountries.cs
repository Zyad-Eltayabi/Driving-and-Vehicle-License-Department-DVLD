using DVLD_Database_Layer.Countries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Countries
{
    public class clsCountries
    {
        public static DataTable GetAllCountries()
        {
            return clsCountriesDB.GetAllCountries();
        }
    }
}

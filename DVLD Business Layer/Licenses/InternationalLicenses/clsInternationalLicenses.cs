using DVLD_Database_Layer.Licenses.InternationalLicenses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Licenses.InternationalLicenses
{
    public class clsInternationalLicenses
    {

        public static DataTable GetLicensesByDriverID(int driverID)
        {
            return clsInternationalLicensesDB.GetLicensesByDriverID(driverID);
        }
    }
}

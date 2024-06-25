using DVLD_Database_Layer.Licenses.Detained_Licenses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer.Licenses.Detained_Licenses
{
    public class clsDetainedLicenses
    {
        public static bool IsLicenseDetained(int licenseID)
        {
            return clsDetainedLicensesDB.IsLicenseDetained(licenseID);
        }
    }
}

using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Licenses.Detained_Licenses
{
    public static class clsDetainedLicensesDB
    {
        public static bool IsLicenseDetained(int licenseID)
        {
            bool isFound = false;
            string query = @"select DetainedLicenses.LicenseID from DetainedLicenses where LicenseID =@LicenseID";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("LicenseID", licenseID);

                        object result = sqlCommand.ExecuteScalar();

                        isFound = (result != null);
                    }
                }
            }
            catch (Exception)
            {
            }
            return isFound;
        }

    }
}

using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Licenses.InternationalLicenses
{
    public class clsInternationalLicensesDB
    {
        public static DataTable GetLicensesByDriverID(int driverID)
        {
            DataTable internationalLicenses = new DataTable();

            string query = @"select * from InternationalLicensesBasicInfo where InternationalLicensesBasicInfo.DriverID = @DriverID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {

                        sqlCommand.Parameters.AddWithValue("@DriverID", driverID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            internationalLicenses.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

            return internationalLicenses;
        }

    }
}

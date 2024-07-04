using DVLD_Database_Layer.Connections;
using System;
using System.Collections;
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
            string query = @"select DetainedLicenses.LicenseID from DetainedLicenses where LicenseID =@LicenseID
                               and DetainedLicenses.IsReleased = '0'";
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

        public static int DetainLicense(int licenseID, DateTime detainDate, float fineFees, int createdByUserID, bool isReleased)
        {
            int ID = -1;
            string query = @"USE[DVLD]
                            INSERT INTO[dbo].[DetainedLicenses]
                                        ([LicenseID]
                                       , [DetainDate]
                                       , [FineFees]
                                       , [CreatedByUserID]
                                       , [IsReleased]) VALUES(@LicenseID, @DetainDate, @FineFees,
                                        @CreatedByUserID, @IsReleased); select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@LicenseID", licenseID);
                        sqlCommand.Parameters.AddWithValue("@DetainDate", detainDate);
                        sqlCommand.Parameters.AddWithValue("@FineFees", fineFees);
                        sqlCommand.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                        sqlCommand.Parameters.AddWithValue("@IsReleased", isReleased);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            ID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }

            return ID;

        }
    }
}

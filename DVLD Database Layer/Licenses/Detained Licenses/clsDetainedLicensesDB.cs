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

        public static bool GetDetainedLicenseByLicenseID(ref int detainID,ref int licenseID, ref int createdByUserID, ref int releasedByUserID,
          ref int releaseApplicationID, ref DateTime detainDate, ref DateTime releaseDate, ref float fineFees, ref bool isReleased)
        {
            var isFound = false;
            string query = @"select * from DetainedLicenses where LicenseID = @LicenseID";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@LicenseID", licenseID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                isFound = true;
                                detainID = int.Parse(sqlDataReader["DetainID"].ToString());
                                createdByUserID = int.Parse(sqlDataReader["CreatedByUserID"].ToString());
                                detainDate = DateTime.Parse(sqlDataReader["DetainDate"].ToString());
                                fineFees = float.Parse(sqlDataReader["FineFees"].ToString());
                                isReleased = Boolean.Parse(sqlDataReader["IsReleased"].ToString());

                                if (!string.IsNullOrEmpty(sqlDataReader["ReleaseDate"].ToString()))
                                    releaseDate = DateTime.Parse(sqlDataReader["ReleaseDate"].ToString());

                                if (!string.IsNullOrEmpty(sqlDataReader["ReleasedByUserID"].ToString()))
                                    releasedByUserID = int.Parse(sqlDataReader["ReleasedByUserID"].ToString());

                                if (!string.IsNullOrEmpty(sqlDataReader["ReleaseApplicationID"].ToString()))
                                    releaseApplicationID = int.Parse(sqlDataReader["ReleaseApplicationID"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

               
            }
            return isFound;
        }

        public static bool UdpateDetainedLicense(int detainID, int licenseID, int createdByUserID, int releasedByUserID,
            int releaseApplicationID, DateTime detainDate, DateTime releaseDate, float fineFees, bool isReleased)
        {
            int rowsAffected = 0;
            string query = @"USE [DVLD]
                            UPDATE [dbo].[DetainedLicenses]
                               SET [LicenseID] = @LicenseID
                                  ,[DetainDate] = @DetainDate
                                  ,[FineFees] = @FineFees
                                  ,[CreatedByUserID] = @CreatedByUserID
                                  ,[IsReleased] = @IsReleased
                                  ,[ReleaseDate] = @ReleaseDate
                                  ,[ReleasedByUserID] = @ReleasedByUserID
                                  ,[ReleaseApplicationID] = @ReleaseApplicationID
                             WHERE DetainID = @DetainID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@DetainID", detainID);
                        sqlCommand.Parameters.AddWithValue("@LicenseID", licenseID);
                        sqlCommand.Parameters.AddWithValue("@DetainDate", detainDate); 
                        sqlCommand.Parameters.AddWithValue("@FineFees", fineFees);
                        sqlCommand.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                        sqlCommand.Parameters.AddWithValue("@IsReleased", isReleased);
                        sqlCommand.Parameters.AddWithValue("@ReleaseDate", releaseDate);
                        sqlCommand.Parameters.AddWithValue("@ReleasedByUserID", releasedByUserID);
                        sqlCommand.Parameters.AddWithValue("@ReleaseApplicationID", releaseApplicationID);

                        rowsAffected = int.Parse(sqlCommand.ExecuteNonQuery().ToString());
                    }
                }
            }
            catch (Exception)
            {

                
            }
            return rowsAffected > 0;
        }

    }
}

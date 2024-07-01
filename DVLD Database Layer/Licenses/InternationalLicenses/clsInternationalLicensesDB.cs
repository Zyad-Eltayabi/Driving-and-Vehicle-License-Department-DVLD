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

        public static int AddNewInternationalLicense(int applicationID, int driverID,
            int issuedUsingLocalLicenseID, int createdByUserID, DateTime expirationDate, bool isActive)
        {
            int ID = -1;
            string query = @" INSERT INTO [dbo].[InternationalLicenses]
                           ([ApplicationID]
                           ,[DriverID]
                           ,[IssuedUsingLocalLicenseID]
                           ,[IssueDate]
                           ,[ExpirationDate]
                           ,[IsActive]
                           ,[CreatedByUserID])
                            VALUES (@ApplicationID,@DriverID,@IssuedUsingLocalLicenseID,@IssueDate,@ExpirationDate,
                            @IsActive,@CreatedByUserID);select SCOPE_IDENTITY();";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ApplicationID", applicationID);
                        sqlCommand.Parameters.AddWithValue("@DriverID", driverID);
                        sqlCommand.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
                        sqlCommand.Parameters.AddWithValue("@IssueDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                        sqlCommand.Parameters.AddWithValue("@IsActive", isActive);
                        sqlCommand.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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

        public static bool IsPersonHasAnActiveInternationalLicense(int localLicenseID)
        {
            bool isPersonHasAlreadyInternationalLicense = false;
            string query = @" select InternationalLicenses.InternationalLicenseID from InternationalLicenses
                                where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
                                  and InternationalLicenses.IsActive = '1'";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", localLicenseID);

                        object result = sqlCommand.ExecuteScalar();

                        isPersonHasAlreadyInternationalLicense = (result != null);
                    }
                }
            }
            catch (Exception)
            {

               
            }
            return isPersonHasAlreadyInternationalLicense;
        }

    }
}

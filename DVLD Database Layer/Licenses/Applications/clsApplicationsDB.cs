using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Licenses.Applications
{
    public static class clsApplicationsDB
    {
        public static int AddNewApplication(int applicantPersonID, int applicationTypeID, int applicationStatus,
            int createdByUserID, float paidFees)
        {
            int ApplicationID = -1;
            string query = @"USE [DVLD]
                            INSERT INTO [dbo].[Applications]
                                       ([ApplicantPersonID]
                                       ,[ApplicationDate]
                                       ,[ApplicationTypeID]
                                       ,[ApplicationStatus]
                                       ,[LastStatusDate]
                                       ,[PaidFees]
                                       ,[CreatedByUserID])
                                 VALUES
                                       (@ApplicantPersonID
                                       ,@ApplicationDate
                                       ,@ApplicationTypeID
                                       ,@ApplicationStatus
                                       ,@LastStatusDate
                                       ,@PaidFees
                                       ,@CreatedByUserID);select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ApplicantPersonID", applicantPersonID);
                        sqlCommand.Parameters.AddWithValue("@ApplicationDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);
                        sqlCommand.Parameters.AddWithValue("@ApplicationStatus", applicationStatus);
                        sqlCommand.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@PaidFees", paidFees);
                        sqlCommand.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            ApplicationID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {

            }
            return ApplicationID;
        }
    }
}

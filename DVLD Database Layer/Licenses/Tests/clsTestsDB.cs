using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Licenses.Tests
{
    public class clsTestsDB
    {
        public static int AddNewTest(int testAppointmentID, int createdByUserID, bool testResult, string notes)
        {
            int testID = -1;
            string query = @"USE [DVLD]
                                    INSERT INTO [dbo].[Tests]
                                               ([TestAppointmentID]
                                               ,[TestResult]
                                               ,[Notes]
                                               ,[CreatedByUserID])
                                         VALUES
                                               (@TestAppointmentID
                                               ,@TestResult
                                               ,@Notes
                                               ,@CreatedByUserID);select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("TestAppointmentID", testAppointmentID);
                        sqlCommand.Parameters.AddWithValue("TestResult", testResult);
                        sqlCommand.Parameters.AddWithValue("CreatedByUserID", createdByUserID);


                        if (string.IsNullOrEmpty(notes))
                            sqlCommand.Parameters.AddWithValue("Notes", System.DBNull.Value);
                        else
                            sqlCommand.Parameters.AddWithValue("Notes", notes);


                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            testID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }

            return testID;
        }

        public static bool UpdateTest(int appointmentID, bool testResult, string notes)
        {
            int rowsAffected = 0;
            string query = @"USE [DVLD]
                              update Tests 
                                set TestResult = @TestResult , Notes = @Notes
                                 where TestAppointmentID = @TestAppointmentID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("TestAppointmentID", appointmentID);
                        sqlCommand.Parameters.AddWithValue("TestResult", testResult);

                        if (string.IsNullOrEmpty(notes))
                            sqlCommand.Parameters.AddWithValue("Notes", System.DBNull.Value);
                        else
                            sqlCommand.Parameters.AddWithValue("Notes", notes);

                        rowsAffected = int.Parse(sqlCommand.ExecuteNonQuery().ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return rowsAffected > 0;
        }

    }
}

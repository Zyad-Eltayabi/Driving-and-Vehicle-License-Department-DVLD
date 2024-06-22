using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Licenses.Tests
{
    public static class clsTestAppointmentsDB
    {
        public static int AddNewAppointment(int testTypeID, int localDrivingLicenseApplicationID, int createdByUserID,
            int retakeTestApplicationID, DateTime appointmentDate, float paidFees, bool isLocked)
        {
            int testAppointmentID = -1;
            string query = @"USE [DVLD]
                                    INSERT INTO [dbo].[TestAppointments]
                                               ([TestTypeID]
                                               ,[LocalDrivingLicenseApplicationID]
                                               ,[AppointmentDate]
                                               ,[PaidFees]
                                               ,[CreatedByUserID]
                                               ,[IsLocked]
                                               ,[RetakeTestApplicationID])
                                         VALUES
                                               (@TestTypeID
                                               ,@LocalDrivingLicenseApplicationID
                                               ,@AppointmentDate
                                               ,@PaidFees
                                               ,@CreatedByUserID
                                               ,@IsLocked
                                               ,@RetakeTestApplicationID);select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("TestTypeID", testTypeID);
                        sqlCommand.Parameters.AddWithValue("LocalDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
                        sqlCommand.Parameters.AddWithValue("AppointmentDate", appointmentDate);
                        sqlCommand.Parameters.AddWithValue("PaidFees", paidFees);
                        sqlCommand.Parameters.AddWithValue("CreatedByUserID", createdByUserID);
                        sqlCommand.Parameters.AddWithValue("IsLocked", isLocked);

                        if (retakeTestApplicationID == 0) // it is a new appointment 
                            sqlCommand.Parameters.AddWithValue("RetakeTestApplicationID", System.DBNull.Value);
                        else
                            sqlCommand.Parameters.AddWithValue("IsLocked", retakeTestApplicationID);


                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            testAppointmentID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }

            return testAppointmentID;
        }

        public static DataTable GetAppointmentDetails(int localDrivingAppID)
        {
            DataTable appointment = new DataTable();

            string query = @"SELECT      TestAppointmentID, AppointmentDate, PaidFees, IsLocked
                                        FROM          TestAppointments 
                                        where TestAppointments.LocalDrivingLicenseApplicationID =@LocalDrivingAppID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {

                        sqlCommand.Parameters.AddWithValue("@LocalDrivingAppID", localDrivingAppID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            appointment.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

            return appointment;
        }


        public static DataTable GetAppointmentFullDetails(int localDrivingAppID, int testTypeID)
        {
            DataTable appointment = new DataTable();

            string query = @"SELECT top 1     Tests.TestAppointmentID, TestAppointments.LocalDrivingLicenseApplicationID,
                            Tests.TestResult,
                            TestAppointments.TestTypeID, TestAppointments.IsLocked, TestAppointments.RetakeTestApplicationID
                            FROM          Tests INNER JOIN
                                                  TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
					                              where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                                   and TestAppointments.TestTypeID = @TestTypeID
                            ORDER BY Tests.TestAppointmentID DESC";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {

                        sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingAppID);
                        sqlCommand.Parameters.AddWithValue("@TestTypeID", testTypeID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            appointment.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

            return appointment;
        }

    }


}


﻿using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Database_Layer.Licenses.Local_Licence
{
    public static class clsLicensesDB
    {
        public static int AddNewLicense(int applicationID, int driverID, int licenseClass,
            int issueReason, int createdByUserID, DateTime expirationDate, string notes, float paidFees)
        {
            int licenseID = -1;
            string query = @"USE [DVLD]
                            INSERT INTO [dbo].[Licenses]
                                       ([ApplicationID]
                                       ,[DriverID]
                                       ,[LicenseClass]
                                       ,[IssueDate]
                                       ,[ExpirationDate]
                                       ,[Notes]
                                       ,[PaidFees]
                                       ,[IsActive]
                                       ,[IssueReason]
                                       ,[CreatedByUserID])
                                 VALUES
                                       (@ApplicationID
                                       ,@DriverID
                                       ,@LicenseClass
                                       ,@IssueDate
                                       ,@ExpirationDate
                                       ,@Notes
                                       ,@PaidFees
                                       ,@IsActive
                                       ,@IssueReason
                                       ,@CreatedByUserID);select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("ApplicationID", applicationID);
                        sqlCommand.Parameters.AddWithValue("DriverID", driverID);
                        sqlCommand.Parameters.AddWithValue("LicenseClass", licenseClass);
                        sqlCommand.Parameters.AddWithValue("IssueDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("ExpirationDate", expirationDate);

                        if (string.IsNullOrEmpty(notes))
                            sqlCommand.Parameters.AddWithValue("Notes", System.DBNull.Value);
                        else
                            sqlCommand.Parameters.AddWithValue("Notes", notes);

                        sqlCommand.Parameters.AddWithValue("PaidFees", paidFees);
                        sqlCommand.Parameters.AddWithValue("IsActive", true);
                        sqlCommand.Parameters.AddWithValue("IssueReason", issueReason);
                        sqlCommand.Parameters.AddWithValue("CreatedByUserID", createdByUserID);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            licenseID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }

            return licenseID;
        }

        public static DataTable GetLicenseByApplicationID(int applicationID)
        {
            DataTable localDrivingLicense = new DataTable();

            string query = @"select * from  LicenseBasicInfo where LicenseBasicInfo.ApplicationID = @ApplicationID ";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {

                        sqlCommand.Parameters.AddWithValue("@ApplicationID", applicationID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            localDrivingLicense.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

            return localDrivingLicense;
        }

        public static DataTable GetLicensesByDriverID(int driverID)
        {
            DataTable localDrivingLicenses = new DataTable();

            string query = @"select * from  LicenseBasicInfo where LicenseBasicInfo.DriverID = @DriverID";

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
                            localDrivingLicenses.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

            return localDrivingLicenses;
        }

        public static DataTable GetLicenseByLicenseID(int licenseID)
        {
            DataTable localDrivingLicense = new DataTable();

            string query = @"select * from Licenses where Licenses.LicenseID = @LicenseID ";

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
                            localDrivingLicense.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }

            return localDrivingLicense;
        }

        public static bool GetLicenseByID(int licenseID, ref int applicationID, ref int driverID, ref int licenseClass,
            ref bool isActive, ref int issueReason, ref int createdByUserID, ref DateTime issueDate,
            ref DateTime expirationDate, ref string notes,
           ref float paidFees)
        {
            var isFound = false;
            string query = @"select * from Licenses where LicenseID = @LicenseID";
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
                                applicationID = (int)sqlDataReader["ApplicationID"];
                                driverID = (int)sqlDataReader["DriverID"];
                                licenseClass = (int)sqlDataReader["LicenseClass"];
                                isActive = (bool)sqlDataReader["IsActive"];
                                createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                                issueDate = (DateTime)sqlDataReader["IssueDate"];
                                expirationDate = (DateTime)sqlDataReader["ExpirationDate"];
                                notes = (string)sqlDataReader["Notes"];
                                paidFees = (float)(decimal)sqlDataReader["PaidFees"];
                                issueReason = (int)(Byte)sqlDataReader["IssueReason"];
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

        public static bool UdpateLicense(int licenseID, int applicationID, int driverID, int licenseClass, bool isActive,
            int issueReason, int createdByUserID, DateTime issueDate, DateTime expirationDate, string notes,
            float paidFees)
        {
            int rowsAffected = 0;
            string query = @"USE [DVLD]
                                UPDATE [dbo].[Licenses]
                                   SET [ApplicationID] = @ApplicationID
                                      ,[DriverID] = @DriverID
                                      ,[LicenseClass] = @LicenseClass
                                      ,[IssueDate] = @IssueDate
                                      ,[ExpirationDate] = @ExpirationDate
                                      ,[Notes] = @Notes
                                      ,[PaidFees] = @PaidFees
                                      ,[IsActive] = @IsActive
                                      ,[IssueReason] = @IssueReason
                                      ,[CreatedByUserID] = @CreatedByUserID
                                 WHERE LicenseID = @LicenseID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ApplicationID", applicationID);
                        sqlCommand.Parameters.AddWithValue("@DriverID", driverID);
                        sqlCommand.Parameters.AddWithValue("@LicenseClass", licenseClass);
                        sqlCommand.Parameters.AddWithValue("@IssueDate", issueDate);
                        sqlCommand.Parameters.AddWithValue("@ExpirationDate", expirationDate);
                        sqlCommand.Parameters.AddWithValue("@Notes", notes); 
                        sqlCommand.Parameters.AddWithValue("@PaidFees", paidFees);
                        sqlCommand.Parameters.AddWithValue("@IsActive", isActive);
                        sqlCommand.Parameters.AddWithValue("@IssueReason", issueReason);
                        sqlCommand.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                        sqlCommand.Parameters.AddWithValue("@LicenseID", licenseID);

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

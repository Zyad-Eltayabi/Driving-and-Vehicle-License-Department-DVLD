﻿using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
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

        public static DataTable GetLicense(int localDrivingAppID)
        {
            DataTable localDrivingLicense = new DataTable();

            string query = @"select * from  LicenseBasicInfo where LicenseBasicInfo.ApplicationID = @LocalDrivingAppID ";

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


    }
}

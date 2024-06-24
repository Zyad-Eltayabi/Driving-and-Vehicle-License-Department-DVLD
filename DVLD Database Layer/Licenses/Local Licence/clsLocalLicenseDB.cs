using DVLD_Database_Layer.Connections;
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
    public static class clsLocalLicenseDB
    {

        public static int AddNewLocalLicense(int applicationID, int licenseClassID)
        {
            int LocalDrivingLicenseApplicationID = -1;

            string query = @"USE [DVLD]
                                INSERT INTO [dbo].[LocalDrivingLicenseApplications]
                                           ([ApplicationID]
                                           ,[LicenseClassID])
                                     VALUES
                                           (@ApplicationID
                                           ,@LicenseClassID); select SCOPE_IDENTITY();";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ApplicationID", applicationID);
                        sqlCommand.Parameters.AddWithValue("@LicenseClassID", licenseClassID);


                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            LocalDrivingLicenseApplicationID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {

            }
            return LocalDrivingLicenseApplicationID;
        }

        public static bool IsPersonHasALocalLicenseOfTheSameLicenseClass(int applicantPersonID, int licenseClassID)
        {
            bool isFound = false;
            string query = @"select newTable.LicenseClassID from 
					  (SELECT      LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
                        LocalDrivingLicenseApplications.ApplicationID, LocalDrivingLicenseApplications.LicenseClassID,
                        Applications.ApplicantPersonID, Applications.ApplicationStatus
                        FROM          LocalDrivingLicenseApplications INNER JOIN
                                              Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID) as newTable
					                          where newTable.ApplicantPersonID = @ApplicantPersonID and newTable.LicenseClassID = @LicenseClassID";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("ApplicantPersonID", applicantPersonID);
                        sqlCommand.Parameters.AddWithValue("LicenseClassID", licenseClassID);

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

        public static bool VerifyAValidLicense(int applicantPersonID, int licenseClassID)
        {
            bool isFound = false;
            string query = @"select newTable.ApplicationStatus from 
					  (SELECT      LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
                        LocalDrivingLicenseApplications.ApplicationID, LocalDrivingLicenseApplications.LicenseClassID,
                        Applications.ApplicantPersonID, Applications.ApplicationStatus
                        FROM          LocalDrivingLicenseApplications INNER JOIN
                      Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID) as newTable
					  where newTable.ApplicantPersonID = @ApplicantPersonID and newTable.LicenseClassID = @LicenseClassID and newTable.ApplicationStatus in (1,3)";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("ApplicantPersonID", applicantPersonID);
                        sqlCommand.Parameters.AddWithValue("LicenseClassID", licenseClassID);

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

        public static DataTable GetLocalDrivingLicenses()
        {
            DataTable localDrivingLicenses = new DataTable();

            string query = @"select * from LocalDrivingLicensesFullInfo";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
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

        public static DataTable GetLocalDrivingLicense(int localDrivingAppID)
        {
            DataTable localDrivingLicense = new DataTable();

            string query = @"select * from LocalDrivingLicensesFullInfo where [L.D.L.AppID] =@LocalDrivingAppID ";

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

        public static int GetApplicantPersonID(int localDrivingAppID)
        {
            int ApplicantPersonID = -1;

            string query = @"USE [DVLD]
                                SELECT   Applications.ApplicantPersonID
                                FROM          Applications INNER JOIN
                                LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
					            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", localDrivingAppID);


                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            ApplicantPersonID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {

            }
            return ApplicantPersonID;
        }


    }
}

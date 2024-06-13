using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Licenses.ApplicationTypes
{
    public static class clsApplicationTypesDB
    {
        public static DataTable GetApplicationTypes()
        {
            DataTable ApplicationTypes = new DataTable();
            string query = @"select * from ApplicationTypes";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            ApplicationTypes.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
            return ApplicationTypes;
        }

        public static bool UpdateApplicationType(int applicationTypeID, string applicationTypeTitle, float applicationFees)
        {
            int rowsAffected = 0;
            string query = @"USE [DVLD]
                            UPDATE [dbo].[ApplicationTypes]
                               SET [ApplicationTypeTitle] = @ApplicationTypeTitle
                                  ,[ApplicationFees] = @ApplicationFees
                             WHERE ApplicationTypeID = @ApplicationTypeID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("ApplicationTypeTitle", applicationTypeTitle);
                        sqlCommand.Parameters.AddWithValue("ApplicationFees",applicationFees);
                        sqlCommand.Parameters.AddWithValue("ApplicationTypeID", applicationTypeID);

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

        public static bool GetApplicationType(int applicationTypeID,ref string applicationTypeTitle,ref float applicationFees)
        {
            var isFound = false;
            string query = @"select * from ApplicationTypes where ApplicationTypes.ApplicationTypeID = @ApplicationTypeID";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@ApplicationTypeID", applicationTypeID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                isFound = true;
                                applicationTypeTitle = sqlDataReader.GetString(1);
                                applicationFees = float.Parse(sqlDataReader["ApplicationFees"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isFound;
        }


    }
}

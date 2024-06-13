using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Tests
{
    public static class clsTestTypesDB
    {
        public static DataTable GetTestTypes()
        {
            DataTable TestTypes = new DataTable();
            string query = @"select * from TestTypes";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            TestTypes.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {


            }
            return TestTypes;
        }

        public static bool UpdateTestType(int testTypeID, string testTypeTitle, string testTypeDescription, float testTypeFees)
        {
            int rowsAffected = 0;
            string query = @"USE [DVLD]
                                    UPDATE [dbo].[TestTypes]
                                       SET [TestTypeTitle] =  @TestTypeTitle
                                          ,[TestTypeDescription] = @TestTypeDescription
                                          ,[TestTypeFees] =  @TestTypeFees
                                     WHERE TestTypeID = @TestTypeID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("TestTypeTitle", testTypeTitle);
                        sqlCommand.Parameters.AddWithValue("TestTypeDescription", testTypeDescription);
                        sqlCommand.Parameters.AddWithValue("TestTypeFees", testTypeFees);
                        sqlCommand.Parameters.AddWithValue("TestTypeID", testTypeID);

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

        public static bool GetTestType(int testTypeID,ref string testTypeTitle,ref string testTypeDescription,ref float testTypeFees)
        {
            var isFound = false;
            string query = @"select * from TestTypes where TestTypes.TestTypeID = @TestTypeID";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@TestTypeID", testTypeID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                isFound = true;
                                testTypeTitle = sqlDataReader.GetString(1);
                                testTypeDescription = sqlDataReader.GetString(2);
                                testTypeFees = float.Parse(sqlDataReader["TestTypeFees"].ToString());
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

using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Users
{
    public static class clsUsersDB
    {
        public static DataTable GetUsers()
        {
            DataTable users = new DataTable();

            string query = @"SELECT      Users.UserID,
                            ISNULL(People.FirstName, '') + ' ' + ISNULL(People.SecondName, '')+ ' ' + ISNULL(People.ThirdName, '') + ' ' +
                            ISNULL(People.LastName, '') AS 'Full Name', 
                            Users.UserName, People.PersonID, Users.IsActive
                            FROM          Users INNER JOIN
                            People ON Users.PersonID = People.PersonID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            users.Load(sqlDataReader);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return users;
        }

        public static bool IsPersonAlreadyUser(int personID)
        {
            bool isFound = false;
            string query = @"SELECT PersonID FROM Users WHERE PersonID = @PersonID";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("PersonID", personID);

                        object result = sqlCommand.ExecuteScalar();

                        isFound = (result != null);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isFound;
        }

        public static int AddNewUser(int personID, string userName, string password, bool isActive)
        {
            int userID = -1;
            string query = @"USE [DVLD]
                                        INSERT INTO [dbo].[Users]
                                                   ([PersonID]
                                                   ,[UserName]
                                                   ,[Password]
                                                   ,[IsActive])
                                             VALUES
                                                   (@PersonID
                                                   ,@UserName
                                                   ,@Password
                                                   ,@IsActive);select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("PersonID", personID);
                        sqlCommand.Parameters.AddWithValue("UserName", userName);
                        sqlCommand.Parameters.AddWithValue("Password", password);
                        sqlCommand.Parameters.AddWithValue("IsActive", isActive);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            userID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return userID;
        }
    }
}

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

        public static bool UpdateUser(int userID, string userName, string password,bool isActive)
        {
            int rowsAffected = 0;
            string query = @"USE [DVLD]
                                        UPDATE [dbo].[Users]
                                              SET [UserName] = @UserName
                                              ,[Password] = @Password
                                              ,[IsActive] = @IsActive
                                         WHERE UserID = @UserID";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("UserName", userName);
                        sqlCommand.Parameters.AddWithValue("Password", password);
                        sqlCommand.Parameters.AddWithValue("IsActive", isActive);
                        sqlCommand.Parameters.AddWithValue("UserID", userID);

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

        public static bool GetUserByID(int userID,ref int personID, ref string userName,ref string password,ref bool isActive) 
        { 
            var isFound = false;
            string query = @"select * from Users where UserID = @UserID";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query,sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if (sqlDataReader.Read())
                            {
                                isFound = true;
                                personID = sqlDataReader.GetInt32(1);
                                userName = sqlDataReader.GetString(2);
                                password = sqlDataReader.GetString(3);
                                isActive = sqlDataReader.GetBoolean(4);
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

        public static bool DeleteUser(int userID)
        {
            string query = @"delete from Users where UserID = @UserID";
            int rowsAffected = 0;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@UserID", userID);
                        rowsAffected = (int)sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

               
            }
            return rowsAffected > 0;
        }

        public static string GetUserName(int userID)
        {
            string userName = "";

            string query = @"select Users.UserName from Users where UserID =@UserID ;";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@UserID", userID);


                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            userName = result.ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
            return userName;
        }

    }
}

using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Login
{
    public static class clsLoginDB
    {
        public static bool IsExists(ref int userID, ref int personID, string userName, string password)
        {
            bool isFound = false;
            string query = @"select * from Users where UserName = @UserName and Password = @Password";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@UserName", userName);
                        sqlCommand.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            if(sqlDataReader.Read())
                            {
                                userID = int.Parse(sqlDataReader["UserID"].ToString());
                                personID = int.Parse(sqlDataReader["PersonID"].ToString());
                                isFound = true;
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

        public static bool IsActive(string userName, string password)
        {
            bool isActive = false;
            string query = @"select Users.IsActive from Users where UserName = @UserName and Password = @Password";
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@UserName", userName);
                        sqlCommand.Parameters.AddWithValue("@Password", password);

                        object result = sqlCommand.ExecuteScalar();


                        isActive = Convert.ToBoolean(result);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return isActive;
        }

    }
}

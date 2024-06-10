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
    }
}

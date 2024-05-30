using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.People
{
    public static class clsPeopleDB
    {
        public static DataTable GetAllPeople()
        {
            SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString);
            string query = @"select * from People";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            DataTable People = new DataTable();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataAdapter = cmd.ExecuteReader();
                People.Load(sqlDataAdapter);
                sqlDataAdapter.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConnection.Close();
            }
            return People;
         }
    }
}

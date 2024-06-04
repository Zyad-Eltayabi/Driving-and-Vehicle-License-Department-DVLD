using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Countries
{
    public class clsCountriesDB
    {
        public static DataTable GetAllCountries()
        {
            SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString);
            string query = @"select * from Countries";
            SqlCommand cmd = new SqlCommand(query,sqlConnection);
            DataTable Countries = new DataTable();
            try
            {
                sqlConnection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                Countries.Load(sqlDataReader);
                sqlDataReader.Close();
            }
            catch (Exception)
            {

                
            }
            finally
            {
                sqlConnection.Close();
            }
            return Countries;
        }
    }
}

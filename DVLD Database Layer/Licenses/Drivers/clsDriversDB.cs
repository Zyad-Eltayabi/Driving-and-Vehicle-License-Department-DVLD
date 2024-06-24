using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Database_Layer.Licenses.Drivers
{
    public static class clsDriversDB
    {
        public static int AddNewDriver(int personID, int createdByUserID)
        {
            int driverID = -1;
            string query = @"USE [DVLD]
                            INSERT INTO [dbo].[Drivers]
                                       ([PersonID]
                                       ,[CreatedByUserID]
                                       ,[CreatedDate])
                                 VALUES
                                       (@PersonID
                                       ,@CreatedByUserID
                                       ,@CreatedDate);select SCOPE_IDENTITY();";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("PersonID", personID);
                        sqlCommand.Parameters.AddWithValue("CreatedByUserID", createdByUserID);
                        sqlCommand.Parameters.AddWithValue("CreatedDate", DateTime.Now);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            driverID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }

            return driverID;
        }

        public static int GetDriverID(int personID)
        {
            int driverID = -1;
            string query = @"select Drivers.DriverID from Drivers where PersonID = @PersonID;";

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("PersonID", personID);

                        object result = sqlCommand.ExecuteScalar();

                        if (result != null)
                            driverID = int.Parse(result.ToString());
                    }
                }
            }
            catch (Exception)
            {
            }

            return driverID;
        }

    }
}

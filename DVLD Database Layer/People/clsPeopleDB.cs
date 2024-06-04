using DVLD_Database_Layer.Connections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
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

        public static bool IsNationalityNumberExists(string nationalityNumber)
        {
            bool isFound = false;
            SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString);
            string query = @"select NationalNo from People where NationalNo = @NationalNo";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@NationalNo", nationalityNumber);
            try
            {
                sqlConnection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    isFound = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sqlConnection.Close();
            }
            return isFound;
        }

        public static int AddNewPerson(string nationalNo, string firstName, string secondName,
            string thirdName, string lastName, DateTime dateOfBirth, int gendor, string address, string phone,
            string email, int nationalityCountryID, string imagePath)
        {
            int ID = -1;
            SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectionString);
            string query = @"USE [DVLD]
                            INSERT INTO [dbo].[People]
                                       ([NationalNo]
                                       ,[FirstName]
                                       ,[SecondName]
                                       ,[ThirdName]
                                       ,[LastName]
                                       ,[DateOfBirth]
                                       ,[Gendor]
                                       ,[Address]
                                       ,[Phone]
                                       ,[Email]
                                       ,[NationalityCountryID]
                                       ,[ImagePath])
                                 VALUES
                                       (@NationalNo
                                       ,@FirstName
                                       ,@SecondName
                                       ,@ThirdName
                                       ,@LastName
                                       ,@DateOfBirth
                                       ,@Gendor
                                       ,@Address
                                       ,@Phone
                                       ,@Email
                                       ,@NationalityCountryID
                                       ,@ImagePath); select SCOPE_IDENTITY();";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@NationalNo", nationalNo);
            sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
            sqlCommand.Parameters.AddWithValue("@SecondName", secondName);
            sqlCommand.Parameters.AddWithValue("@ThirdName", thirdName);
            sqlCommand.Parameters.AddWithValue("@LastName", lastName);
            sqlCommand.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            sqlCommand.Parameters.AddWithValue("@Gendor", gendor);
            sqlCommand.Parameters.AddWithValue("@Address", address);
            sqlCommand.Parameters.AddWithValue("@Phone", phone);
            sqlCommand.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);

            if (string.IsNullOrEmpty(email))
            {
                sqlCommand.Parameters.AddWithValue("@Email", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@Email", email);
            }

            if (string.IsNullOrEmpty(imagePath))
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                sqlCommand.Parameters.AddWithValue("@ImagePath", imagePath);
            }

            try
            {
                sqlConnection.Open();
                object result = sqlCommand.ExecuteScalar();
                if(result != null ) 
                    ID = int.Parse(result.ToString());
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return ID;
        }
    }
}

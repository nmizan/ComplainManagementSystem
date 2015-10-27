using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace ComplainRegistrationSystem.DAL
{
    public class LoginGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ComplainCon"].ConnectionString;

        public string[] Login(string userId, string password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select UserName,UserType From UserAccount Where UserID = '" + userId + "' AND Password ='" + password + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            string [] ud=new string[2];
           
           if (reader.Read())
            {
                ud[0] = reader.GetValue(0).ToString();
                ud[1] = reader.GetValue(1).ToString();
               
                
            }
            reader.Close();
            connection.Close();
            return ud;

        }

        public string GetPassword(string username)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select Password From UserAccount Where UserName = '" + username + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            string password = "";
            while (reader.Read())
            {
                password = reader.GetValue(0).ToString();

                break;
            }
            reader.Close();
            connection.Close();
            return password;
        }

        public void UpdatePassword(string username,string value)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Update UserAccount Set Password='"+value+"'  Where UserName = '" + username + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            
            connection.Close();
         

        }
    }
}
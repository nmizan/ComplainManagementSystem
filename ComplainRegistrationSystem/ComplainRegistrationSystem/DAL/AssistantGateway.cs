using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.DAL
{
    public class AssistantGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ComplainCon"].ConnectionString;

        public int Save(Assistant aAssistant)
        {

            string query = string.Format(@"INSERT INTO AssistantDetails(AssistantID,AsstName,ContactNo,AsstType) VALUES('{0}','{1}','{2}','{3}')",aAssistant.AssistantId, aAssistant.AsstName, aAssistant.ContactNo, aAssistant.AsstType);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        //public bool IsAssistantIdExists(Assistant aAssistant)
        //{
        //    bool isAssistantIdExists = false;
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    string query = "Select AssistantID  From AssistantDetails Where AssistantID='" + aAssistant.AssistantId + "'";
        //    SqlCommand command = new SqlCommand(query, connection);
        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    while (reader.Read())
        //    {

        //        isAssistantIdExists = true;
        //        break;
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return isAssistantIdExists;


        //}

       
        public List<Assistant> ShowAllAssistant()
        {
            List<Assistant> assistantsList = new List<Assistant>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select AssistantID,AsstName,ContactNo,AsstType From AssistantDetails ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Assistant aAssistant = new Assistant();
                aAssistant.AssistantId = reader["AssistantID"].ToString();
                aAssistant.AsstName = reader["AsstName"].ToString();
                aAssistant.ContactNo = reader["ContactNo"].ToString();
                aAssistant.AsstType = reader["AsstType"].ToString();

                assistantsList.Add(aAssistant);

            }
            reader.Close();
            connection.Close();
            return assistantsList;

        }
        public int Delete(string assistId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM AssistantDetails WHERE AssistantID =@assistId ", connection);
            cmd.Parameters.AddWithValue("@assistId", assistId);
            connection.Open();
            int n = cmd.ExecuteNonQuery();
            connection.Close();
            return n;

        }
        public int Update(string  assistId, string assistName, string assistType, string contctNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Update AssistantDetails Set AsstName=@assistname, ContactNo=@cntct, AsstType=@assistType WHERE AssistantID =@assistId ", connection);
            cmd.Parameters.AddWithValue("@assistId", assistId);
            cmd.Parameters.AddWithValue("@assistname", assistName);
            cmd.Parameters.AddWithValue("@assistType", assistType);
            cmd.Parameters.AddWithValue("@cntct", contctNo);

            connection.Open();
            int n = cmd.ExecuteNonQuery();
            connection.Close();
            return n;
        }
        public List<Assistant> GetAssistantsByType(string type)
        {
            List<Assistant> assistantsList = new List<Assistant>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select AssistantID,AsstName,ContactNo,AsstType From AssistantDetails where AsstType ='" + type + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Assistant aAssistant = new Assistant();
                aAssistant.AssistantId = reader["AssistantID"].ToString();
                aAssistant.AsstName = reader["AsstName"].ToString();
                aAssistant.ContactNo = reader["ContactNo"].ToString();
                aAssistant.AsstType = reader["AsstType"].ToString();

               
                assistantsList.Add(aAssistant);

            }
            reader.Close();
            connection.Close();
            return assistantsList;



        }
    }
}
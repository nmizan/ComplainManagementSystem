using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem.DAL
{
    
    public class ComplainGateway
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ComplainCon"].ConnectionString;

        public int Save(Complain aComplain)
        {
          
            string query = string.Format(@"INSERT INTO Complain(ComplainID,PersonName,HostelNo,RoomNo,Category,Subject,Summary,Priority,DateOfComplain,Status,ContactNo,Remarks) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')", aComplain.ComplainId, aComplain.PersonName, aComplain.HostelNo, aComplain.RoomNo, aComplain.Category,aComplain.Subject, aComplain.Summary, aComplain.Priority, aComplain.DateOfComplain, aComplain.Status, aComplain.ContactNo,aComplain.Remarks);
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<Complain> ShowAllComplain()
        {
            List<Complain> complainList = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From Complain Order By DateOfComplain Desc";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            
            while (reader.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = reader["ComplainID"].ToString();
                aComplain.PersonName = reader["PersonName"].ToString();
                aComplain.HostelNo = int.Parse(reader["HostelNo"].ToString());
                aComplain.RoomNo = int.Parse(reader["RoomNo"].ToString());
                aComplain.Category = reader["Category"].ToString();
                aComplain.Subject = reader["Subject"].ToString();
                aComplain.Summary = reader["Summary"].ToString();
                aComplain.Priority = reader["Priority"].ToString();
                aComplain.DateOfComplain =DateTime.Parse(reader["DateOfComplain"].ToString());
                aComplain.Status = reader["Status"].ToString();
                aComplain.ContactNo = reader["ContactNo"].ToString();
                aComplain.AssistantName = reader["AssistantName"].ToString();
                string remAll = reader["Remarks"].ToString();
                if (remAll.Length > 10)
                {
                    aComplain.Remarks = remAll.Substring(0,10);
                }
                else
                {
                    aComplain.Remarks = remAll;
                }
                aComplain.AssistantContact = reader["AssistantContact"].ToString();
                complainList.Add(aComplain);
                
            }
            reader.Close();
            connection.Close();
            return complainList;



        }
        public List<Complain> GetComplainByall(string allThings,string textB)
        {
            List<Complain>allShowBy=new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query="";
            if (allThings.ToString() == "All")
                query = "Select * From Complain Order By DateOfComplain Desc";
            else if (allThings.ToString()=="ComplainID")
                query = "Select * From Complain where ComplainID like'%"+textB+ "%'Order By DateOfComplain Desc";
            else if (allThings.ToString() == "PersonName")
                query = "Select * From Complain where PersonName like '%" + textB + "%'Order By DateOfComplain Desc";
            else if (allThings.ToString() == "RoomNo")
                query = "Select * From Complain where RoomNo like '%" + textB + "%'Order By DateOfComplain Desc";
            else if (allThings.ToString() == "Category")
                query = "Select * From Complain where Category like'%" + textB + "%'Order By DateOfComplain Desc";
            else if(allThings.ToString() == "Status")
                query = "Select * From Complain where Status like'%" + textB + "%'Order By DateOfComplain Desc";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader= command.ExecuteReader();
            while (reader.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = reader["ComplainID"].ToString();
                aComplain.PersonName = reader["PersonName"].ToString();
                aComplain.HostelNo = int.Parse(reader["HostelNo"].ToString());
                aComplain.RoomNo = int.Parse(reader["RoomNo"].ToString());
                aComplain.Category = reader["Category"].ToString();
                aComplain.Subject = reader["Subject"].ToString();
                aComplain.Summary = reader["Summary"].ToString();
                aComplain.Priority = reader["Priority"].ToString();
                aComplain.DateOfComplain = DateTime.Parse(reader["DateOfComplain"].ToString());
                aComplain.Status = reader["Status"].ToString();
                aComplain.ContactNo = reader["ContactNo"].ToString();
                aComplain.AssistantName = reader["AssistantName"].ToString();
                string remAll = reader["Remarks"].ToString();
                if (remAll.Length > 10)
                {
                    aComplain.Remarks = remAll.Substring(0, 10);
                }
                else
                {
                    aComplain.Remarks = remAll;
                }
                aComplain.AssistantContact = reader["AssistantContact"].ToString();
                allShowBy.Add(aComplain);
            }

            reader.Close();
            connection.Close();
            return allShowBy;



        }
       
    
        public string Update(string compId,string pName,int hNo,int rNo,string catg,string subj,string sumry,string priority,string cntctNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Update Complain Set PersonName=@pname, HostelNo=@hno, RoomNo=@rno, Category=@cat, Subject=@sub, Summary=@sum, Priority=@prio, ContactNo=@contct WHERE ComplainID =@comId ", connection);
            cmd.Parameters.AddWithValue("@comId", compId);
            cmd.Parameters.AddWithValue("@pname", pName);
            cmd.Parameters.AddWithValue("@hno", hNo);
            cmd.Parameters.AddWithValue("@rno", rNo);
            cmd.Parameters.AddWithValue("@cat", catg);
            cmd.Parameters.AddWithValue("@sub", subj);
            cmd.Parameters.AddWithValue("@sum", sumry);
            cmd.Parameters.AddWithValue("@prio", priority);
            cmd.Parameters.AddWithValue("@contct", cntctNo);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            return "WellDone";

        }
        public Complain DropInGrid(string cid)
        {
            Complain dAll = new Complain();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select hostelNo,Category,Priority from complain where complainId='" + cid + "'", connection);
            connection.Open();
            SqlDataReader dr2 = cmd.ExecuteReader();
            if (dr2.Read())
            { 
            dAll.HostelNo = int.Parse(Convert.ToString(dr2.GetValue(0)));
            dAll.Category = dr2["Category"].ToString();
            dAll.Priority = dr2["Priority"].ToString();
            }
            connection.Close();
            return dAll;
            

        }


    }
}
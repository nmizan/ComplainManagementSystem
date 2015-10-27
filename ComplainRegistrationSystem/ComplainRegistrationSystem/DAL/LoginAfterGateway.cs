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
    public class LoginAfterGateway
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["ComplainCon"].ConnectionString;
        private SqlDataReader dr;

        public List<Assistant> GetAssistantData()
        {
            List<Assistant> AssistList = new List<Assistant>();

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select AsstName,AsstType From AssistantDetails", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Assistant aAssistant = new Assistant();
                aAssistant.AsstName = dr.GetValue(0).ToString();
                aAssistant.AsstType = dr.GetValue(1).ToString();
                aAssistant.AsstName = dr.GetValue(0).ToString() + " (" + dr.GetValue(1).ToString() + " )";
                AssistList.Add(aAssistant);

            }


            dr.Close();
            connection.Close();
            return AssistList;

        }

        public List<Assistant> ViewInGridView(string aName)
        {
            List<Assistant> aViewInGridView = new List<Assistant>();
            SqlConnection connection = new SqlConnection(connectionString);
            string querry = "Select AssistantID,ContactNo,SolvingReq,PendingReq from AssistantDetails where AsstName ='" + aName +
                "'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Assistant aViewLabel = new Assistant();
                aViewLabel.AssistantId = dr.GetValue(0).ToString();
                aViewLabel.ContactNo = Convert.ToString(dr.GetValue(1));
                string aname = Convert.ToString(dr.GetValue(2));
                if (aname == "")
                {
                    aViewLabel.SolvingReq = 0;
                }
                else
                {
                    aViewLabel.SolvingReq = int.Parse(aname);
                }
                string ano = Convert.ToString(dr.GetValue(3));
                if (ano == "")
                {
                    aViewLabel.PendingReq = 0;
                }
                else
                {
                    aViewLabel.PendingReq = int.Parse(ano);
                }

                aViewInGridView.Add(aViewLabel);
            }

            dr.Close();
            connection.Close();
            return aViewInGridView;

        }

        public List<Complain> ViewInGridView()
        {
            List<Complain> aGridView = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * From Complain", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Complain aComplain = new Complain();
                aComplain.ComplainId = dr.GetValue(0).ToString();
                aComplain.PersonName = dr.GetValue(1).ToString();
                aComplain.HostelNo = int.Parse(dr.GetValue(2).ToString());
                aComplain.RoomNo = int.Parse(dr.GetValue(3).ToString());
                aComplain.Category = dr.GetValue(4).ToString();
                aComplain.Subject = dr.GetValue(5).ToString();
                aComplain.Summary = dr.GetValue(6).ToString();
                aComplain.Priority = dr.GetValue(7).ToString();
                aComplain.DateOfComplain = DateTime.Parse(dr.GetValue(8).ToString());
                aComplain.Status = dr.GetValue(9).ToString();
                aComplain.ContactNo = dr.GetValue(10).ToString();
                aComplain.AssistantName = dr.GetValue(11).ToString();
                string rem = dr.GetValue(12).ToString();
                string rema = "";
                if (rem.Length > 10)
                    rema = rem.Substring(0, 10);
                else
                {
                    rema = rem;
                }
                aComplain.Remarks = rema;
                aComplain.AssistantContact = dr.GetValue(13).ToString();
                aComplain.full = rem;
                aGridView.Add(aComplain);


            }

            dr.Close();
            connection.Close();
            return aGridView;

        }

        public List<Complain> ViewInLabelReq()
        {
            List<Complain> aViewInLabel = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select status from Complain", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            Complain aView = new Complain();
            while (dr.Read())
            {


                if (dr.GetValue(0).ToString() == "New")
                {
                    aView.NewReq++;
                }
                else if (dr.GetValue(0).ToString() == "Pending")
                {
                    aView.PenReq++;
                }
                else if (dr.GetValue(0).ToString() == "Solved")
                {
                    aView.SolReq++;
                }

                else if (dr.GetValue(0).ToString() == "Closed")
                {
                    aView.CanReq++;
                }


            }
            aViewInLabel.Add(aView);
            dr.Close();
            connection.Close();
            return aViewInLabel;
        }

        public List<Complain> GridViewChangeByLink(string reqType)
        {
            List<Complain> aChange = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Complain where Category='" + reqType + "'", connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Complain abComplain = new Complain();
                abComplain.ComplainId = dr.GetValue(0).ToString();
                abComplain.PersonName = dr.GetValue(1).ToString();
                abComplain.HostelNo = int.Parse(dr.GetValue(2).ToString());
                abComplain.RoomNo = int.Parse(dr.GetValue(3).ToString());
                abComplain.Category = dr.GetValue(4).ToString();
                abComplain.Subject = dr.GetValue(5).ToString();
                abComplain.Summary = dr.GetValue(6).ToString();
                abComplain.Priority = dr.GetValue(7).ToString();
                abComplain.DateOfComplain = DateTime.Parse(dr.GetValue(8).ToString());
                abComplain.Status = dr.GetValue(9).ToString();
                abComplain.ContactNo = dr.GetValue(10).ToString();
                abComplain.AssistantName = dr.GetValue(11).ToString();
                string viewRem = dr.GetValue(12).ToString();
                if (viewRem.Length > 10)
                    abComplain.Remarks = viewRem.Substring(0, 10);
                else
                {
                    abComplain.Remarks = viewRem;
                }
                abComplain.AssistantContact = dr.GetValue(13).ToString();
                aChange.Add(abComplain);
            }
            dr.Close();
            connection.Close();
            return aChange;

        }

        public List<Complain> GridByReq(string reqStatus, string cate)
        {
            List<Complain> aChange = new List<Complain>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd =
                new SqlCommand("select * from Complain where Status='" + reqStatus + "'And Category ='" + cate + "'",
                    connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Complain abComplain = new Complain();
                abComplain.ComplainId = dr.GetValue(0).ToString();
                abComplain.PersonName = dr.GetValue(1).ToString();
                abComplain.HostelNo = int.Parse(dr.GetValue(2).ToString());
                abComplain.RoomNo = int.Parse(dr.GetValue(3).ToString());
                abComplain.Category = dr.GetValue(4).ToString();
                abComplain.Subject = dr.GetValue(5).ToString();
                abComplain.Summary = dr.GetValue(6).ToString();
                abComplain.Priority = dr.GetValue(7).ToString();
                abComplain.DateOfComplain = DateTime.Parse(dr.GetValue(8).ToString());
                abComplain.Status = dr.GetValue(9).ToString();
                abComplain.ContactNo = dr.GetValue(10).ToString();
                abComplain.AssistantName = dr.GetValue(11).ToString();
                string viewRem = dr.GetValue(12).ToString();
                if (viewRem.Length > 10)
                    abComplain.Remarks = viewRem.Substring(0, 10);
                else
                {
                    abComplain.Remarks = viewRem;
                }
                abComplain.AssistantContact = dr.GetValue(13).ToString();
                aChange.Add(abComplain);
            }
            dr.Close();
            connection.Close();
            return aChange;

        }

        public string ChangedByCan(string[] abc, string status)
        {
            int i = 0;

            for (i = 0; i < abc.Length; i++)
            {
                string cid = abc[i];
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("update complain set status=@som where ComplainId ='" + cid + "'",
                    connection);
                cmd.Parameters.AddWithValue("@som", status);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return status;
        }

        public DataTable SearchByDate(string dat1, string dat2)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select * From Complain where DateOfComplain between @sd and @ed",
                connection);
            cmd.Parameters.AddWithValue("@sd", dat1.Trim());
            cmd.Parameters.AddWithValue("@ed", dat2.Trim());

            DataTable dt = new DataTable();

            connection.Open();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            connection.Close();
            return dt;


        }

        public string AllocateAssistant(List<Complain> allocat, string[] cid)
        {
            String name = "";
            string remarks = "";
            string cid1 = "";
            string pendin = "";


            List<Complain> aAllocate = allocat;
            foreach (Complain al in aAllocate)
            {
                name = al.AssistantName;
                remarks = al.Remarks;
                pendin = al.Status;
            }
            for (int i = 0; i < cid.Length; i++)
            {

                cid1 = cid[i];

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd =
                    new SqlCommand(
                        "Update Complain set AssistantName=@aname,Remarks=@rem,Status=@pen where ComplainId= '" + cid1 +
                        "'", connection);
                cmd.Parameters.AddWithValue("@aname", name);
                cmd.Parameters.AddWithValue("@rem", remarks);
                cmd.Parameters.AddWithValue("@pen", pendin);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            return "Succcessfully Allocated";

        }

        public List<string> PopulateDropDown()
        {
            List<string> aAlldrop = new List<string>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("Select distinct Category from complain where category is not null",
                connection);
            connection.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                string cat = (string)dr["Category"];
                aAlldrop.Add(cat);
            }
            dr.Close();
            connection.Close();
            return aAlldrop;

        }

        public string GetAllRemarks(string iid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string querry = "Select Remarks from complain where Complainid='" + iid + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            con.Open();
            string remarks = "";
            string rem = "";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                rem = dr["Remarks"].ToString();
                if (rem != "")
                {
                    remarks = rem;
                }
                else
                {
                    remarks = "Sorry! No Remarks Available";
                }
                dr.Close();
                con.Close();
            }
            return remarks;
        }

        public string GiveRemarks(string allRem, string id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string querry = "Update complain set Remarks=@rem where Complainid='" + id + "'";
            SqlCommand cmd = new SqlCommand(querry, con);
            cmd.Parameters.AddWithValue("@rem", allRem);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Succcessfully Updating Remarks";
        }

        public Assistant ChangeReqLAM(string aName)
        {
            Assistant ab = new Assistant();
            SqlConnection connect = new SqlConnection(connectionString);
            string querree = "Select SolvingReq,PendingReq from AssistantDetails where AsstName ='" + aName.Trim() + "'";
            SqlCommand cmd1 = new SqlCommand(querree, connect);
            connect.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                string que = Convert.ToString(dr1["SolvingReq"]);
                if (que != "")
                {
                    ab.SolvingReq = int.Parse(que);

                }
                else
                {
                    ab.SolvingReq = 0;
                }
                string q = Convert.ToString(dr1["PendingReq"]);
                if (q != "")
                {
                    ab.PendingReq = int.Parse(q);
                }
                else
                {
                    ab.PendingReq = 0;
                }
            }
            dr1.Close();
            connect.Close();
            return ab;

        }

        public string UpdateAssisGridViewReq(int penR, int newR, string aName)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string quer = "";

            if (newR > -1)
            {
                quer = "Update AssistantDetails set SolvingReq=@sNew,PendingReq=@pReq where AsstName='" + aName + "'";

            }

            SqlCommand cmd = new SqlCommand(quer, con);
            cmd.Parameters.AddWithValue("@sNew", newR);
            cmd.Parameters.AddWithValue("@pReq", penR);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Done";
        }
        
           
    }
}
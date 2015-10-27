using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem
{
    public partial class ViewComplainByManager1 : System.Web.UI.Page
    {
        private LoginAfterManager aManagerBal = new LoginAfterManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Session["msg"] = "Sorry!! UnAuthentication Access....";
                Response.Redirect("LoginPage.aspx");

            }
            if (!IsPostBack)
            {
                List<Assistant> aAssistants = aManagerBal.GetAssistantData();
                searchAssisDropDownList0.Items.Clear();
                searchAssisDropDownList0.Items.Add("Select");
                solvedButton.Visible = false;
                CancelButton.Visible = false;

                foreach (Assistant a1 in aAssistants)
                {
                    searchAssisDropDownList0.Items.Add(a1.AsstName);
                }

                List<Complain> lb = aManagerBal.ViewInReq();
                foreach (Complain l in lb)
                {
                    NR_L1.Text = l.NewReq.ToString();
                    P_L2.Text = l.PenReq.ToString();
                    S_Ll3.Text = l.SolReq.ToString();
                    C_L4.Text = l.CanReq.ToString();
                }
                PopulateSearchDrop();
                EditRemPanel4.Visible = false;
                RemarksViewPanel3.Visible = false;


            }
        }
        protected void viewComplainButton_Click(object sender, EventArgs e)
        {
            List<Complain> b = aManagerBal.ViewInGridview();
            solvedButton.Visible = true;
            CancelButton.Visible = true;
            complainGridView1.DataSource = b;
            complainGridView1.DataBind();
        }

        protected void Nreq_LinkButton1_Click(object sender, EventArgs e)
        {
            Panel2.Visible = true;
            Label5.Visible = true;
            Label7.Visible = true;
            searchAssisDropDownList0.Visible = true;
            summaryTextBox.Visible = true;
            allocateButton.Visible = true;
            string cate = "";
            if (searchCatDropDownList0.SelectedIndex > 0)
                cate = searchCatDropDownList0.SelectedItem.Text;
            else
            {
                Please_Select_Label7.Text = "Please Select A value in drop downlist first";
            }
            List<Complain> te = aManagerBal.ReqTyp("New", cate);
            //complainGridView1.Columns[9].Visible = false;
            solvedButton.Visible = false;
            CancelButton.Visible = true;
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            Session["status"] = "New";
        }

        protected void pendingReqLinkButton_Click(object sender, EventArgs e)
        {
            Label5.Visible = false;
            Label7.Visible = false;
            searchAssisDropDownList0.Visible = false;
            summaryTextBox.Visible = false;
            Panel2.Visible = true;
            allocateButton.Visible = false;
            string cat = "";
            if (searchCatDropDownList0.SelectedIndex > 0)
                cat = searchCatDropDownList0.SelectedItem.Text;
            else
            {
                Please_Select_Label7.Text = "Please Select A value in drop downlist first";
            }
            //Session["DropPen"] = cat;

            List<Complain> te = aManagerBal.ReqTyp("Pending", searchCatDropDownList0.SelectedItem.Text);
            solvedButton.Visible = true;
            CancelButton.Visible = true;
            //complainGridView1.Columns[9].Visible = false;
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            Session["status"] = "Pending";
        }

        protected void solvedReqLinkButton_Click(object sender, EventArgs e)
        {
            ViewState["Sol"] = "Sol";
            Panel2.Visible = true;
            Label5.Visible = false;
            Label7.Visible = false;
            allocateButton.Visible = false;
            searchAssisDropDownList0.Visible = false;
            summaryTextBox.Visible = false;
            CancelButton.Visible = false;
            solvedButton.Visible = false;
            string catSol = "";
            if (searchCatDropDownList0.SelectedIndex > 0)
                catSol = searchCatDropDownList0.SelectedItem.Text;
            else
            {
                Please_Select_Label7.Text = "Please Select A value in drop downlist first";
            }


            List<Complain> te = aManagerBal.ReqTyp("Solved", catSol);
            Label6.Visible = false;
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            Session["status"] = "Solved";
        }

        protected void cancelReqLinkButton_Click(object sender, EventArgs e)
        {

            Panel2.Visible = true;
            solvedButton.Visible = false;
            CancelButton.Visible = false;
            Label5.Visible = false;
            Label7.Visible = false;
            allocateButton.Visible = false;
            searchAssisDropDownList0.Visible = false;
            summaryTextBox.Visible = false;
            string catCan = "";
            if (searchCatDropDownList0.SelectedIndex > 0)
                catCan = searchCatDropDownList0.SelectedItem.Text;
            else
            {
                Please_Select_Label7.Text = "Please Select A value in DropDownlist first";
            }
            List<Complain> te = aManagerBal.ReqTyp("Closed", catCan);
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
        }

        public void AllocateWithClick()
        {
            int r = complainGridView1.Rows.Count;
            string[] cid = new string[r];
            int j = 0;
            bool flag = false;
            for (int i = 0; i < r; i++)
            {
                CheckBox ch = (CheckBox)complainGridView1.Rows[i].FindControl("CheckBox1");
                Label l = (Label)complainGridView1.Rows[i].FindControl("Label2");

                if (ch.Checked == true)
                {
                    cid[j++] = l.Text;
                    flag = true;
                }
            }
            if (flag == true && searchAssisDropDownList0.SelectedIndex > 0 && summaryTextBox.Text != null)
            {
                List<Complain> aAllocate = new List<Complain>();
                Complain allocate = new Complain();
                string aName = searchAssisDropDownList0.SelectedItem.ToString();
                int bIn = aName.IndexOf("(");
                allocate.AssistantName = aName.Substring(0, bIn - 1);
                if (Session["UserName"] != null)
                {
                    allocate.Remarks = DateTime.Now.ToShortDateString() + ":" + "(" + Session["UserName"] + ")" + summaryTextBox.Text;
                }
                else
                {
                    allocate.Remarks = DateTime.Now.ToShortDateString() + ":" + "(  )" + summaryTextBox.Text;
                }

                allocate.Status = "Pending";
                aAllocate.Add(allocate);
                Session["name11"] = allocate.AssistantName;
                string msg = aManagerBal.AllocateFinal(aAllocate, cid);
                Please_Select_Label7.Text = j + " Row IS " + msg;
            }

            else
                Please_Select_Label7.Text = "Please Check The Box,Fill the textbox and select dropdownlist";

        }

        public void ChangeAssisGrid()
        {
            string aName = searchAssisDropDownList0.SelectedItem.ToString();
            int bIn = aName.IndexOf("(");
            string nam = aName.Substring(0, bIn - 1);
            Assistant tb = new Assistant();
            tb = aManagerBal.ChangeAssisGrid(nam);
            int newReq = tb.SolvingReq;
            int penReq = tb.PendingReq;
            string button = Session["na"].ToString();
            if (Session["na"].ToString() == "All")
            {
                newReq++;

            }
            else if (Session["na"].ToString() == "Sol")
            {
                if (newReq != 0)
                {
                    newReq = newReq - 1;
                    penReq = penReq + 1;
                }
                else
                {
                    newReq = 0;
                    penReq = penReq + 1;
                }


            }
            string all = aManagerBal.ChAssId(newReq, penReq, nam);
            List<Assistant> aLabelView = new List<Assistant>();
            aLabelView = aManagerBal.ViewInAssistantGrid(nam);
            assistantGridView1.DataSource = aLabelView;
            assistantGridView1.DataBind();
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            int r = complainGridView1.Rows.Count;
            string[] cid = new string[r];
            int j = 0;
            for (int i = 0; i < complainGridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)complainGridView1.Rows[i].FindControl("CheckBox1");
                Label l = (Label)complainGridView1.Rows[i].FindControl("Label2");

                if (ch.Checked == true)
                    cid[j++] = l.Text;

            }

            if (Session["status"].ToString() == "New")
            {
                string n = aManagerBal.ChangeBySol(cid, "Closed");
                if (searchCatDropDownList0.SelectedIndex > 0)
                {
                    List<Complain> te = aManagerBal.ReqTyp("New", searchCatDropDownList0.SelectedItem.Text);


                    complainGridView1.DataSource = te;
                    complainGridView1.DataBind();
                }

                List<Complain> lb = aManagerBal.ViewInReq();
                foreach (Complain l in lb)
                {
                    NR_L1.Text = l.NewReq.ToString();
                    C_L4.Text = l.CanReq.ToString();

                }
                Please_Select_Label7.Text = j + "  Status is Changed from new to Closed ";
            }
            else if (Session["status"].ToString() == "Pending")
            {
                string n = aManagerBal.ChangeBySol(cid, "Closed");
                List<Complain> te = aManagerBal.ReqTyp("Pending", searchCatDropDownList0.SelectedItem.Text);
                complainGridView1.DataSource = te;
                complainGridView1.DataBind();
                List<Complain> lb = aManagerBal.ViewInReq();
                foreach (Complain l in lb)
                {
                    S_Ll3.Text = l.SolReq.ToString();
                    C_L4.Text = l.CanReq.ToString();

                }
                Please_Select_Label7.Text = j + "  Status is Changed from Pending to Closed ";

            }
        }
        
        protected void solvedButton_Click(object sender, EventArgs e)
        {
            Session["na"] = "Sol";
            StatusViewById();
            ChangeAssisGrid();
        }

        public void StatusViewById()
        {

            int r = complainGridView1.Rows.Count;
            string[] cid = new string[r];
            int j = 0;
            for (int i = 0; i < complainGridView1.Rows.Count; i++)
            {
                CheckBox ch = (CheckBox)complainGridView1.Rows[i].FindControl("CheckBox1");
                Label l = (Label)complainGridView1.Rows[i].FindControl("Label2");

                if (ch.Checked == true)
                    cid[j++] = l.Text;

            }
            Please_Select_Label7.Text = j + "  Row is Updated";
            string n = aManagerBal.ChangeBySol(cid, "Solved");
            List<Complain> te = aManagerBal.ReqTyp("Pending", searchCatDropDownList0.SelectedItem.Text);
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();

            List<Complain> lb = aManagerBal.ViewInReq();
            foreach (Complain l in lb)
            {
                P_L2.Text = l.PenReq.ToString();
                S_Ll3.Text = l.SolReq.ToString();

            }

        }


        protected void searchCatDropDownList0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchCatDropDownList0.SelectedIndex > 0)
            {

                string reType = searchCatDropDownList0.SelectedItem.ToString();
                List<Complain> cd = aManagerBal.ChangeGridView(reType);
                complainGridView1.Columns[7].Visible = false;
                complainGridView1.Columns[8].Visible = false;
                complainGridView1.Columns[10].Visible = false;
                complainGridView1.Columns[8].Visible = false;
                complainGridView1.DataSource = cd;
                complainGridView1.DataBind();

            }
          
        }

        public void PopulateSearchDrop()
        {
            searchCatDropDownList0.Items.Clear();
            searchCatDropDownList0.Items.Add("Select");
            List<string> dc = aManagerBal.DropPopu();
            foreach (string x in dc)
            {
                searchCatDropDownList0.Items.Add(x);
            }

        }

        protected void searchDateButton_Click1(object sender, EventArgs e)
        {
            string sd = viewDateTextBox1.Text;
            string ed = viewDateTextBox2.Text;
            DataTable ddTime = aManagerBal.SearchByDate(sd, ed);
            complainGridView1.DataSource = ddTime;
            complainGridView1.DataBind();
        }

        protected void searchAssisDropDownList0_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (searchAssisDropDownList0.SelectedIndex > 0)
            {
                string nDrop = searchAssisDropDownList0.SelectedItem.ToString();
                int nameindex = nDrop.IndexOf("(");
                string oName1 = nDrop.Substring(0, nameindex - 1);
                List<Assistant> aLabelView = aManagerBal.ViewInAssistantGrid(oName1);
                assistantGridView1.DataSource = aLabelView;
                assistantGridView1.DataBind();

            }
        }

        protected void allocateButton_Click1(object sender, EventArgs e)
        {
            Session["na"] = "All";
            AllocateWithClick();
            List<Complain> te = aManagerBal.ReqTyp("New", searchCatDropDownList0.SelectedItem.Text);
            complainGridView1.DataSource = te;
            complainGridView1.DataBind();
            List<Complain> lb = aManagerBal.ViewInReq();
            foreach (Complain l in lb)
            {
                NR_L1.Text = l.NewReq.ToString();
                P_L2.Text = l.PenReq.ToString();

            }
            ChangeAssisGrid();
        }

        protected void complainGridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            complainGridView1.PageIndex = e.NewPageIndex;
            List<Complain> b = aManagerBal.ViewInGridview();
            solvedButton.Visible = true;
            CancelButton.Visible = true;
            complainGridView1.DataSource = b;
            complainGridView1.DataBind();
            Please_Select_Label7.Visible = false;


        }
        protected void complainGridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            RemarksViewPanel3.Visible = true;
            int r = e.NewSelectedIndex;
            Label id = (Label)complainGridView1.Rows[r].FindControl("Label2");
            ViewRemarksTextBox3.Text = aManagerBal.GetRemarks(id.Text);
            Session["idForRemarks"] = id.Text;
            Please_Select_Label7.Visible = false;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        protected void NewRemarksButton1_Click1(object sender, EventArgs e)
        {

            if (Session["idForRemarks"] != null)
            {

                string comId = Session["idForRemarks"].ToString();
                string dataRem = aManagerBal.GetRemarks(comId);
                string all = EditRemarksTextBox4.Text;
                string remarks = "";
                if (Session["UserName"] != null)
                {

                    remarks = dataRem + "(" + DateTime.Now.ToShortDateString() + ") By : Mr.(" + Session["UserName"] + ") : " + all;
                }
                else
                {
                    remarks = dataRem + "(" + DateTime.Now.ToShortDateString() + ") By : Mr.(  ) : " + all;
                }

                Please_Select_Label7.Visible = true;
                Please_Select_Label7.Text = aManagerBal.GiveRemarks(remarks, comId);
                RemarksViewPanel3.Visible = false;
                EditRemPanel4.Visible = false;

            }
        }

        protected void NewRemarksButton1_Click(object sender, EventArgs e)
        {
            EditRemPanel4.Visible = true;
            EditRemarksTextBox4.Text = "";
        }

       
    }
}
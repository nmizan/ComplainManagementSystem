using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem
{
    public partial class ComplainForm : System.Web.UI.Page
    {
        ComplainManager aManager = new ComplainManager();
        Complain aComplain = new Complain();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> complainList = new List<string>();

                complainList.Add("Select");
                complainList.Add("Electrical");
                complainList.Add("Cleaning");
                complainList.Add("Plumbing");
                complainList.Add("Carpenter");
                complainList.Add("Others");
                foreach (var list in complainList)
                {
                    categoryDropDownList.Items.Add(list);

                }


                List<string> priorityList = new List<string>();

                priorityList.Add("Select");
                priorityList.Add("High");
                priorityList.Add("Low");

                foreach (var list in priorityList)
                {
                    priorityDropDownList.Items.Add(list);
                }
                

            }
           
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (categoryDropDownList.SelectedItem.Text == "" || priorityDropDownList.SelectedItem.Text == "Select" ||
                nameTextBox.Text == "" ||
                hnoDropDownList1.SelectedItem.Text == "Select" || roomNoTextBox.Text == "" ||subjectTextBox.Text==""|| summaryTextBox.Text == "" || contactTextBox.Text == "")
            {
                msgLabel.Text = "please enter the value in the textbox.";

            }
            else
            {
                aComplain.ComplainId = RandomGenerateId(0,99999).ToString();
                aComplain.PersonName = nameTextBox.Text;
                aComplain.HostelNo = Convert.ToInt32(hnoDropDownList1.SelectedItem.Text);
                aComplain.RoomNo = Convert.ToInt32(roomNoTextBox.Text);
                if (categoryDropDownList.SelectedItem.Text != "Others")
                {
                    aComplain.Category = categoryDropDownList.SelectedItem.Text;
                }
                else
                {
                    aComplain.Category = otherTextBox.Text;
                }
                aComplain.Subject = subjectTextBox.Text;
                aComplain.Summary = summaryTextBox.Text;
                aComplain.Priority = priorityDropDownList.SelectedItem.Text;
                aComplain.DateOfComplain = DateTime.Now;
                aComplain.Status = "New";
                aComplain.ContactNo = contactTextBox.Text;
                aComplain.Remarks=DateTime.Now.ToShortDateString() +" ( Complain Registered By Mr." +Session["UserName"]+")";
                //if (ValidateContactNo())
                //{
                    msgLabel.Text = (aManager.Save(aComplain));
                    PopulateGridView();
                    complainGridView.Visible = true;
                    otherTextBox.Visible = false;
                    idLabel.Text = "Your Complain ID Is : " + aComplain.ComplainId;
                    ClearTextBox();
                //}
                //else
                //{
                //    msgLabel.Text = "Plz give the valid Contact No";
                //}
               
                

            }
        }
        public void ClearTextBox()
        {
           
            nameTextBox.Text = "";
            hnoDropDownList1.Items.Clear();
            roomNoTextBox.Text = "";
            categoryDropDownList.Items.Clear();
            subjectTextBox.Text = "";
            summaryTextBox.Text = "";
            priorityDropDownList.Items.Clear();
            contactTextBox.Text = "";
        }
        //public bool ValidateContactNo()
        //{
        //    bool flag = false;
        //    string contact = contactTextBox.Text;
        //    Regex regex = new Regex(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$");
        //    Match match = regex.Match(contact);
        //    if (match.Success)
        //    {
        //        flag = true;
        //    }
        //    return flag;
        //}
        public int RandomGenerateId(int min,int max)
        {
            Random random=new Random();
            return random.Next(min , max);
        }
        public void PopulateGridView()
        {
            complainGridView.DataSource = aManager.ShowAllComplain();
            complainGridView.DataBind();
        }
       
        protected void complainGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            complainGridView.PageIndex = e.NewPageIndex;
            PopulateGridView();
        }

        protected void complainGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            complainGridView.EditIndex = e.NewEditIndex; 
            complainGridView.DataSource = aManager.ShowAllComplain();
         
            complainGridView.DataBind();
        }

       
        protected void complainGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            complainGridView.DataSource = aManager.ShowAllComplain();
            complainGridView.EditIndex = -1;
            complainGridView.DataBind();
        }

        protected void complainGridView_RowUpdating1(object sender, GridViewUpdateEventArgs e)
        {
           
            
            int r = e.RowIndex;
           Complain bd = new Complain();

            Label t1 = (Label)complainGridView.Rows[r].FindControl("Label1");
            bd = aManager.DropGri(t1.Text);
            int t3 = bd.HostelNo;
            string t5 = bd.Category, t8 = bd.Priority;
            TextBox t2 = (TextBox)complainGridView.Rows[r].FindControl("pNameTextBox");
            DropDownList ch1 = (DropDownList)complainGridView.Rows[r].FindControl("hostelDropDownList");
           if (ch1.SelectedIndex > 0)
            {
                t3 = Convert.ToInt32(ch1.SelectedItem.ToString());
            }
            TextBox t4 = (TextBox)complainGridView.Rows[r].FindControl("roomTextBox");
            DropDownList cha1 = (DropDownList)complainGridView.Rows[r].FindControl("cateDropDownList");
            if (cha1.SelectedIndex > 0)
            {
                t5 = cha1.SelectedItem.ToString();
            }
            
            TextBox t6 = (TextBox)complainGridView.Rows[r].FindControl("subjectTextBox");
            TextBox t7 = (TextBox)complainGridView.Rows[r].FindControl("summaryTextBox");
            DropDownList c1 = (DropDownList)complainGridView.Rows[r].FindControl("PrioDrop");
            if (c1.SelectedIndex > 0)
            {
                t8 = c1.SelectedItem.ToString();
            }
            TextBox t9 = (TextBox)complainGridView.Rows[r].FindControl("contactTextBox");
            bool flag = aManager.Update(t1.Text, t2.Text,t3,int.Parse(t4.Text),t5,t6.Text, t7.Text, t8, t9.Text);
            if (flag == true)
         
            {
                msgLabel.Text = "Update Successfully";
                complainGridView.DataSource = aManager.ShowAllComplain();
                complainGridView.EditIndex = -1;
                complainGridView.DataBind();

            }
            else
            {
                msgLabel.Text = "Not Updated, Sorry!!!!!";
            }
        }

        protected void categoryDropDownList_SelectedIndexChanged1(object sender, EventArgs e)
        {

            if (categoryDropDownList.SelectedItem.ToString() == "Others")
            {
                otherTextBox.Visible = true;
            }
            else
            {
                otherTextBox.Visible = false;
            }
        }
    }
}
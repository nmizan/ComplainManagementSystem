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
    public partial class UserInfo1 : System.Web.UI.Page
    {
        private ManagerManager aManager=new ManagerManager();
        private UserAccount account=new UserAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserId"] == null)
            //{
            //    Session["msg"] = "Sorry!! UnAuthentication Access....";
            //    Response.Redirect("LoginPage.aspx");

            //}

            if (!IsPostBack)
            {
                List<string> typeList = new List<string>();
                typeList.Add("Hostel Manager");
                typeList.Add("Receptionist");
                typeDropDownList.Items.Add("Select");
                foreach (var list in typeList)
                {
                    typeDropDownList.Items.Add(list);
                }
                PopulateGridView();
            }
        }

       
        public void ClearTextBox()
        {
            userIdTextBox.Text = "";
            userNameTextBox.Text = "";
           
            userPassTextBox.Text = "";
            contactTextBox.Text = "";
            emailTextBox.Text = "";
        }

        public void PopulateGridView()
        {
            GridView1.DataSource = aManager.ShowAllUser();
            GridView1.DataBind();
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string utype = typeDropDownList.SelectedItem.Text;
            GridView1.DataSource = aManager.GetUserByType(utype);
            GridView1.DataBind();
            GridView1.Visible = true;

        }

        protected void addLinkButton_Click(object sender, EventArgs e)
        {
            int x = aManager.AddUserNew();
            userIdTextBox.Text = x.ToString();
            
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            string utype = typeDropDownList.SelectedItem.Text;
            GridView1.DataSource = aManager.GetUserByType(utype);
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int r = e.RowIndex;
            Label t1 = (Label)GridView1.Rows[r].FindControl("Label1");
            Label l1 = (Label) GridView1.Rows[r].FindControl("Label2");
            TextBox t2 = (TextBox)GridView1.Rows[r].FindControl("nameTextBox");
            TextBox t3 = (TextBox)GridView1.Rows[r].FindControl("emailTextBox");
            TextBox t4 = (TextBox)GridView1.Rows[r].FindControl("contactTextBox");


            bool flag = aManager.Update(int.Parse(t1.Text), l1.Text, t2.Text,t4.Text,t3.Text);
            if (flag == true)
            {
                msgLabel.Text = "Update Successfully";
                GridView1.DataSource = aManager.ShowAllUser();
                GridView1.EditIndex = -1;
                GridView1.DataBind();

            }
            else
            {
                msgLabel.Text = "Not Updated, Sorry!!!!!";
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            int row = e.RowIndex;
            Label lbl = (Label)GridView1.Rows[row].FindControl("Label1");

            int userId = Convert.ToInt32(lbl.Text);

            bool flag = aManager.Delete(userId);
            if (flag == true)
            {
                msgLabel.Text = "Delete Successfully !";
                GridView1.DataSource = aManager.ShowAllUser();
                GridView1.DataBind();


            }
            else
            {
                msgLabel.Text = "Not Deleted !";
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.DataSource = aManager.ShowAllUser();
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void saveButton_Click1(object sender, EventArgs e)
        {
           if (userIdTextBox.Text == "" || userNameTextBox.Text == "" || typeDropDownList.SelectedItem.Text == "" || userPassTextBox.Text == ""||emailTextBox.Text==""||contactTextBox.Text=="")
            {
                msgLabel.Text = "please enter the value";
            }
            else
            {
                account.UserId = userIdTextBox.Text;
                account.UserName = userNameTextBox.Text;
                account.UserType = typeDropDownList.SelectedItem.Text;
                account.Password = userPassTextBox.Text;
                account.Email = emailTextBox.Text;
                account.Contact = contactTextBox.Text;
                if(ValidateEmail())
                {
                   
                        msgLabel.Text = aManager.Save(account);
                        PopulateGridView();
                        ClearTextBox();
                        GridView1.Visible = true;
                   
                }
                else
                {
                    msgLabel.Text = "Plz enter valid Email";
                }
               
            }
        }

        public bool ValidateEmail()
        {
            bool flag = false;
            string email = emailTextBox.Text;
            Regex regex=new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
            {
                flag=true;
            }
            return flag;

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
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel1.Visible = false;
            Label2.Text = "New Password :";
            int nor = e.NewSelectedIndex;
            Label uid = (Label)GridView1.Rows[nor].FindControl("Label1");
            Label name = (Label)GridView1.Rows[nor].FindControl("Label3");
            ViewState["id"] = uid.Text;
            ViewState["na"] = name.Text;
        }

       
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            PopulateGridView();
        }

        protected void changePassButton0_Click(object sender, EventArgs e)
        {
            if (userIdTextBox.Text=="")
            {
                msgLabel.Text = "Pls fill up the ID";
            }
            else
            {
                string newPass = userIdTextBox.Text;
                msgLabel.Text = "Name : " + ViewState["na"] + "  - " + aManager.ChPassMg(ViewState["id"].ToString(), newPass);
                PopulateGridView();
            }
            

        }

        
    }
}
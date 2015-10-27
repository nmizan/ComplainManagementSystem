using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;

namespace ComplainRegistrationSystem
{
    public partial class LoginPage1 : System.Web.UI.Page
    {
        private LoginManager aLoginManager = new LoginManager();
        private UserAccount account = new UserAccount();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["msg"] != null)
            {
                msgLabel.Text = Session["msg"].ToString();
            }
            else
            {
                msgLabel.Text = null;
            }
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (userTextBox.Text == "" || passwordTextBox.Text == "")
            {
                msgLabel.Text = "Please Enter the Value";
                return;

            }
            
                account.UserId = userTextBox.Text;
                account.Password = passwordTextBox.Text;


                string []ud= aLoginManager.Login(account.UserId, account.Password);
           
                if( ud[0]!= null && ud[1]!=null)
                {
                    Session["UserId"] = account.UserId;
                    Session["UserName"] = ud[0];
                    Session["UserType"] = ud[1];
                  
                    if (ud[1].ToString() == "Hostel Manager")
                    {

                        Response.Redirect("Manager.aspx");

                    }
                    else
                    {
                        Response.Redirect("Receptionist.aspx");
                    }
                }
                else
                {
                    msgLabel.Text = "Username or Password is Incorrect! Pls Try Again!";
               
                }
            
        }
    }
}
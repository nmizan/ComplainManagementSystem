using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplainRegistrationSystem
{
    public partial class Receptionist1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Session["msg"] = "Sorry!Unauthentication............";

                Response.Redirect("LoginPage.aspx");

            }
          
        }

        protected void complainButton_Click(object sender, EventArgs e)
        {

        }
    }
}
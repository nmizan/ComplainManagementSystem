using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComplainRegistrationSystem
{
    public partial class Manager1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Session["msg"] = "Sorry!! UnAuthentication Access....";
                Response.Redirect("LoginPage.aspx");

            }
        }
    }
}
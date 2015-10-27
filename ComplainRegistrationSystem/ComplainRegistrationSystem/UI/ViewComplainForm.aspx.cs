using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ComplainRegistrationSystem.BAL;
using ComplainRegistrationSystem.Model;
using  System.Data;

namespace ComplainRegistrationSystem
{
    public partial class ViewComplainForm : System.Web.UI.Page
    {
        private LoginAfterManager aManagerBal = new LoginAfterManager();
        private ComplainManager aManager = new ComplainManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Session["msg"] = "Sorry!! UnAuthentication Access....";
                Response.Redirect("LoginPage.aspx");

            }
            if (!IsPostBack)
            {
                //Welcome_Label5.Text = "Welcome Mr." + Session["UserName"].ToString();
                List<Complain> da = aManager.ShowAllComplain();
                viewGridView.DataSource = da;
                viewGridView.DataBind();
            }
        }

       

        protected void viewGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            viewGridView.PageIndex = e.NewPageIndex;
            viewGridView.DataSource = aManager.ShowAllComplain();
            viewGridView.DataBind();
        }

        protected void showIdButton_Click(object sender, EventArgs e)
        {
              string dropdata = DropDownList1.SelectedItem.ToString();
                string tdata = Search_TextBox1.Text;
                List<Complain> allList = aManager.GetComplainByall(dropdata,tdata);
                viewGridView.DataSource = allList;
                viewGridView.DataBind();
                msgLabel10.Text = dropdata + " : " + tdata+ "  IS Showing Below";
          
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search_TextBox1.Visible = true;
        }

        protected void viewGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int r = e.NewSelectedIndex;
            Label id = (Label)viewGridView.Rows[r].FindControl("Label8");
            remTextBox1.Text = aManagerBal.GetRemarks(id.Text);
            remarksMsgLabel.Visible = true;
            remTextBox1.Visible = true;
        }
    }
}
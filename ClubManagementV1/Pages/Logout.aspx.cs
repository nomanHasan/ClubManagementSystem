using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void yesButton_Click(object sender, EventArgs e)
        {
            SessionHelper.Logout(Session, this);
        }

        protected void noButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/StudentPages/Home.aspx");
        }
    }
}
using ClubManagementV1.Models;
using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.PresidentPages
{
    public partial class Home : System.Web.UI.Page
    {

        int Sid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "president", this);

            
        }

        public void Authenticate(string role)
        {
            if (Session["LOGIN"] != null)
            {
                string auth = Session["LOGIN"].ToString();
                if (auth != role)
                {
                    if (auth == "admin")
                    {
                        Response.Redirect("~/Pages/AdminPages/Home.aspx");
                    }
                    else if (auth == "president")
                    {
                        Response.Redirect("~/Pages/PresidentPages/Home.aspx");
                    }
                    else if (auth == "student")
                    {
                        Response.Redirect("~/Pages/StudentPages/Home.aspx");
                    }
                }
            }
            else {
                Response.Redirect("~/Pages/Login.aspx");
            }
        }

    }
}
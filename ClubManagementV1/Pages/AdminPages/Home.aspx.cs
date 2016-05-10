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

namespace ClubManagementV1.Pages.AdminPages
{
    public partial class Home : System.Web.UI.Page
    {
        int Aid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            SessionHelper.Authenticate(Session, "admin", this);

            if (Session["Admin"] != null) {
                Models.Admin thisAdmin = (Models.Admin)Session["ADMIN"];

                int thisAdminID = thisAdmin.AdminID;
                Aid = thisAdminID;

                DataSet clDs = Repository.GetDataSet("select * from club", "club");
                DataSet stDs = Repository.GetDataSet("select * from Student", "student");
                DataSet evDs = Repository.GetDataSet("select * from Event", "event");
                DataSet psDs = Repository.GetDataSet("select student.studentID, student.StudentName, club.clubname from student, club, president where student.studentID =president.studentid and president.clubid = club.clubid ", "clubpresident");

                GridView1.DataSource = clDs;
                GridView1.DataBind();

                GridView2.DataSource = stDs;
                GridView2.DataBind();

                GridView3.DataSource = evDs;
                GridView3.DataBind();

                GridView4.DataSource = psDs;
                GridView4.DataBind();

            }



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
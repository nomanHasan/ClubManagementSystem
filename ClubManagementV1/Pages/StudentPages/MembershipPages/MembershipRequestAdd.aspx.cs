using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.StudentPages.MembershipPages
{
    public partial class MembershipRequestAdd : System.Web.UI.Page
    {
        int Sid;
        int clubID;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "student", this);

            if (Session["STUDENT"] != null)
            {
                Models.Student thisStudent = (Models.Student)Session["STUDENT"];

                int studentID = thisStudent.StudentID;
                Sid = studentID;
            }

            
        }

        protected void yesButton_Click(object sender, EventArgs e)
        {
            int status;
            if (int.TryParse(Request.QueryString["ClubID"], out clubID))
            {
                status = Repository.requestMembership(clubID, Sid);
            }
            Response.Redirect("~/Pages/StudentPages/ClubPages/ClubList.aspx");

        }

        protected void noButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/StudentPages/ClubPages/ClubList.aspx");
        }
    }
}
using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.StudentPages.ParticipationPages
{
    public partial class ParticipationRequestDelete : System.Web.UI.Page
    {
        int Sid;
        int eventID;
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
            if (int.TryParse(Request.QueryString["eventID"], out eventID))
            {
                status = Repository.deleteRequestParticipation(eventID, Sid);
            }
            Response.Redirect("~/Pages/StudentPages/EventPages/EventList.aspx");
        }

        protected void noButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/StudentPages/EventPages/EventList.aspx");
        }
    }
}
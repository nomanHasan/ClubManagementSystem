using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.PresidentPages.MembershipPages
{
    public partial class MembershipRequestAccept : System.Web.UI.Page
    {
        int Sid;
        int Cid;

        int studentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "president", this);


            if (Session["PRESIDENT"] != null)
            {
                Models.President thisPresident = (Models.President)Session["PRESIDENT"];

                Sid = thisPresident.Student.StudentID;
                Cid = thisPresident.Club.ClubID;

            }
        }

        protected void yesButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Request.QueryString["studentID"], out studentID)) {
                int status = Repository.acceptRequest(Cid, studentID);
            }

            Response.Redirect("../../StudentPages/MembershipPages/MembershipRequestList.aspx");
        }

        protected void noButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../StudentPages/MembershipPages/MembershipRequestList.aspx");
        }
    }
}
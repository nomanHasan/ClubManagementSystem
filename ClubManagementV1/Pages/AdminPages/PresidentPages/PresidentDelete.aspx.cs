using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.AdminPages.PresidentPages
{
    public partial class PresidentDelete : System.Web.UI.Page
    {

        int clubID;
        int studentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "admin", this);

            if (!int.TryParse(Request.QueryString["clubID"], out clubID) || !int.TryParse(Request.QueryString["studentID"], out studentID))
            {
                Response.Redirect("../ClubPages/ClubList.aspx");
            }
        }

        protected void yesButton_Click(object sender, EventArgs e)
        {
            int status = Repository.removePresident(studentID, clubID);

            Response.Redirect(string.Format("../ClubPages/ClubEdit.aspx?clubID={0}", clubID));
        }

        protected void noButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("../ClubPages/ClubEdit.aspx?clubID={0}", clubID));
        }
    }
}
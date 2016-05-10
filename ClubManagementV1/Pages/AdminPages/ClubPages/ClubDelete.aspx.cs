using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.AdminPages.ClubPages
{
    public partial class ClubDelete : System.Web.UI.Page
    {

        int clubID;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "admin", this);


            if (int.TryParse(Request.QueryString["ClubID"], out clubID))
            {
                DataSet clDs = Repository.GetDataSet(string.Format("select * from club where clubID = {0}", clubID), "club");

                DataTable clTb = clDs.Tables["club"];

                DataRow row = clTb.Rows[0];

                dataClubName.InnerText = row["ClubName"].ToString();
                dataClubDetails.InnerText = row["ClubDetails"].ToString();
                dataDate.InnerText = row["ClubCreated"].ToString();
            }
            else
            {
                Response.Redirect("~/admin/home");
            }
        }

        protected void yesButton_Click(object sender, EventArgs e)
        {
            int status = Repository.deleteClub(clubID);
            Response.Redirect("~/Pages/AdminPages/ClubPages/ClubList.aspx");
        }

        protected void noButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AdminPages/ClubPages/ClubList.aspx");
        }
    }
}
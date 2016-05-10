using ClubManagementV1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.AdminPages.ClubPages
{
    public partial class ClubAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddClub_Click(object sender, EventArgs e)
        {
            if (txtClubDetails.Value != null && txtClubName.Value != null)
            {
                DateTime thisTime = DateTime.Now;

                int status = Repository.insertClub(txtClubName.Value, txtClubDetails.Value, thisTime);
                //int status = Repository.InsertDataSet(string.Format("insert into club (ClubName, ClubDetails, ClubCreated) values({0},{1},{2})", txtClubName.Value, txtClubDetails.Value, thisTime.ToString()));

                if (status <= 0)
                {
                    message.InnerText = "The Club Could not be created";
                }
                else
                {
                    Response.Redirect("~/Pages/AdminPages/ClubPages/ClubList.aspx");
                }
            }
        }
    }
}
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
    public partial class ClubDetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SessionHelper.Authenticate(Session, "admin",this);

            int clubID;

            if(int.TryParse(Request.QueryString["ClubID"], out clubID)) {
                DataSet clDs = Repository.GetDataSet(string.Format("select * from club where clubID = {0}", clubID),"club");

                DataTable clTb = clDs.Tables["club"];

                DataRow row = clTb.Rows[0];

                dataClubName.InnerText = row["ClubName"].ToString();
                dataClubDetails.InnerText = row["ClubDetails"].ToString();
                dataDate.InnerText = row["ClubCreated"].ToString();

                DataSet prDs = Repository.GetDataSet(string.Format("select student.studentname from student where studentid in (select studentID from president where clubID = {0})", clubID),"president");
                DataSet evDs = Repository.GetDataSet(string.Format("select * from event where clubID = {0}", clubID), "events");

                if (prDs.Tables["president"].Rows.Count > 0) {
                    foreach (DataRow r in prDs.Tables["president"].Rows)
                    {
                        presidents.InnerHtml +="<tr><td>" + r["studentName"].ToString() + "</td></tr> ";
                    }
                }

                
                if (evDs.Tables["events"].Rows.Count > 0) {
                    foreach (DataRow r in evDs.Tables["events"].Rows)
                    {
                        events.InnerHtml += "<tr>";
                        events.InnerHtml += "<td>"+r["EventName"].ToString() + "</td> ";
                        events.InnerHtml += "<td>" + r["EventTime"].ToString() + "</td>";
                        events.InnerHtml += "<td>" + r["EventVenue"].ToString() + "</td>";
                        events.InnerHtml += "</tr>";
                    }
                }

                deleteLink.HRef = "ClubDelete.aspx?ClubID=" + clubID;
                editClub.HRef = "ClubEdit.aspx?ClubID=" + clubID;


            }
            else
            {
                Response.Redirect("~/admin/home");
            }
        }
    }
}
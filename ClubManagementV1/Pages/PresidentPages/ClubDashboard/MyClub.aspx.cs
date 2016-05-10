using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.PresidentPages.ClubDashboard
{
    public partial class MyClub : System.Web.UI.Page
    {
        int Sid;
        int Cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "president", this);
            

            if (Session["PRESIDENT"] != null)
            {
                Models.President thisPresident = (Models.President)Session["PRESIDENT"];

                Sid = thisPresident.Student.StudentID;
                Cid = thisPresident.Club.ClubID;

            }

            if (Sid>0)
            {
                DataSet clDs = Repository.GetDataSet(string.Format("select * from club where clubID in (select clubID from president where studentID = {0})", Sid), "club");

                DataTable clTb = clDs.Tables["club"];

                DataRow row = clTb.Rows[0];

                dataClubName.InnerText = row["ClubName"].ToString();
                dataClubDetails.InnerText = row["ClubDetails"].ToString();
                dataDate.InnerText = row["ClubCreated"].ToString();

                DataSet prDs = Repository.GetDataSet(string.Format("select student.studentname from student where studentid in (select studentID from president where clubID = {0})", Cid), "president");
                DataSet evDs = Repository.GetDataSet(string.Format("select * from event where clubID = {0}", Cid), "events");

                if (prDs.Tables["president"].Rows.Count > 0)
                {
                    foreach (DataRow r in prDs.Tables["president"].Rows)
                    {
                        presidents.InnerHtml += "<tr><td>" + r["studentName"].ToString() + "</td></tr> ";
                    }
                }


                if (evDs.Tables["events"].Rows.Count > 0)
                {
                    foreach (DataRow r in evDs.Tables["events"].Rows)
                    {
                        events.InnerHtml += "<tr>";
                        events.InnerHtml += "<td>" + r["EventName"].ToString() + "</td> ";
                        events.InnerHtml += "<td>" + r["EventTime"].ToString() + "</td>";
                        events.InnerHtml += "<td>" + r["EventVenue"].ToString() + "</td>";
                        events.InnerHtml += "</tr>";
                    }
                }

                manageMemRequest.HRef = "../MembershipPages/MembershipRequestList.aspx";
                managePartRequest.HRef = "../ParticipationPages/ParticipationList.aspx";


            }
            else
            {
                Response.Redirect("~/PresidentPages/Home.aspx");
            }
        }


        public IEnumerable<Models.Student> GetStudents()
        {
            DataSet stDs = Repository.GetDataSet(string.Format("select * from student where studentID in (select studentID from clubMembership where clubID={0})", Cid), "memreq");

            foreach (DataRow row in stDs.Tables["memreq"].Rows)
            {
                yield return new Models.Student
                {
                    StudentID = Convert.ToInt32(row["studentID"]),
                    StudentName = row["studentName"].ToString(),
                    StudentEmail = row["Email"].ToString(),
                    StudentPhone = row["Phone"].ToString()
                    
                };
            }
        }
    }
}
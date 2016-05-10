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

namespace ClubManagementV1.Pages.StudentPages.EventPages
{
    public partial class EventList : System.Web.UI.Page
    {
        int Sid;
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

        public IEnumerable<Event> GetEvents()
        {
            DataSet evDs = Repository.GetDataSet(string.Format("select * from event where clubID in (select clubID from clubMembership where studentID = {0})",Sid), "Event");


            foreach (DataRow row in evDs.Tables["Event"].Rows)
            {
                int clubID = Convert.ToInt32(row["ClubID"]);

                string clubName = Repository.ExecuteScalar(string.Format("select clubName from club where clubID={0}", clubID)).ToString();

                    yield return new Models.Event
                    {
                        EventID = Convert.ToInt32(row["EventID"]),
                        EventName = row["EventName"].ToString(),
                        EventTime = Convert.ToDateTime(row["EventTime"]),
                        EventVenue = row["EventVenue"].ToString(),
                        EventClub = new Models.Club { ClubName = clubName }
                    };
            }
        }
    }
}
using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.StudentPages.ParticipationPages
{
    public partial class ParticipationRequestList : System.Web.UI.Page
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

        public IEnumerable<Models.ParticipationRequest> GetPartRequests()
        {
            DataSet cmDs = Repository.GetDataSet(string.Format("select * from ParticipationQueue where studentID = {0}", Sid), "participation");

            foreach (DataRow row in cmDs.Tables["participation"].Rows)
            {
                int eventID = Convert.ToInt32(row["eventID"]);
                string eventName = Repository.ExecuteScalar(string.Format("select eventName from event where eventID={0}", eventID)).ToString();


                yield return new Models.ParticipationRequest
                {
                    Event = new Models.Event { EventID = eventID, EventName = eventName }
                };
            }

        }
    }
}
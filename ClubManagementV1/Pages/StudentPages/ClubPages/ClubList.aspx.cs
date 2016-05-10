using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.StudentPages.ClubPages
{
    public partial class ClubList : System.Web.UI.Page
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

        public IEnumerable<Models.Club> GetClubs()
        {
            DataSet clDs = Repository.GetDataSet(string.Format("select * from club where clubID not in (select ClubID from clubMembership where studentID = {0})",Sid), "club");

            foreach (DataRow row in clDs.Tables["club"].Rows)
            {
                yield return new Models.Club
                {
                    ClubID = Convert.ToInt32(row["ClubID"]),
                    ClubName = row["ClubName"].ToString(),
                    ClubCreated = Convert.ToDateTime(row["ClubCreated"]),
                    ClubDetails = row["ClubDetails"].ToString()
                };
            }
        }

    }
}
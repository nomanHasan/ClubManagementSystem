using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.PresidentPages.MembershipPages
{
    public partial class MembershipRequestList : System.Web.UI.Page
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
        }

        public IEnumerable<Models.MembershipRequest> GetMemReqs()
        {
            DataSet clDs = Repository.GetDataSet(string.Format("select * from membershipqueue where clubID = {0}", Cid), "memreq");

            foreach (DataRow row in clDs.Tables["memreq"].Rows)
            {
                string clubName = Repository.ExecuteScalar(string.Format("select clubName from club where clubID={0}", Cid)).ToString();

                int studentID = Convert.ToInt32(row["studentID"]);

                string studentName = Repository.ExecuteScalar(string.Format("select studentName from student where studentID={0}", studentID)).ToString();

                yield return new Models.MembershipRequest
                {
                    Club = new Models.Club { ClubID = Cid, ClubName = clubName },
                    Student = new Models.Student { StudentID=studentID, StudentName = studentName}
                };
            }
        }
    }
}
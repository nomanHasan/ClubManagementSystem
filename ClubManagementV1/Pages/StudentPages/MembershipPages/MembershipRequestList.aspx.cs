using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.StudentPages.MembershipPages
{
    public partial class MembershipRequestList : System.Web.UI.Page
    {
        public int Sid;
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


        public IEnumerable<Models.MembershipRequest> GetMemRequests()
        {
            DataSet cmDs = Repository.GetDataSet(string.Format("select * from MembershipQueue where studentID = {0}", Sid), "membership");

            foreach (DataRow row in cmDs.Tables["membership"].Rows)
            {
                int clubID = Convert.ToInt32(row["clubID"]);
                string clubName = Repository.ExecuteScalar(string.Format("select clubName from club where clubID={0}", clubID)).ToString();


                yield return new Models.MembershipRequest
                {
                    Club = new Models.Club { ClubID = clubID, ClubName = clubName }
                };
            }

        }
    }
}
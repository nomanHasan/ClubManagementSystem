using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.AdminPages.PresidentPages
{
    public partial class PresidentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "admin", this);
        }

        public IEnumerable<Models.President> GetPresidents()
        {
            DataSet evDs = Repository.GetDataSet("select * from president", "president");

           

            foreach (DataRow row in evDs.Tables["president"].Rows)
            {

                int clubID = Convert.ToInt32(row["ClubID"]);

                string clubName = Repository.ExecuteScalar(string.Format("select clubName from club where clubID={0}", clubID)).ToString();
                
                int studentID = Convert.ToInt32(row["StudentID"]);

                string studentName = Repository.ExecuteScalar(string.Format("select studentName from student where studentID = {0}", studentID)).ToString();

                string studentRole = Repository.ExecuteScalar(string.Format("select role from Account where username in (select username from student where studentID = {0})", studentID)).ToString();

                string studentUsername = Repository.ExecuteScalar(string.Format("select username from student where studentID = {0}", studentID)).ToString();
                
                yield return new Models.President
                {
                    Club = new Models.Club { ClubID = clubID, ClubName=clubName },
                    Student = new Models.Student { StudentName = studentName, StudentID = studentID },
                    Account = new Models.Account {  Role = studentRole, Username = studentUsername }
                };

            }
        }
    }
}
using ClubManagementV1.Models.Repository;
using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubManagementV1.Models;

namespace ClubManagementV1.Pages.AdminPages.ClubPages
{
    public partial class ClubEdit : System.Web.UI.Page
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

                if (!IsPostBack) {

                    txtClubName.Value = row["ClubName"].ToString();
                    txtClubDetails.Value = row["ClubDetails"].ToString();
                    dateClubCreated.Value = row["ClubCreated"].ToString();
                }

                DataSet prDs = Repository.GetDataSet(string.Format("select student.studentname, student.studentID from student where studentid in (select studentID from president where clubID = {0})", clubID), "president");
                DataSet evDs = Repository.GetDataSet(string.Format("select * from event where clubID = {0}", clubID), "events");
            }
            else
            {
                Response.Redirect("~/admin/home");
            }
        }

        public IEnumerable<Student> GetPresidents() {
            DataSet prDs = Repository.GetDataSet(string.Format("select student.studentname, student.studentID from student where studentid in (select studentID from president where clubID = {0})", clubID), "president");

            foreach (DataRow row in prDs.Tables["president"].Rows)
            {
                yield return new Models.Student
                {
                    StudentID = Convert.ToInt32(row["StudentID"]),
                    StudentName = row["studentName"].ToString()
                };
            }
        }

        public IEnumerable<Student> GetStudents()
        {
            DataSet prDs = Repository.GetDataSet(string.Format("select * from student where studentID in (select studentID from clubmembership where clubID = {0})", clubID), "student");

            foreach (DataRow row in prDs.Tables["student"].Rows)
            {
                yield return new Models.Student
                {
                    StudentID = Convert.ToInt32(row["StudentID"]),
                    StudentName = row["StudentName"].ToString(),
                    StudentEmail = row["Email"].ToString(),
                    StudentPhone = row["Phone"].ToString()
                };
            }
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            string clubName = txtClubName.Value;
            string clubDetails = txtClubDetails.Value;
            string clubCreated = dateClubCreated.Value;

            int status = Repository.updateClub(clubID, clubName, clubDetails, clubCreated);

            if (status <= 0)
                Response.Redirect("~/Pages/AdminPages/Home.aspx");
            else
                Response.Redirect("~/Pages/AdminPages/ClubPages/ClubList.aspx");
        }
    }
}
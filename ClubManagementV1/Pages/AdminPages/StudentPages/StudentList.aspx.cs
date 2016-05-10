using ClubManagementV1.Models;
using ClubManagementV1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages.AdminPages.StudentPages
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Student> GetStudents()
        {
            DataSet evDs = Repository.GetDataSet("select * from Student", "Student");


            foreach (DataRow row in evDs.Tables["Student"].Rows)
            {
                int StudentID = Convert.ToInt32(row["StudentID"]);

                string userName = Repository.ExecuteScalar(string.Format("select username from Account where username in (select username from Student where studentID = {0})", StudentID)).ToString();
                
                yield return new Models.Student
                {
                    StudentID = Convert.ToInt32(row["StudentID"]),
                    StudentName = row["StudentName"].ToString(),
                    StudentEmail = row["Email"].ToString(),
                    StudentPhone = row["Phone"].ToString(),
                    Account = new Models.Account { Username = userName }
                };

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubManagementV1.Models.Repository;
using System.Data;
using ClubManagementV1.Models;

namespace ClubManagementV1.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
                DataSet loginDataSet;

                string username = txtUserName.Value;
                string password = txtPassword.Value;

                if (username == null) return;

                string sql = string.Format("Select * from Account where username='{0}' and password='{1}'", username, password);


                loginDataSet = Repository.GetDataSet(sql, "Account");

                if (loginDataSet.Tables["Account"].Rows.Count > 0)
                {

                    string role = loginDataSet.Tables["Account"].Rows[0]["Role"].ToString();

                    Session["LOGIN"] = role;

                    if (role == "student")
                    {
                        string s = string.Format("Select * from Student where username='{0}'", username);
                        DataSet ds = Repository.GetDataSet(s, "Student");

                        Student student = new Student();

                        student.StudentName = ds.Tables["Student"].Rows[0]["StudentName"].ToString();
                        student.StudentID = int.Parse(ds.Tables["Student"].Rows[0]["StudentID"].ToString());
                        student.StudentEmail = ds.Tables["Student"].Rows[0]["Email"].ToString();
                        student.StudentPhone = ds.Tables["Student"].Rows[0]["Phone"].ToString();

                        Session["STUDENT"] = student;
                    }
                    else if (role == "president")
                    {
                        string s = string.Format("Select * from Student where username='{0}'", username);
                        DataSet ds = Repository.GetDataSet(s, "Student");

                        Student student = new Student();

                        student.StudentName = ds.Tables["Student"].Rows[0]["StudentName"].ToString();
                        student.StudentID = int.Parse(ds.Tables["Student"].Rows[0]["StudentID"].ToString());
                        student.StudentEmail = ds.Tables["Student"].Rows[0]["Email"].ToString();
                        student.StudentPhone = ds.Tables["Student"].Rows[0]["Phone"].ToString();

                        string clubName = Repository.ExecuteScalar(string.Format("select clubName from club where clubID in (select clubID from President where studentID = {0})", student.StudentID)).ToString();

                        int clubID = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select clubID from president where studentID = {0}", student.StudentID)));

                        Models.Club club = new Models.Club();
                        club.ClubID = clubID;
                        club.ClubName = clubName;

                        Models.President president = new Models.President();
                        president.Club = club;
                        president.Student = student;

                        Session["PRESIDENT"] = president;

                    }
                    else if (role == "admin")
                    {
                        string s = string.Format("Select * from Admin where username='{0}'", username);
                        DataSet ds = Repository.GetDataSet(s, "Admin");

                        Admin admin = new Admin();

                        admin.AdminName = ds.Tables["Admin"].Rows[0]["AdminName"].ToString();
                        admin.AdminID = int.Parse(ds.Tables["Admin"].Rows[0]["AdminID"].ToString());


                        Session["ADMIN"] = admin;
                    }

                    if (role == "admin")
                    {
                        Response.Redirect("~/Pages/AdminPages/Home.aspx");
                    }
                    else if (role == "president")
                    {
                        Response.Redirect("~/Pages/PresidentPages/Home.aspx");
                    }
                    else if (role == "student")
                    {
                        Response.Redirect("~/Pages/StudentPages/Home.aspx");
                    }

                }
                else {
                    Response.Redirect("~/Pages/Home.aspx");
                }
            
        }
    }
}
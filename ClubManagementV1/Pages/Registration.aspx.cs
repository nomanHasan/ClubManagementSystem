using ClubManagementV1.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClubManagementV1.Pages
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string studentName = txtStudentName.Value;
            string studentEmail = txtEmail.Value;
            string studentPhone = txtPhone.Value;
            string studentUsername = txtUsername.Text;
            string studentPassword = txtPassword.Value;


            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(username) from Account  where username = '{0}'", studentUsername)));

            if (availability > 0) {
                check.Text = "Check Availability : Not Available";
                check.CssClass = "btn btn-danger";
                return;
            }
            else {
                check.Text = "Check Availability : Available";
                check.CssClass = "btn btn-success";
            }

            int status = Convert.ToInt32(Repository.registerStudent(studentName, studentEmail, studentPhone,studentUsername, studentPassword));

            if (status == 1) {
                Response.Redirect("Home.aspx");
            }




        }


        protected void check_Click(object sender, EventArgs e)
        {
            string studentUsername = txtUsername.Text;
            int availability = Convert.ToInt32(Repository.ExecuteScalar(string.Format("select count(username) from Account where username = '{0}'", studentUsername)));

            if (availability > 0)
            {
                check.Text = "Check Availability : Not Available";
                check.CssClass = "btn btn-danger";
            }
            else {
                check.Text = "Check Availability : Available";
                check.CssClass = "btn btn-success";
            }
        }
    }
}
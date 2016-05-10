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

namespace ClubManagementV1.Pages.StudentPages
{
    public partial class Home : System.Web.UI.Page
    {

        int Sid = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "student", this);

            if (Session["STUDENT"] != null)
            {
                Student thisStudent = (Student)Session["STUDENT"];

                int studentID = thisStudent.StudentID;
                Sid = studentID;


                //DataSet clDs = Repository.GetDataSet(string.Format("select * from ClubMembership where studentID = '{0}'", studentID), "ClubMembership");
                //DataSet evDs = Repository.GetDataSet(string.Format("select * from EventParticipation where studentID = '{0}'", studentID), "EventParticipation");

                DataSet clDs = Repository.GetDataSet(string.Format("select * from club where clubID in (select clubID from ClubMembership where studentID = '{0}')", studentID), "ClubMembership");
                DataSet evDs = Repository.GetDataSet(string.Format("select * from event where eventID in (select eventID from EventParticipation where studentID = '{0}')", studentID), "EventParticipation");
                DataSet stDs = Repository.GetDataSet(string.Format("select * from Student where studentID = '{0}'", studentID), "student");




                GridView1.DataSource = clDs;
                GridView1.DataBind();

                GridView2.DataSource = evDs;
                GridView2.DataBind();

                GridView3.DataSource = stDs;
                GridView3.DataBind();

                stDs.Tables["student"].PrimaryKey = new DataColumn[] { stDs.Tables["student"].Columns["studentID"] };
                Cache.Insert("DATASET", stDs, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);

            }
            if (!IsPostBack)
                this.LoadGridViewData();


        }

        public void Authenticate(string role)
        {
            if (Session["LOGIN"] != null)
            {
                string auth = Session["LOGIN"].ToString();
                if (auth != role)
                {
                    if (auth == "admin")
                    {
                        Response.Redirect("~/Pages/AdminPages/Home.aspx");
                    }
                    else if (auth == "president")
                    {
                        Response.Redirect("~/Pages/PresidentPages/Home.aspx");
                    }
                    else if (auth == "student")
                    {
                        Response.Redirect("~/Pages/StudentPages/Home.aspx");
                    }
                }
            }
            else {
                Response.Redirect("~/Pages/Login.aspx");
            }
        }

        private void LoadFromDatabase()
        {
            DataSet stDs = Repository.GetDataSet(string.Format("select * from Student where studentID = '{0}'", Sid), "student");

            stDs.Tables["student"].PrimaryKey = new DataColumn[] { stDs.Tables["student"].Columns["studentID"] };

            Cache.Insert("DATASET", stDs, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);

        }

        private void LoadGridViewData()
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadFromDatabase();
            }

            DataSet ds = (DataSet)Cache["DATASET"];
            GridView3.DataSource = ds.Tables["student"];
            GridView3.DataBind();
        }

        protected void GridView3_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView3.EditIndex = e.NewEditIndex;
            this.LoadGridViewData();

        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadFromDatabase();
            }

            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["studentID"]);

            dr.Delete();

            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            this.LoadGridViewData();
        }

        protected void GridView3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView3.EditIndex = -1;
            this.LoadGridViewData();
        }

        protected void GridView3_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] == null)
            {
                this.LoadFromDatabase();
            }

            DataSet ds = (DataSet)Cache["DATASET"];
            DataRow dr = ds.Tables["student"].Rows.Find(e.Keys["studentID"]);

            spro.InnerText = e.NewValues["Phone"].ToString();

            dr["StudentName"] = e.NewValues["StudentName"];
            dr["Email"] = e.NewValues["Email"];
            dr["Phone"] = e.NewValues["Phone"];

            GridView3.DataSource = ds;
            GridView3.DataBind();

            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            GridView3.EditIndex = -1;
            this.LoadGridViewData();

        }
    }
}
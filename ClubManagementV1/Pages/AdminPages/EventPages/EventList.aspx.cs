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

namespace ClubManagementV1.Pages.AdminPages.EventPages
{
    public partial class EventList : System.Web.UI.Page
    {
        DateTime thisTime = DateTime.Now;
        DateTime threshold;
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "admin", this);

            iThreshold.InnerText = threshold.ToString();

            if (!IsPostBack) {
                threshold = DateTime.Now.AddYears(-5);
            }
        }

        public IEnumerable<Event> GetEvents() {
            DataSet evDs = Repository.GetDataSet("select * from event", "Event");
            

            foreach (DataRow row in evDs.Tables["Event"].Rows)
            {
                int clubID = Convert.ToInt32(row["ClubID"]);

                string clubName = Repository.ExecuteScalar(string.Format("select clubName from club where clubID={0}", clubID)).ToString();

                DateTime evTime = Convert.ToDateTime(row["EventTime"]);
                if (evTime >= threshold) {
                    yield return new Models.Event
                    {
                        EventID = Convert.ToInt32(row["EventID"]),
                        EventName = row["EventName"].ToString(),
                        EventTime = Convert.ToDateTime(row["EventTime"]),
                        EventVenue = row["EventVenue"].ToString(),
                        EventClub = new Models.Club { ClubName = clubName }
                    };
                }
                
            }
        }

        protected void lastMonth_Click(object sender, EventArgs e)
        {
            threshold = DateTime.Now.AddMonths(-1);
            eventRep.DataBind();
        }

        protected void last3Month_Click(object sender, EventArgs e)
        {
            threshold = DateTime.Now.AddMonths(-3);
            eventRep.DataBind();
        }

        protected void last6Month_Click(object sender, EventArgs e)
        {
            threshold = DateTime.Now.AddMonths(-6);
            eventRep.DataBind();
        }

        protected void lastYear_Click(object sender, EventArgs e)
        {
            threshold = DateTime.Now.AddYears(-1);
            eventRep.DataBind();
        }


        protected void last2Year_Click(object sender, EventArgs e)
        {
            threshold = DateTime.Now.AddYears(-2);
            eventRep.DataBind();
        }

        protected void last5Year_Click(object sender, EventArgs e)
        {
            threshold = DateTime.Now.AddYears(-5);
            eventRep.DataBind();
        }

        protected void lastLongAgo_Click(object sender, EventArgs e)
        {
            threshold = DateTime.Now.AddYears(-10);
            eventRep.DataBind();
        }
    }
}
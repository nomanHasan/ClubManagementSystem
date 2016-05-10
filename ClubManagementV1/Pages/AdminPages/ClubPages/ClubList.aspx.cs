using ClubManagementV1.Pages.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClubManagementV1.Models;
using ClubManagementV1.Models.Repository;
using System.Data;

namespace ClubManagementV1.Pages.AdminPages.ClubPages
{
    public partial class ClubList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionHelper.Authenticate(Session, "admin", this);


        }

        public IEnumerable<Models.Club> GetClubs() {
            DataSet clDs = Repository.GetDataSet("select * from club", "club");

            foreach (DataRow row in clDs.Tables["club"].Rows) {
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace ClubManagementV1.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.MapPageRoute("admin_home", "admin/home", "~/Pages/AdminPages/Home.aspx");
            routes.MapPageRoute("admin", "admin", "~/Pages/AdminPages/Home.aspx");

            routes.MapPageRoute("president_home", "president/home", "~/Pages/PresidentPages/Home.aspx");
            routes.MapPageRoute("president", "president", "~/Pages/PresidentPages/Home.aspx");

            routes.MapPageRoute("student_home", "student/home", "~/Pages/StudentPages/Home.aspx");
            routes.MapPageRoute("student", "student", "~/Pages/StudentPages/Home.aspx");

            routes.MapPageRoute(null, "", "~/Pages/Home.aspx");
        }
    }
}
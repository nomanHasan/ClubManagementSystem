using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ClubManagementV1.Pages.Helpers
{
    public class SessionHelper
    {
        public static void Set(HttpSessionState Session, string key, object value)
        {
            Session[key] = value;
        }

        public static void Authenticate(HttpSessionState session, string role, System.Web.UI.Page webpage)
        {
            if (session["LOGIN"] != null)
            {
                string auth = session["LOGIN"].ToString();
                if (auth != role)
                {
                    if (auth == "admin")
                    {
                        webpage.Response.Redirect("~/Pages/AdminPages/Home.aspx");
                    }
                    else if (auth == "president")
                    {
                        webpage.Response.Redirect("~/Pages/PresidentPages/Home.aspx");
                    }
                    else if (auth == "student")
                    {
                        webpage.Response.Redirect("~/Pages/StudentPages/Home.aspx");
                    }
                }
            }
            else {
                webpage.Response.Redirect("~/Pages/Login.aspx");
            }
        }


        public static T GetFromSession<T>(HttpSessionState session, string key)
        {
            object dataValue = session[key];

            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else {
                return default(T);
            }
        }

        public static void Logout(HttpSessionState session, System.Web.UI.Page page) {
            if (session["LOGIN"] != null) {
                session["LOGIN"] = null;
            }else if (session["ADMIN"] != null)
            {
                session["ADMIN"] = null;
            }
            else if (session["PRESIDENT"] != null)
            {
                session["PRESIDENT"] = null;
            }
            else if (session["STUDENT"] != null)
            {
                session["STUDENT"] = null;
            }

            page.Response.Redirect("~/Pages/Login.aspx");
        }
    }
}
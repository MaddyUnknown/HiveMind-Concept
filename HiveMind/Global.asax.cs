using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Routing;
using System.Web.SessionState;

namespace HiveMind
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            RegisterCustomRoutes(RouteTable.Routes);

            RegisterErrorRoutes(RouteTable.Routes);
        }

        protected void RegisterCustomRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("userAuthenticationPage", "user/authenticate", "~/views/Authenticate.aspx");

            routes.MapPageRoute("userHomePage", "user/home", "~/views/requireAuthentication/HomePage.aspx");

            routes.MapPageRoute("searchPage", "search", "~/views/SearchResult.aspx");

            //routes.MapPageRoute("userRegistrationSuccessful", "registrationSuccessful", "~/views/RegistrationSuccessful.aspx");

            routes.MapPageRoute("userLogOutSuccessful", "logOutSuccess", "~/views/LogOutSuccessful.aspx");
        }

        private void RegisterErrorRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("errorDefault", "error/default", "~/views/errorPage/Error.aspx");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
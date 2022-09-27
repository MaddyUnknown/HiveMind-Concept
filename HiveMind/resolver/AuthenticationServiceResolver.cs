using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using HiveMind.AuthenticateUtils;

namespace HiveMind.Resolver
{
    // This class is responsible for resolving the authentication service that the application will use.
    // This class follows singleton pattern.
    public static class AuthenticationServiceResolver
    {
        private static readonly string XmlAuthentication = "xml";

        private static BaseAuthenticationService authService = InitSingletonAuthService();

        public static BaseAuthenticationService Resolve()
        {
            return authService;
        }

        private static BaseAuthenticationService InitSingletonAuthService()
        {
            if (ConfigurationManager.AppSettings["AuthenticationType"].ToLower() == XmlAuthentication)
            {
                return new XmlAuthenticationService(ConfigurationManager.AppSettings["LoginFileLocation"]);
            }
            else
            {
                return new SqlDbAuthenticationService(ConfigurationManager.ConnectionStrings["userlogincon"].ConnectionString);
            }
        }
    }
}
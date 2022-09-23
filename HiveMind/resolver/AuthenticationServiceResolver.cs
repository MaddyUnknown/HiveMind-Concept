using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using HiveMind.AuthenticateUtils;

namespace HiveMind.Resolver
{
    public static class AuthenticationServiceResolver
    {
        private static string XmlAuthentication = "xml";

        public static BaseAuthenticationService Resolve()
        {
            if(ConfigurationManager.AppSettings["AuthenticationType"].ToLower() == XmlAuthentication)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using HiveMind.AuthenticateUtils;
using HiveMind.Resolver;

namespace HiveMind.View
{
    public partial class HomePage : System.Web.UI.Page
    {
        public static BaseAuthenticationService authenticationService = AuthenticationServiceResolver.Resolve();
        protected void Page_Load(object sender, EventArgs e)
        {
            HiveMind.Model.User user = authenticationService.UserDetials(User.Identity.Name);
            UserName.Text = user.Name;
        }
    }
}
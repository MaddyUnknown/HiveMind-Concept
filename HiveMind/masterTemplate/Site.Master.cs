using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace HiveMind.master
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UserLogOut(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //FormsAuthentication.RedirectToLoginPage();
            Response.Redirect("~/LogOutSuccessful.aspx");
        }

        public Button LogOutHeaderButton
        {
            get
            {
                return LogOutHeader;
            }
        }

        public Button LogOutFooterButton
        {
            get
            {
                return LogOutFooter;
            }
        }
    }
}
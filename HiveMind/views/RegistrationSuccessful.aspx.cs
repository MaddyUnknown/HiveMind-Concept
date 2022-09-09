using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiveMind.View
{
    public partial class RegistrationSuccessful : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.LogOutHeaderButton.Enabled = false;
            Master.LogOutHeaderButton.Visible = false;
            Master.LogOutFooterButton.Enabled = false;
            Master.LogOutFooterButton.Visible = false;
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/user/authenticate");
        }
    }
}
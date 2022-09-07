using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HiveMind
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void InternalPageChangeCommand(object sender, CommandEventArgs e)
        {
            int pageNumber = Convert.ToInt16(e.CommandArgument);
            MultiView1.ActiveViewIndex = pageNumber;
        }
    }
}
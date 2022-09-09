using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using HiveMind.AuthenticateUtils;
using HiveMind.Userdefined.Control;
using System.Configuration;

namespace HiveMind.View
{
    public partial class Login : System.Web.UI.Page
    {
        private BaseAuthenticationService authenticationService = new XmlAuthenticationService(ConfigurationManager.AppSettings["LoginFileLocation"]);


        protected void Page_PreInit(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
            }
        }

        private void CreateToast(string imageUrl, string title, string content)
        {
            ToastNotification toast = (ToastNotification)LoadControl(UserControlConstants.ToastNotificationDynamicPath);
            toast.ImageUrl = imageUrl;
            toast.Title = title;
            toast.Content = content;
            ToastHolder.Controls.Add(toast);
        }

        protected void InternalPageChangeCommand(object sender, CommandEventArgs e)
        {
            int pageNumber = Convert.ToInt16(e.CommandArgument);
            MultiView1.ActiveViewIndex = pageNumber;
        }

        protected void LogInEventHandler(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (authenticationService.Authenticate(Email.Text, Password.Text))
                {
                    FormsAuthentication.RedirectFromLoginPage(Email.Text, RememberMe.Checked);
                }
                else
                {
                    CreateToast(ViewConstants.errorImageLoc, ViewConstants.invalidCredentials_header, ViewConstants.enterValidInput_body);
                }

            }
            else
            {
                CreateToast(ViewConstants.errorImageLoc, ViewConstants.invalidInput_header, ViewConstants.invalidInput_body);
            }
        }

        protected void SignUpEventHandler(object sender, EventArgs e)
        {
            if(IsValid)
            {
                if(authenticationService.UserRegistration(RegisterName.Text, RegisterEmail.Text, RegisterPassword.Text))
                {
                    //CreateToast(ViewConstants.successImageLoc, ViewConstants.userRegistration_header, ViewConstants.userRegistationSuccess_body);
                    Server.Transfer("~/views/RegistrationSuccessful.aspx");
                }
                else
                {
                    CreateToast(ViewConstants.errorImageLoc, ViewConstants.userRegistration_header, ViewConstants.emailAlreadyRegistered_body);
                }
            }
            else
            {
                CreateToast(ViewConstants.errorImageLoc, ViewConstants.invalidInput_header, ViewConstants.invalidInput_body);
            }
        }

        protected void GeneratePasswordChangeEmail_Click(object sender, EventArgs e)
        {
            CreateToast(ViewConstants.errorImageLoc, ViewConstants.serverNote_header, ViewConstants.featureNotImplemented);
        }
    }
}
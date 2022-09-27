using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Web.Security;
using HiveMind.AuthenticateUtils;
using HiveMind.Userdefined.Control;
using HiveMind.Resolver;
using HiveMind.ApplicationException;

namespace HiveMind.View
{
    public partial class Login : System.Web.UI.Page
    {
        private static BaseAuthenticationService authenticationService = AuthenticationServiceResolver.Resolve();


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

        private void CreateToast(string imageUrl, string title, string content, Color color)
        {
            ToastNotification toast = (ToastNotification)LoadControl(UserControlConstants.ToastNotificationDynamicPath);
            toast.ImageUrl = imageUrl;
            toast.Title = title;
            toast.Content = content;
            toast.TextColor = color;
            ToastHolder.Controls.Add(toast);
        }

        protected void InternalPageChangeCommand(object sender, CommandEventArgs e)
        {
            int pageNumber = Convert.ToInt16(e.CommandArgument);
            MultiView1.ActiveViewIndex = pageNumber;
        }

        protected void LogInEventHandler(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (authenticationService.Authenticate(Email.Text, Password.Text))
                    {
                        FormsAuthentication.RedirectFromLoginPage(Email.Text, RememberMe.Checked);
                    }
                    else
                    {
                        CreateToast(ViewConstants.errorImageLoc, ViewConstants.invalidCredentials_header, ViewConstants.enterValidInput_body, Color.Red);
                    }

                }
                else
                {
                    CreateToast(ViewConstants.errorImageLoc, ViewConstants.invalidInput_header, ViewConstants.invalidInput_body, Color.Red);
                }
            }
            catch (Exception ex)
            {
                customErrorHandler(ex);
            }

        }

        protected void SignUpEventHandler(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    if (authenticationService.UserRegistration(RegisterName.Text, RegisterEmail.Text, RegisterPassword.Text))
                    {
                        //CreateToast(ViewConstants.successImageLoc, ViewConstants.userRegistration_header, ViewConstants.userRegistationSuccess_body, Color.Green);
                        Server.Transfer("~/views/RegistrationSuccessful.aspx");
                    }
                    else
                    {
                        CreateToast(ViewConstants.errorImageLoc, ViewConstants.userRegistration_header, ViewConstants.emailAlreadyRegistered_body, Color.Red);
                    }
                }
                else
                {
                    CreateToast(ViewConstants.errorImageLoc, ViewConstants.invalidInput_header, ViewConstants.invalidInput_body, Color.Red);
                }
            }
            catch (Exception ex)
            {
                customErrorHandler(ex);
            }

        }

        protected void GeneratePasswordChangeEmail_Click(object sender, EventArgs e)
        {
            //CreateToast(ViewConstants.errorImageLoc, ViewConstants.serverNote_header, ViewConstants.featureNotImplemented, Color.Red);
            try
            {
                authenticationService.CancelToken(ForgotEmail.Text);
            }
            catch(Exception ex) {
                customErrorHandler(ex);
            }
            
        }

        protected void customErrorHandler(Exception ex)
        {
            if(ex is KeyedException)
            {
                CreateToast(ViewConstants.errorImageLoc, ViewConstants.serverError_header, ex.Message, Color.Red);
            }
            else
            {
                CreateToast(ViewConstants.errorImageLoc, ViewConstants.serverError_header, ViewConstants.serverError_body, Color.Red);
            }
        }
    }
}
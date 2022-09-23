using System.Web.Security;
using HiveMind.Model;
using System.Data;

namespace HiveMind.AuthenticateUtils
{
    public abstract class BaseAuthenticationService
    {
        abstract public bool Authenticate(string email, string password);

        abstract public bool UserRegistration(string name, string email, string password);

        abstract public User UserDetials(string email);

        abstract public string CancelToken(string email);

        protected string Encrypt(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA256");
        }
    }
}

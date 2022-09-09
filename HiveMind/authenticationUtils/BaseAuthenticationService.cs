using System.Web.Security;

namespace HiveMind.AuthenticateUtils
{
    public abstract class BaseAuthenticationService
    {
        abstract public bool Authenticate(string email, string password);

        abstract public bool UserRegistration(string name, string email, string password);

        protected string Encrypt(string password)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA256");
        }
    }
}

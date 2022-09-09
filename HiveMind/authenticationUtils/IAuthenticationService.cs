using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveMind.AuthenticateUtils
{
    public interface IAuthenticationService
    {
        bool Authenticate(string email, string password);
    }

    public interface IUserRegistrationService
    {
        bool Registration(string username, string email, string password);
    }
}

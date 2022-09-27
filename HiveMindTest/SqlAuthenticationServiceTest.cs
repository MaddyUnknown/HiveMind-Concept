using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HiveMind.ApplicationException;
using HiveMind.AuthenticateUtils;

namespace HiveMindTest
{
    [TestClass]
    public class SqlAuthenticationServiceTest
    {
        private SqlDbAuthenticationService service = new SqlDbAuthenticationService(@"User ID=HiveMindUser;Password=test1234;Initial Catalog=HiveMind;Data Source=MSI\SQLEXPRESS;");

        [TestMethod]
        [ExpectedException(typeof(KeyedException), "User Authentication Input can't be null or empty")]
        public void Authenticate_InvalidEmptyInput_ThrowsError()
        {
            string email = null;
            string password = "time";

            bool match = service.Authenticate(email, password);
        }

        [TestMethod]
        public void Authenticate_ValidInput_Authenticates()
        {
            string email = "dummy@gmail.com";
            string password = "test1234";

            bool match = service.Authenticate(email, password);

            Assert.IsTrue(match);
        }

        [TestMethod]
        public void Authenticate_InvalidInput_AuthenticationFails()
        {
            string email = "dummy@gmail.com";
            string password = "Test1234";

            bool match = service.Authenticate(email, password);

            Assert.IsFalse(match);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyedException), "User Authentication Input can't be null or empty")]
        public void Registration_InvalidEmptyInput_ThrowsError()
        {
            string email = "dummy1@gmail.com";
            string password = "";
            string name = "test";

            bool registrationSuccess = service.UserRegistration(name, email, password);
        }

        [TestMethod]
        public void Registration_InvalidInput_RegistrationFails()
        {
            string email = "Dummy@gmail.com";
            string password = "tryitout";
            string name = "test";

            bool registrationSuccess = service.UserRegistration(name, email, password);

            Assert.IsFalse(registrationSuccess);
        }



        [TestMethod]
        public void Registration_ValidInput_Registered()
        {
            string email = "dummy1@gmail.com";
            string name = "Mehdi Hossain";
            string password = "test1245";
            Assert.IsFalse(service.Authenticate(email, password));


            bool registrationSuccess = service.UserRegistration(name, email, password);

            Assert.IsTrue(registrationSuccess);

            Assert.IsTrue(service.Authenticate(email, password));
        }
    }
}

using System;
using System.Collections.Generic;

namespace HiveMind.ApplicationException
{
    public static class KeyLookUpConstant
    {
        private static Dictionary<string, string> keyLookUp = new Dictionary<string, string>();
        private static string DefaultExceptionMessage = "System Exception Occured";

        static KeyLookUpConstant()
        {
            keyLookUp.Add("default", DefaultExceptionMessage);
            keyLookUp.Add("authentication.input.empty", "User Authentication Input can't be null or empty");
            keyLookUp.Add("registration.input.empty", "User Registration Input can't be null or empty");
            keyLookUp.Add("user.data.notfound.for.email", "No user found for given email: {0}");
            keyLookUp.Add("user.data.multiplefound.for.email", "More than one user registed with the given email: {0}");
            
            keyLookUp.Add("sql.error.generic", "Error occured during database operation.");
            keyLookUp.Add("implementation.incomplete", "The following feature is incomplete");


            keyLookUp.Add("input.invalid.one", "Invalid input: {0}");

        }

        public static string getMessage(string key)
        {
            try
            {
                return keyLookUp[key];
            }
            catch(Exception)
            {
                return DefaultExceptionMessage;
            }
        }
    }
}
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
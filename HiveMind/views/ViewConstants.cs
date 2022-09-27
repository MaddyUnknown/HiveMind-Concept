using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HiveMind.View
{
    public class ViewConstants
    {
        //Image Resources
        public static string errorImageLoc = "~/asset/image/icon/error.png";
        public static string successImageLoc = "~/asset/image/icon/success.png";

        //Toast Headers
        public static string userRegistration_header = "User Registration";
        public static string invalidInput_header = "Invalid Input";
        public static string serverNote_header = "Server Note";
        public static string serverError_header = "Server Error";
        public static string invalidCredentials_header = "Invalid Credentials";


        //Toast Bodys
        public static string userRegistationSuccess_body = "User Was Successfully Registered";
        public static string emailAlreadyRegistered_body = "Email Is Already Registed";
        public static string invalidInput_body = "Provided Input Are Not Valid";
        public static string enterValidInput_body = "Please Enter Valid Email and Password";
        public static string serverError_body = "An Error Occured While Processing Your Request. Please Try Again Later.";

        public static string featureNotImplemented = "This Feature Is Currently Unavailable";

    }
}
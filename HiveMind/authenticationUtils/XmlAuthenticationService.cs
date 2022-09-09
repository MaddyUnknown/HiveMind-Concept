using System;
using System.Data;
using System.Configuration;
using System.Xml;

namespace HiveMind.AuthenticateUtils
{

    public class XmlAuthenticationService : BaseAuthenticationService
    {

        public override bool Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("User Authentication Input can't be null or empty");
            }

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(ConfigurationManager.AppSettings["LoginFileLocation"]);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (email.ToLower() == row["email"].ToString().ToLower() && Encrypt(password) == row["password"].ToString())
                {
                    return true;
                }
            }

            return false;
        }

        public override bool UserRegistration(string name, string email, string password)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("User Registration Input can't be null or empty");
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ConfigurationManager.AppSettings["LoginFileLocation"]);
            XmlElement root = xmlDocument.DocumentElement;

            bool alreadyRegisterd = false;

            foreach(XmlNode element in root.SelectNodes("user/email"))
            {
                if(element.InnerText == email)
                {
                    alreadyRegisterd = true;
                    break;
                }
            }

            if (!alreadyRegisterd)
            {
                XmlElement newUser = xmlDocument.CreateElement("user");
                XmlElement newUserName = xmlDocument.CreateElement("name");
                XmlElement newUserEmail = xmlDocument.CreateElement("email");
                XmlElement newUserPassword = xmlDocument.CreateElement("password");

                XmlText newUserNameContent = xmlDocument.CreateTextNode(name);
                XmlText newUserEmailContent = xmlDocument.CreateTextNode(email);
                XmlText newUserPasswordContent = xmlDocument.CreateTextNode(Encrypt(password));


                newUser.AppendChild(newUserName);
                newUser.AppendChild(newUserEmail);
                newUser.AppendChild(newUserPassword);

                newUserName.AppendChild(newUserNameContent);
                newUserEmail.AppendChild(newUserEmailContent);
                newUserPassword.AppendChild(newUserPasswordContent);

                root.InsertAfter(newUser, root.LastChild);
                xmlDocument.Save(ConfigurationManager.AppSettings["LoginFileLocation"]);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Data;
using System.Xml;
using HiveMind.Model;
using System.Collections.Generic;
using HiveMind.ApplicationException;


namespace HiveMind.AuthenticateUtils
{

    public class XmlAuthenticationService : BaseAuthenticationService
    {
        private readonly string path;

        public XmlAuthenticationService(string path)
        {
            this.path = path;
        }

        public override bool Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new KeyedException("input.invalid.one", email);
            }

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(this.path);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if (email.ToLower() == row["email"].ToString().ToLower() && Encrypt(password) == row["password"].ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public override string CancelToken(string email)
        {
            throw new KeyedException("feature.notimplementated");
        }
        

        public override User UserDetials(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new KeyedException("authentication.input.empty");
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.path);
            XmlElement root = xmlDocument.DocumentElement;

            List<User> users = new List<User>();

            foreach (XmlNode element in root.SelectNodes("user"))
            {
                if (element.SelectSingleNode("email").InnerText == email)
                {
                    User user = new User();
                    user.Name = element.SelectSingleNode("name").InnerText;
                    user.Email = element.SelectSingleNode("email").InnerText;

                    users.Add(user);
                }
            }

            if(users.Count == 0)
            {
                throw new KeyedException("user.data.notfound.for.email", email);
            }
            else if(users.Count > 1)
            {

                throw new KeyedException("user.data.multiplefound.for.email", email);
            }
            else
            {
                return users[0];
            }
        }

        public override bool UserRegistration(string name, string email, string password)
        {
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new KeyedException("registration.input.empty");
            }

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(this.path);
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
                xmlDocument.Save(this.path);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

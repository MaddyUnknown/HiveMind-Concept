using System;
using System.Linq;
using System.Web;

namespace HiveMind.ApplicationException
{
    public class ApplicationBaseException : Exception
    {

        public ApplicationBaseException() : base()
        {

        }

        public ApplicationBaseException(string message) : base(message)
        {

        }
    }
}
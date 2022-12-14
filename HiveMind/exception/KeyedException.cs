namespace HiveMind.ApplicationException
{
    public class KeyedException : ApplicationBaseException
    {
        public KeyedException(string key) : base(message(key))
        {

        }

        public KeyedException(string key, params object[] args) : base(message(key, args))
        {

        }

        private static string message(string key, object[] args = null)
        {
            if(key == null)
            {
                key = "default";
            }

            if (args == null)
            {
                return KeyLookUpConstant.getMessage(key);
            }
            else
            {
                return string.Format(KeyLookUpConstant.getMessage(key), args);
            }
        }
    }
}
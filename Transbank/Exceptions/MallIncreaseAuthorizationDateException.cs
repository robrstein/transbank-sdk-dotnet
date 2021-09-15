using System;

namespace Transbank.Exceptions
{
    public class MallIncreaseAuthorizationDateException : TransbankException
    {
        public MallIncreaseAuthorizationDateException(string message) : base(-1, message) { }

        public MallIncreaseAuthorizationDateException(int code, string message) : base(code, message) { }

        public MallIncreaseAuthorizationDateException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}

using System;

namespace Transbank.Exceptions
{
    public class MallReversePreAuthorizedAmountException : TransbankException
    {
        public MallReversePreAuthorizedAmountException(string message) : base(-1, message) { }

        public MallReversePreAuthorizedAmountException(int code, string message) : base(code, message) { }

        public MallReversePreAuthorizedAmountException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}

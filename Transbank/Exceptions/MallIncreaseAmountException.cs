using System;

namespace Transbank.Exceptions
{
    public class MallIncreaseAmountException : TransbankException
    {
        public MallIncreaseAmountException(string message) : base(-1, message) { }

        public MallIncreaseAmountException(int code, string message) : base(code, message) { }

        public MallIncreaseAmountException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}

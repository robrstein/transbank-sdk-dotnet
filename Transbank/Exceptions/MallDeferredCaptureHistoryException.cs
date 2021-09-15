using System;

namespace Transbank.Exceptions
{
    public class MallDeferredCaptureHistoryException : TransbankException
    {
        public MallDeferredCaptureHistoryException(string message) : base(-1, message) { }

        public MallDeferredCaptureHistoryException(int code, string message) : base(code, message) { }

        public MallDeferredCaptureHistoryException(int code, string message, Exception innerException)
            : base(code, message, innerException) { }
    }
}

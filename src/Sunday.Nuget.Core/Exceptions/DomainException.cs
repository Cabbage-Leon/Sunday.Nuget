using System;

namespace Sunday.Nuget.Core.Exceptions
{
    public class ErrorCodeDictionary
    {
        public static string GetErrorMessage(object errorcode, params object[] args)
        {
            var errorMessage = errorcode.ToString();
            if (args != null && args.Length > 0)
                return string.Format(errorMessage, args);
            return errorMessage;
        }
    }

    [Serializable]
    public class DomainException : Exception
    {
        public object ErrorCode { get; protected set; }

        public DomainException()
        {
        }

        public DomainException(object errorCode, string message = null, Exception innerException = null)
          : base(message ?? ErrorCodeDictionary.GetErrorMessage(errorCode), innerException)
        {
            ErrorCode = errorCode;
        }

        public DomainException(object errorCode, object[] args, Exception innerException = null)
            : base(ErrorCodeDictionary.GetErrorMessage(errorCode, args), innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
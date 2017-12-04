using System;
using MemoTime.Core.Domain;

namespace MemoTime.Infrastructure.Exceptions
{
    public class ServiceException : MemoTimeException
    {

        protected ServiceException()
        {
        }

        public ServiceException(string code) : base(code)
        {
        }

        public ServiceException(string message, params object[] args)
            : this(string.Empty, message, args)
        {

        }

        public ServiceException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {

        }

        public ServiceException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {

        }

        public ServiceException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
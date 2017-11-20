using System;

namespace MemoTime.Core.Domain
{
    public abstract class MemoTimeException : Exception
    {
        public string Code { get; protected set; }
        
        protected MemoTimeException()
        {}

        public MemoTimeException(string code)
        {
            Code = code;
        }

        public MemoTimeException(string message, params object[] args) 
            :this(string.Empty, message, args)
        {
            
        }

        public MemoTimeException(string code, string message, params object[] args)
            :this(null, code, message, args)
        {
            
        }

        public MemoTimeException(Exception innerException, string message, params object[] args)
            :this(innerException, string.Empty, message, args)
        {
            
        }

        public MemoTimeException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
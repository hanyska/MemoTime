using System;

namespace MemoTime.Core.Domain
{
    public class MemoTimeException : Exception
    {
        protected string Code { get; set; }

        protected MemoTimeException()
        {
            
        }

        public MemoTimeException(string code)
        {
            Code = code;
        }

        public MemoTimeException(string message, params object[] args) : this(string.Empty, message, args)
        {
            
        }
    }
}
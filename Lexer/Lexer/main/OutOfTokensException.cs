using System;
using System.Runtime.Serialization;

namespace Lex
{
    [Serializable]
    internal class OutOfTokensException : Exception
    {
        public OutOfTokensException()
        {
        }

        public OutOfTokensException(string message) : base(message)
        {
        }

        public OutOfTokensException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OutOfTokensException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
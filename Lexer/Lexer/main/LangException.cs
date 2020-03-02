using System;
using System.Runtime.Serialization;

namespace Lex
{
    [Serializable]
    internal class LangException : Exception
    {
        public LangException()
        {
        }

        public LangException(string message) : base(message)
        {
        }

        public LangException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
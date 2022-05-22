using System;
using System.Runtime.Serialization;

namespace ClearBank.DeveloperTest.Domain.Account.Exceptions
{
    public class InvalidAccountNumberException : Exception
    {
        public InvalidAccountNumberException()
        {
        }

        public InvalidAccountNumberException(string message) : base(message)
        {
        }

        public InvalidAccountNumberException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidAccountNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace ClearBank.DeveloperTest.Domain.Account.Exceptions
{
    public class InvalidDebitAmountException : Exception
    {
        public InvalidDebitAmountException()
        {
        }

        public InvalidDebitAmountException(string message) : base(message)
        {
        }

        public InvalidDebitAmountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDebitAmountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

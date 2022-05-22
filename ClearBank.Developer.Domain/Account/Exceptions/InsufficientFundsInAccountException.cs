using System;
using System.Runtime.Serialization;
namespace ClearBank.DeveloperTest.Domain.Account.Exceptions
{
    public class InsufficientFundsInAccountException : Exception
    {
        public InsufficientFundsInAccountException()
        {
        }

        public InsufficientFundsInAccountException(string message) : base(message)
        {
        }

        public InsufficientFundsInAccountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InsufficientFundsInAccountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

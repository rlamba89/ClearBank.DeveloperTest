using System;
using System.Runtime.Serialization;

namespace ClearBank.DeveloperTest.Domain.Account.Exceptions
{
    public class InValidPaymentSchemeException : Exception
    {
        public InValidPaymentSchemeException()
        {
        }

        public InValidPaymentSchemeException(string message) : base(message)
        {
        }

        public InValidPaymentSchemeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InValidPaymentSchemeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

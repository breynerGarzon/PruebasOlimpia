using System;
using System.Runtime.Serialization;

namespace Olimpia.Model.Exceptions
{
    public class InvoiceException : Exception
    {
        public InvoiceException()
        {
        }

        public InvoiceException(string message) : base(message)
        {
        }

        public InvoiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvoiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
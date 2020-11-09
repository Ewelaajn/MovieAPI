using System;
using System.Runtime.Serialization;

namespace MovieApi.Services.Exceptions
{
    public class MailTakenException : Exception
    {
        public MailTakenException()
        {
        }

        protected MailTakenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public MailTakenException(string message) : base(message)
        {
        }

        public MailTakenException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
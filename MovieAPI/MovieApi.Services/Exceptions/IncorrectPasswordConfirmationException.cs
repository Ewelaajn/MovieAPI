using System;
using System.Runtime.Serialization;

namespace MovieApi.Services.Exceptions
{
    public class IncorrectPasswordConfirmationException : Exception
    {
        public IncorrectPasswordConfirmationException()
        {
        }

        protected IncorrectPasswordConfirmationException(SerializationInfo info, StreamingContext context) : base(info,
            context)
        {
        }

        public IncorrectPasswordConfirmationException(string message) : base(message)
        {
        }

        public IncorrectPasswordConfirmationException(string message, Exception innerException) : base(message,
            innerException)
        {
        }
    }
}
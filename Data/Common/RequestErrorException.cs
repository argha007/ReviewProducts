using System;
using System.Runtime.Serialization;

namespace Data.Common
{
    public class RequestErrorException : Exception
    {
        public RequestError Error { get; }

        public RequestErrorException(RequestError error)
        {
            Error = error ?? throw new ArgumentNullException(nameof(error));
        }

        public RequestErrorException(string message) : base(message)
        {
        }

        public RequestErrorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RequestErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

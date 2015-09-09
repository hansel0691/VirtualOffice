using System;
using System.Runtime.Serialization;

namespace Domain.Models.Exceptions
{
    [Serializable]
    public class DataAccessException : Exception
    {
        public DataAccessException()
        {
        }

        public DataAccessException(string message)
            : base(message)
        {
        }

        public DataAccessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DataAccessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
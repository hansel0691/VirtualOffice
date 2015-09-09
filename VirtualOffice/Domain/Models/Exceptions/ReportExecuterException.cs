using System;
using System.Runtime.Serialization;

namespace Domain.Models.Exceptions
{
    [Serializable]
    public class ReportExecuterException : Exception
    {
        public ReportExecuterException()
        {
        }

        public ReportExecuterException(string message): base(message)
        {
        }

        public ReportExecuterException(string message, Exception innerException):base(message, innerException)
        {
        }

        public ReportExecuterException(SerializationInfo info, StreamingContext context):base(info, context)
        {
        }
    }
}
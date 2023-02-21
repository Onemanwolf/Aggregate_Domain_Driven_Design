using System.Runtime.Serialization;

namespace Application.Models.Auction
{
    [Serializable]
    internal class MoreThanTwoDecimalPlacesException : Exception
    {
        public MoreThanTwoDecimalPlacesException()
        {
        }

        public MoreThanTwoDecimalPlacesException(string? message) : base(message)
        {
        }

        public MoreThanTwoDecimalPlacesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MoreThanTwoDecimalPlacesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
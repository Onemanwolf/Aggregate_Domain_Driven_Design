using System.Runtime.Serialization;

namespace Application.Models.Auction
{
    [Serializable]
    internal class MoneyCanNotBeNegativeValueException : Exception
    {
        public MoneyCanNotBeNegativeValueException()
        {
        }

        public MoneyCanNotBeNegativeValueException(string? message) : base(message)
        {
        }

        public MoneyCanNotBeNegativeValueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected MoneyCanNotBeNegativeValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
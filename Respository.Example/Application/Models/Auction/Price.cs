
using System.Collections;
using Application.Infrastructure;
namespace Application.Models.Auction
{
    public class Price : ValueObject<Price>
    {
        public Price(Money amount)
        {
            if (amount == null) throw new ArgumentNullException(nameof(amount));
            Amount = amount;
        }

        public Money Amount { get; private set; }

        public Money BidIncrement()
        {
            if (Amount.IsGreaterThanOrEqualTo(new Money(0.01m)) && Amount.IsLessThanOrEqualTo(new Money(0.05m)))
                return Amount.Add(new Money(0.05m));
            if (Amount.IsGreaterThanOrEqualTo(new Money(1.00m)) && Amount.IsLessThanOrEqualTo(new Money(4.99m)))
                return Amount.Add(new Money(0.20m));
            if (Amount.IsGreaterThanOrEqualTo(new Money(5.00m)) && Amount.IsLessThanOrEqualTo(new Money(9.99m)))
                return Amount.Add(new Money(0.50m));
            return Amount.Add(new Money(1.00m));
        }

        public bool CanBeExceededBy(Money offer)
        {
            return offer.IsGreaterThanOrEqualTo(BidIncrement());
        }



        protected override IEnumerable<object> GetAttributesToIncludeEqualityCheck()
        {
            return new List<object>() { Amount };
        }
    }
}
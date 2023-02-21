using System.Collections;
using Application.Infrastructure;

namespace Application.Models.Auction
{
    public class Offer : ValueObject<Offer>
    {

        public Offer(Guid bidderId, Money maxminBid, DateTime timeOfOffer)
        {
            BidderId = bidderId;
            MaximumBid = maxminBid;
            TimeOfOffer = timeOfOffer;
        }

        public Guid BidderId { get; }
        public Money MaximumBid { get; private set; }
        public DateTime TimeOfOffer { get; private set; }

        protected override IEnumerable<object> GetAttributesToIncludeEqualityCheck()
        {
            throw new NotImplementedException();
        }
    }
}
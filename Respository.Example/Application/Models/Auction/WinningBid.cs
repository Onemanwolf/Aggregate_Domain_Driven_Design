using Application.Infrastructure;

namespace Application.Models.Auction
{
    public class WinningBid : ValueObject<WinningBid>
    {
        public WinningBid(Guid bidder, Money maximumBid, Money bid, DateTime timeOfBid)
        {
            if(bidder == Guid.Empty)
            throw new ArgumentNullException($"Bidder cannot be null {nameof(bidder)}");
            if(maximumBid == null)
            throw new ArgumentNullException($"MaxminBid cannot be null {nameof(maximumBid)}");
            if(timeOfBid == DateTime.MinValue)
            throw new ArgumentNullException($"TimeOfBid cannot be null {nameof(timeOfBid)}");
            Bidder = bidder;
            MaximumBid = maximumBid;
            CurrentAuctionPrice = new Price(bid);
            TimeOfBid = timeOfBid;
        }


        public Guid Bidder { get; private set; }
        public DateTime TimeOfBid { get; private set; }
        public Money MaximumBid { get; private set; }
        public Price CurrentAuctionPrice { get; private set; }

        public WinningBid RaiseMaxminBid(Money newAmount)
        {


            if (newAmount.IsGreaterThan(MaximumBid))
            {
                return new WinningBid(Bidder, newAmount, CurrentAuctionPrice.Amount, DateTime.Now);
            }
            else
            {
                throw new ApplicationException("Maximun bid increase must be larger current maximun bid");
            }
        }

        public bool WasMadeBy(Guid bidder)
        {
            return Bidder.Equals(bidder) ;
        }

        public bool CanBeExceededBy(Money offer)
        {
            return CurrentAuctionPrice.CanBeExceededBy(offer);
        }

        public bool HasNotReachedMaxminBid()
        {
            return MaximumBid.IsGreaterThan(CurrentAuctionPrice.Amount);
        }

        protected override IEnumerable<object> GetAttributesToIncludeEqualityCheck()
        {
            return new List<object>() { Bidder, TimeOfBid, MaximumBid, CurrentAuctionPrice };
        }

// need was made by
//Can exeed etc ...



       


    }
}


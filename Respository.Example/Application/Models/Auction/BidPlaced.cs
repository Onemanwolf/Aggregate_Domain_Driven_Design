namespace Application.Models.Auction
{
    /// <summary>
    /// Domain Event BidPlaced
    /// </summary>
    public class BidPlaced
    {
        public BidPlaced(Guid auctionID, Guid bidderId, Money amountBid, DateTime timeOfBid)
        {

            if(auctionID == Guid.Empty)
                throw new ArgumentNullException($"AuctionId cannot be null {nameof(auctionID)}");
            if(bidderId == Guid.Empty)
                throw new ArgumentNullException($"BidderId cannot be null {nameof(bidderId)}");
            if(amountBid == null)
                throw new ArgumentNullException($"AmountBid cannot be null {nameof(amountBid)}");
            if(timeOfBid == DateTime.MinValue)
                throw new ArgumentNullException($"TimeOfBid cannot be null {nameof(timeOfBid)}");
            AuctionId = auctionID;
            BidderId = bidderId;
            AmountBid = amountBid;
            TimeOfMemberBid = timeOfBid;
        }

        public Guid AuctionId { get; private set; }
        public Guid BidderId { get; private set; }
        public Money AmountBid { get; private set; }
        public DateTime TimeOfMemberBid { get; private set; }



    }
}
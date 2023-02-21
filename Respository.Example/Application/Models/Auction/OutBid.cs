namespace Application.Models.Auction
{
    public class OutBid
    {
        public OutBid(Guid auctionId, Guid bidderId)
        {
            if (auctionId == Guid.Empty)
                throw new ArgumentNullException($"AuctionId cannot be null {nameof(auctionId)}");
            if (bidderId == Guid.Empty)
                throw new ArgumentNullException($"BidderId cannot be null {nameof(bidderId)}");
            AuctionId = auctionId;
            BidderId = bidderId;
        }

        public Guid AuctionId { get; private set; }
        public Guid BidderId { get; private set; }
    }
}
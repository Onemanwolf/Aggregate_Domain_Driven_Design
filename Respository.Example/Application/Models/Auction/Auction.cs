using Application.Infrastructure;
namespace Application.Models.Auction
{
    public class Auction : Entity<Guid>
    {
        public Auction(Guid id, Money startingPrice, DateTime endsAt)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException($"AuctionId cannot be null {nameof(id)}");
            if (startingPrice == null)
                throw new ArgumentNullException($"StartingPrice cannot be null {nameof(startingPrice)}");
            if (endsAt == DateTime.MinValue)
                throw new ArgumentNullException($"EndsAt cannot be null {nameof(endsAt)}");
            Id = id;
            StartingPrice = startingPrice;
            EndsAt = endsAt;
        }

        public Money StartingPrice { get; private set; }
        public DateTime EndsAt { get; private set; }

        public WinningBid WinningBid { get; private set; }

        private bool StilInProgress(DateTime currentTime)
        {
            return (EndsAt > currentTime);
        }

        public void PlaceBidFor(Offer offer, DateTime currentTime)
        {
            if (StilInProgress(currentTime))
            {
                if (FirstOffer())
                {

                    PlaceABidForTheFirst(offer);
                }
                else if (BidderIsIncreasingMaxminBidToNew(offer))
                {
                    WinningBid = WinningBid.RaiseMaxminBid(offer.MaximumBid);
                    //PlaceABidForTheFirst(new BidPlaced(Id, offer.BidderId, offer.Amount, currentTime));
                }

            }

        }



        private bool BidderIsIncreasingMaxminBidToNew(Offer offer)
        {
            return WinningBid.WasMadeBy(offer.BidderId) && offer.MaximumBid
            .IsGreaterThan(WinningBid.MaximumBid);
        }

        private bool FirstOffer()
        {
            return WinningBid == null;
        }

        private void PlaceABidForTheFirst(Offer offer)
        {
            if (offer.MaximumBid.IsGreaterThanOrEqualTo(StartingPrice))
            {
                WinningBid = new WinningBid(offer.BidderId, offer.MaximumBid, StartingPrice, DateTime.Now);
                Place(WinningBid);
            }

        }

        private void Place(WinningBid newBid)
        {
            if (FirstOffer() && WinningBid.WasMadeBy(newBid.Bidder))
            {
                DomainEvents.Raise<OutBid>(new OutBid(Id, newBid.Bidder));
            }
            else
            {
                WinningBid = newBid;
                DomainEvents.Raise<BidPlaced>(new BidPlaced(Id, newBid.Bidder, newBid.CurrentAuctionPrice.Amount, DateTime.Now));
            }

        }
    }
}
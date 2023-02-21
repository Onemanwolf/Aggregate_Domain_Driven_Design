using Application.Models.Auction;
namespace Application.Models.Auction
{
    public class AutomaticBiddlerService
    {
        public IEnumerable<WinningBid> GenerateNextSequenceOfBidsAfter(Offer offer, WinningBid currentWinningBid)
        {
            var bids = new List<WinningBid>();
            if (currentWinningBid.MaximumBid.IsGreaterThanOrEqualTo(offer.MaximumBid))
            {
                var bidFromOffer = new
                WinningBid(offer.BidderId,
                offer.MaximumBid, offer.MaximumBid,
                offer.TimeOfOffer);
                bids.Add(bidFromOffer);
                bids.Add(CalculateNextBid(bidFromOffer,
                new Offer(offer.BidderId, offer.MaximumBid, offer.TimeOfOffer)));

            }
            else
            {
                bids.Add(new WinningBid(offer.BidderId, offer.MaximumBid, offer.MaximumBid, offer.TimeOfOffer));
            }
            return bids;
        }

        private WinningBid CalculateNextBid(WinningBid winningBid, Offer offer)
        {
            WinningBid bid;
            if (winningBid.CanBeExceededBy(offer.MaximumBid))
            {
                bid = new WinningBid(offer.BidderId, offer.MaximumBid, offer.MaximumBid, offer.TimeOfOffer);
            }
            else
            {
                bid = new WinningBid(offer.BidderId, offer.MaximumBid, winningBid.CurrentAuctionPrice.BidIncrement(), offer.TimeOfOffer);
            }
            return bid;
        }
    }
}
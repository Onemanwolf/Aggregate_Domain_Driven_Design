using Microsoft.Extensions.Logging;

namespace Presentation.Service
{
    public interface IAuctionService
    {
         Task CreateAuction();
    }

    public class AuctionService : IAuctionService
    {
        private readonly ILogger<AuctionService> _logger;

        public AuctionService(ILogger<AuctionService> logger)
        {
            _logger = logger;
        }
        public async Task CreateAuction()
        {
           _logger.LogInformation("Auction created");
        }
    }
}
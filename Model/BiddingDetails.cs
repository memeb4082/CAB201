using Auction.View;
namespace Auction.Model
{
    public abstract class BiddingDetails
    {
        protected string bidderEmail;
        protected decimal bidAmount;

        public string BidderEmail{get; set;}
        public decimal BidAmount{get; set;}
        public string ProductName{get; set;}

        public BiddingDetails(string bidderEmail, decimal bidAmount){
            this.bidderEmail = bidderEmail;
            // TODO: Check video for prompt
            this.bidAmount = bidAmount;
        }
    }
}
// using Auction.View;
namespace Auction.Model
{
    public abstract class BiddingDetails
    {
        // protected string bidderEmail;
        // protected string bidderName;
        protected decimal bidAmount;

        // public string BidderEmail{get; set;}
        // public decimal BidAmount{get; set;}
        public override string ToString()
        {
            // return $"{(bidderName == null ? "-" : bidderName)}\t {(bidderEmail == null ? "-" : bidderEmail)}\t {(bidAmount == 0.0M ? "-" : bidAmount)}";
            return $"{(bidAmount == 0.0M ? "-" : bidAmount)}";
        }
        public BiddingDetails() {
            // this.bidderEmail = null;
            // this.bidderName = null;
            this.bidAmount = 0.0M;
        }
        public BiddingDetails(string bidderEmail, decimal bidAmount){
            // this.bidderEmail = bidderEmail;
            // this.bidderName = bidderName;
            // TODO: Check video for prompt
            this.bidAmount = bidAmount;
        }
    }
}
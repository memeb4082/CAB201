// using Auction.View;
namespace Auction.Model
{
    public abstract class BiddingDetails
    {
        protected string bidderEmail;
        // protected string bidderName;
        protected decimal bidAmount;

        public string BidderEmail
        {
            get
            {
                return bidderEmail;
            }
            set
            {
                bidderEmail = value;
            }
        }
        public decimal BidAmount
        {
            get
            {
                return bidAmount;
            }
            set
            {
                bidAmount = value;
            }
        }
        public override string ToString()
        {
            // return $"{(bidderName == null ? "-" : bidderName)}\t {(bidderEmail == null ? "-" : bidderEmail)}\t {(bidAmount == 0.0M ? "-" : bidAmount)}";
            return $"{(bidAmount == 0.0M ? "-" : bidAmount)}";
        }
        public BiddingDetails(string bidderEmail, decimal bidAmount)
        {
            this.bidderEmail = bidderEmail;
            this.bidAmount = bidAmount;
        }
    }
}
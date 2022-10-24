using static Auction.CustomUI;
namespace Auction.Model
{
    public abstract class BiddingDetails
    {
        protected string bidderEmail;
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
            return $"{(bidAmount == 0.0M ? "-" : bidAmount)}";
        }
        public BiddingDetails(string bidderEmail, decimal bidAmount)
        {
            this.bidderEmail = bidderEmail;
            this.bidAmount = bidAmount;
        }
    }
}
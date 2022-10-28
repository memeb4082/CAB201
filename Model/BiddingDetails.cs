using static Auction.CustomUI;
namespace Auction.Model
{
    public abstract class BiddingDetails
    {
        protected decimal bidAmount;
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
        public BiddingDetails(decimal bidAmount)
        {
            this.bidAmount = bidAmount;
        }
    }
}
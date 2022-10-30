using static Auction.CustomUI;
using System.Xml.Linq;
namespace Auction.Model
{
    public abstract class BiddingDetails
    {
        protected decimal bidAmount;
        private Client bidderData;
        internal Client BidderData
        {
            get
            { return bidderData; }
            set
            {
                bidderData = value;
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
            if (BidderData == null)
            {
                return $"-\t -";
            }
            else
            {
                return $"{BidderData.Name} ${(bidAmount == 0.0M ? "-" : bidAmount)}\t {BidderData.Email}";
            }
        }
        public abstract XElement ToXElement();
        public BiddingDetails(decimal bidAmount)
        {
            this.bidAmount = bidAmount;
        }
        public BiddingDetails()
        {
        }
    }
}
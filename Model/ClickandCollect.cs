using System;
using System.Xml.Linq;
using static Auction.CustomUI;
namespace Auction.Model
{
    public class ClickandCollect : BiddingDetails
    {
        protected DateTime startDateTime;
        protected DateTime endDateTime;
        public DateTime Start { get { return startDateTime; } }
        public DateTime End { get { return endDateTime; } }
        public override XElement ToXElement()
        {
            XElement XElem = new XElement("ClickAndCollect",
                new XElement(BidderData.ToXElementBidding()),
                new XElement("BidAmount", bidAmount.ToString()),
                new XElement("StartTime", startDateTime.ToString()),
                new XElement("EndTime", endDateTime.ToString())
            );
            return XElem;
        }
        public ClickandCollect(decimal bidAmount) : base(bidAmount)
        {
            // TODO: Double check video for prompts
            startDateTime = CustomDateTime("Please enter start time");
            while (startDateTime.Subtract(DateTime.Now).Hours < 1)
            {
                startDateTime = CustomDateTime("Please enter start time");
            }
            endDateTime = CustomDateTime("Please enter end time");
            while (endDateTime.Subtract(startDateTime).Hours < 1)
            {
                endDateTime = CustomDateTime("Please enter end time");
            }
        }
        internal ClickandCollect(DateTime startDateTime, DateTime endDateTime, decimal bidAmount) : base(bidAmount)
        {
            this.startDateTime = startDateTime;
            this.endDateTime = endDateTime;
            this.bidAmount = bidAmount;
        }
    }
}
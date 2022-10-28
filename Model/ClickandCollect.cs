using System;
using static Auction.CustomUI;
namespace Auction.Model
{
    public class ClickandCollect : BiddingDetails
    {
        protected DateTime startDateTime;
        protected DateTime endDateTime;

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
    }
}
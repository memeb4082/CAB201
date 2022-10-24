using System;
// using Auction.View;
namespace Auction.Model
{
    public class ClickandCollect : BiddingDetails
    {
        protected DateTime startDateTime;
        protected DateTime endDateTime;

        public ClickandCollect(string bidderEmail, int productIndex) : base(bidderEmail, productIndex)
        {
            // TODO: Double check video for prompts
            startDateTime = CustomInput.CustomDateTime("Please enter start time");
            while (startDateTime.Subtract(DateTime.Now).Hours < 1)
            {
                startDateTime = CustomInput.CustomDateTime("Please enter start time");
            }
            endDateTime = CustomInput.CustomDateTime("Please enter end time");
            while (endDateTime.Subtract(startDateTime).Hours < 1)
            {
                endDateTime = CustomInput.CustomDateTime("Please enter end time");

            }
        }
    }
}
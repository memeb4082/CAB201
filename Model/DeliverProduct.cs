using System;
// using Auction.View;
namespace Auction.Model
{
    public class DeliverProduct : BiddingDetails
    {
        protected Address deliveryAddress;
        public DeliverProduct(decimal bidAmount) : base(bidAmount)
        {
            this.deliveryAddress = new Address();
        }
        public DeliverProduct(Address deliveryAddress, string bidderEmail, decimal bidAmount) : base(bidAmount)
        {
            this.deliveryAddress = deliveryAddress;
        }
    }
}
using System;
// using Auction.View;
namespace Auction.Model
{
    public class DeliverProduct : BiddingDetails
    {
        protected Address deliveryAddress;
        public DeliverProduct(string bidderEmail, int productIndex) : base(bidderEmail, productIndex)
        {
            this.deliveryAddress = new Address();
        }
        public DeliverProduct(Address deliveryAddress, string bidderEmail, int productIndex) : base(bidderEmail, productIndex)
        {
            this.deliveryAddress = deliveryAddress;
        }
    }
}
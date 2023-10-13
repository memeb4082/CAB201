using System;
using System.Xml.Linq;
// using Auction.View;
namespace Auction.Model
{
    public class DeliverProduct : BiddingDetails
    {
        protected Address deliveryAddress;
        internal Address DeliveryAddress
        {
            get { return deliveryAddress; }
        }
        public override XElement ToXElement()
        {
            XElement XElem = new XElement("Delivery",
                new XElement(BidderData.ToXElementBidding()),
                new XElement("BidAmount", bidAmount.ToString()),
                deliveryAddress.ToXElement()
            );
            return XElem;
        }
        public override string ToString()
        {
            return $"Deliver to {deliveryAddress.ToString()}";
        }
        public DeliverProduct(decimal bidAmount) : base(bidAmount)
        {
            this.deliveryAddress = new Address();
        }
        public DeliverProduct(Address deliveryAddress, decimal bidAmount) : base(bidAmount)
        {
            this.deliveryAddress = deliveryAddress;
        }
    }
}
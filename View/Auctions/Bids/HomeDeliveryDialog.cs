using System;
using static Auction.CustomUI;

using Auction.Model;

namespace Auction.View
{
    public class HomeDeliveryDialog : Dialog
    {
        const string TITLE = "Home Delivery";
        public HomeDeliveryDialog(ProductDetails Product, decimal BidAmt) : base(TITLE, Product, BidAmt)
        {
        }
        public override void Display()
        {
            DeliverProduct newBid = new DeliverProduct(BidAmount);
            Product.Bid = newBid;
        }
    }
}

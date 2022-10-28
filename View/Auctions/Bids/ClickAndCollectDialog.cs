using System;
using static System.Console;
using static Auction.CustomUI;
using Auction.Model;

namespace Auction.View
{
    public class ClickAndCollectDialog : Dialog
    {
        const string TITLE = "Click and collect";
        public ClickAndCollectDialog(ProductDetails Product, decimal BidAmt) : base(TITLE, Product, BidAmt)
        {
        }
        public override void Display()
        {
            ClickandCollect newBid = new ClickandCollect(BidAmount);
        }
    }
}

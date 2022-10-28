using System;
using Auction.Model;

namespace Auction.View
{
    public abstract class Dialog : IDisplayable
    {
        public string Title { get; }
        public decimal BidAmount {get;}
        protected AuctionHouse Auction {get;}
        protected ProductDetails Product {get;}
        public Dialog(string Title,
            AuctionHouse Auction)
        {
            this.Title = Title;
            this.Auction = Auction;
        }
        public Dialog(string Title,
            ProductDetails Product,
            decimal BidAmount)
        {
            this.Title = Title;
            this.Product = Product;
            this.BidAmount = BidAmount;
        }
        public abstract void Display();
    }
}
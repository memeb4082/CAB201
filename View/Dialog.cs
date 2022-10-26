using System;
using Auction.Model;

namespace Auction.View
{
    public abstract class Dialog : IDisplayable
    {
        public string Title { get; }
        protected AuctionHouse Auction {get;}
        public Dialog(string Title,
            AuctionHouse Auction)
        {
            this.Title = Title;
            this.Auction = Auction;
        }
        public abstract void Display();
    }
}
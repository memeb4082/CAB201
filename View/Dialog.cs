using System;
using Auction.Model;

namespace Auction.View
{
    public abstract class Dialog : IDisplayable
    {
        public string Title { get; }
        protected ProductStorage Products { get; }
        protected ClientStorage Clients { get; }
        public Dialog (string Title, ProductStorage Products, ClientStorage Clients) {
            this.Title = Title;
            this.Products = Products;
            this.Clients = Clients;
        }
        public abstract void Display();
    }
}
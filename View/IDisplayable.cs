using System;
using Auction.Model;

namespace Auction.View 
{
    interface IDisplayable
    {
        public string TITLE { get; set; }
        protected ProductStorage PRODUCTS { get; }
        protected ClientStorage CLIENTS { get; }
        void Display();
    }
}
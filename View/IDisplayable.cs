using System;
using Auction.Model;

namespace Auction.View {
    public interface IDisplayable {
        public string Title { get; }
        void Display();
    }
}
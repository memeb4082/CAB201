using Auction.Model;
namespace Auction.View {
    interface IDisplay {
        public string TITLE { get; }
        public void Display();
    }
}
using Auction.Model;

namespace Auction.View {
    abstract class Dialog : IDisplay {
        public string TITLE { get; }
        private protected ProductStorage Products { get; }
        private protected ClientStorage Clients { get; }
        public Dialog(string Title, ProductStorage Products, ClientStorage Clients) {
            this.Products = Products;
            this.Clients = Clients;
            this.TITLE = Title;
        }
        abstract void Display();
    }
}
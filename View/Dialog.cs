using Auction.Model;
namespace Auction.View {
    abstract class Dialog : IDisplayable {
        public string Title {get;}
        protected ClientStorage Clients {get;}
        protected ProductStorage Products {get;}
        public Dialog(string Title, ClientStorage Clients, ProductStorage Products) {
            this.Title = Title;
            this.Clients = Clients;
            this.Products = Products;
        }
        public abstract void Display();
    }
}
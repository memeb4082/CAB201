using Auction.Model;
namespace Auction.View {
    internal class AuctionMenu : Menu {
        private const string TITLE = "Client Menu";
        public AuctionMenu(ProductStorage Products, ClientStorage Clients) : base(
            TITLE,
            Products,
            Clients,
            new AdvertiseProduct(Products, Clients)
            // ViewProducts(Products, Clients),
            // SearchProducts(Products, Clients),
            // ViewBids(Products, Clients)
        ) {

        }
    }
}

using Auction.Model;
namespace Auction.View {
    internal class AuctionMenu : Menu {
        private const string TITLE = "Client Menu";
        public AuctionMenu(
            AuctionHouse Auction
        ) : base(
            TITLE,
            Auction,
            new AdvertiseDialog(Auction),
            new ViewProductsDialog(Auction),
            new SearchDialog(Auction),
            new ViewBidsDialog(Auction),
            new ViewPurchasedDialog(Auction),
            new MainMenu(Auction)
        ) {

        }
    }
}
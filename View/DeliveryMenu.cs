using Auction.Model;
namespace Auction.View
{
    internal class DeliveryMenu : Menu
    {
        private const string TITLE = "Delivery Instructions";
        public DeliveryMenu(
            AuctionHouse Auction
        ) : base(
        TITLE,
        Auction,
        new ClickAndCollectDialog(Auction),
        new HomeDeliveryDialog(Auction)
        )
        { }
    }
}

using Auction.Model;
using static Auction.CustomUI;
namespace Auction.View {
    public class ViewPurchasedDialog : Dialog {
        const string TITLE = "View My Purchased Items";
        public ViewPurchasedDialog(
            AuctionHouse auction
        ) : base(
            TITLE,
            auction
        ) {}
        public override void Display() {}
    }
}
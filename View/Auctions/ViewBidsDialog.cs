using Auction.Model;
using static Auction.CustomUI;
namespace Auction.View {
    public class ViewBidsDialog : Dialog {
        const string TITLE = "View Bids on My Products";
        public ViewBidsDialog(
            AuctionHouse auction
        ) : base(
            TITLE,
            auction
        ) {}
        public override void Display() {}
    }
}
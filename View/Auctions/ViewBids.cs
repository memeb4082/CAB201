using Auction.Model;
using static Auction.View.CustomInput;
namespace Auction.View {
    public class ViewBids : Dialog {
        const string TITLE = "View Bids on My Products";
        public ViewBids(
            ProductStorage Products,
            ClientStorage Clients
        ) : base(
            TITLE,
            Products,
            Clients
        ) {}
        public override void Display() {}
    }
}
using Auction.Model;
using static Auction.View.CustomInput;
namespace Auction.View {
    public class ViewPurchased : Dialog {
        const string TITLE = "View My Purchased Items";
        public ViewPurchased(
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
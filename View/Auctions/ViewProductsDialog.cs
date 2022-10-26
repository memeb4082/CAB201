using Auction.Model;
using static System.Console;
using static Auction.CustomUI;
namespace Auction.View {
    public class ViewProductsDialog : Dialog {
        const string TITLE = "View My Product List";
        public ViewProductsDialog(
            AuctionHouse auction
        ) : base(
            TITLE,
            auction
        ) {}
        public override void Display() {
            string tableSelling;
            Auction.ViewMyProducts(out tableSelling);
            WriteLine(tableSelling);
        }
    }
}
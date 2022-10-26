using static System.Console;
using static Auction.CustomUI;
using Auction.Model;

namespace Auction.View {
    public class RegisterDialog : Dialog {
        public const string TITLE = "Register";
        public RegisterDialog(
            AuctionHouse auction
            ) : 
            base(
                TITLE, 
                auction) {
        }
        public override void Display()
        {
            CustomTitle("Registration");
            Auction.Register();
            Menu LoginMenu = new MainMenu(Auction);
            LoginMenu.Display();
        }
    }
}
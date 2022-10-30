
using static Auction.CustomUI;
using Auction.Model;

namespace Auction.View
{
    public class LoginDialog : Dialog
    {
        const string TITLE = "Sign In";
        public LoginDialog(AuctionHouse auction) : base(TITLE, auction)
        {

        }
        public override void Display()
        {
            Client client = Auction.Login();
            Menu AuctionMenu = new AuctionMenu(Auction);
            AuctionMenu.Display();
        }
    }
}
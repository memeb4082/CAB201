using static System.Console;
using Auction.Model;

namespace Auction.View {
    public class LoginDialog : Dialog {
        const string TITLE = "Sign In";
        public LoginDialog(
            ProductStorage Products, 
            ClientStorage Clients) : base(
                TITLE, 
                Products, 
                Clients
                ) {

        }
        public override void Display()
        {
            Client client = Clients.Login();
            Products.Client = client;
            Menu AuctionMenu = new AuctionMenu(Products, Clients);
            AuctionMenu.Display();
        }
    }
}
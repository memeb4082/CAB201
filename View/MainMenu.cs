using System;
using Auction.Model;
namespace Auction.View
{
    public class MainMenu : Menu
    {
        private const string TITLE = "Main Menu";
        protected AuctionHouse auction;
        public MainMenu(AuctionHouse auction) : base(
            TITLE,
            auction,
            new RegisterDialog(
                auction
            ),
            new LoginDialog(
                auction
            ),
            new ExitDialog(
                "Exit"
            )
            )
        {
            this.auction = Auction;
        }
    }
}
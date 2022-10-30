using System.Xml.Linq;
using Auction.Model;
using Auction.View;
using static Auction.CustomUI;
namespace Auction
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string ENTER = "Welcome to the Auction House";
            const string EXIT = "Good bye, thank you for using the Auction House!";
            CustomMainTitle(ENTER);
            AuctionHouse Auction = new AuctionHouse("data.xml");
            MainMenu Menu = new MainMenu(
                Auction
            );
            Menu.Display();
            CustomMainTitle(EXIT);
        }
    }
}

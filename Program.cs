using static System.Console;
using Auction.Model;
using Auction.View;
namespace Auction
{
    class Program
    {
        public static void Main(string[] args)
        {
            WriteLine($"+------------------------------+\n| Welcome to the Auction House |\n+------------------------------+");
            AuctionHouse Auction = new AuctionHouse("data.xml");
            MainMenu Menu = new MainMenu(
                Auction
            );
            Menu.Display();
        }
    }
}

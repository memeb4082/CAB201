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
            ProductStorage Products = new ProductStorage("products.xml");
            ClientStorage Clients = new ClientStorage("data.xml");
            MainMenu Menu = new MainMenu(
                Products, 
                Clients
            );
            Menu.Display();
        }
    }
}

using static System.Console;
using Auction.Model;
using Auction.View;
namespace Auction
{
    class Program
    {
        public static void Main(string[] args)
        {
            ProductStorage products = new ProductStorage("products.xml");
            ClientStorage clients = new ClientStorage("data.xml");
            MainMenu menu = new MainMenu(products, clients);
            menu.Display();
        }
    }
}

using static System.Console;
using Auction.Model;
// using Auction.View;
namespace Auction
{
    class Program
    {
        public static void Main(string[] args)
        {
            // WriteLine($"+------------------------------+\n| Welcome to the Auction House |\n+------------------------------+");
            // Storage temp = new ProductStorage("products.xml");
            // ProductStorage Products = new ProductStorage("products.xml");
            // ClientStorage Clients = new ClientStorage("data.xml");
            // MainMenu Menu = new MainMenu(
            //     Products, 
            //     Clients
            // );
            // Menu.Display();
            AuctionHouse auction = new AuctionHouse("data.xml");
            auction.BidOnProduct("PEni5", "penis@penis.com", 0.0M);
            Client client = auction.Login();
            ProductDetails product = new ProductDetails();
            client.NewProduct(product);
        }
    }
}

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
            // auction.Register();
            Client client = auction.Login();
            auction.BidOnProduct("14", client, 0.0M);
            ProductDetails product = new ProductDetails();
            client.NewProduct(product);
        }
    }
}

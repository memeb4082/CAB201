using static System.Console;
using Auction.Model;
namespace Auction
{
    class Program
    {
        public static void Main(string[] args)
        {
            ProductStorage products = new ProductStorage("products.xml");
            ClientStorage clients = new ClientStorage("data.xml");
            
        }
    }
}

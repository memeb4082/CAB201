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
            Client user = clients.Login();
            foreach (ProductDetails product in products.ShowProducts(user.Email)) 
            {
                products.BidOnProduct(product, user, 50m);

            }
        }
    }
}

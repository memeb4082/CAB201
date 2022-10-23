using Auction.Model;
using static System.Console;
using static Auction.View.CustomInput;

namespace Auction.View
{
    public class SearchProducts : Dialog
    {
        const string TITLE = "Search for Advertised Products";
        public SearchProducts(
            ProductStorage Products,
            ClientStorage Clients
        ) : base(
            TITLE,
            Products,
            Clients
        )
        { }
        public override void Display()
        {
            CustomTitle($"Product Search for {Products.Client.Name}({Products.Client.Email})");
            WriteLine("Please supply a search phrase (ALL to see all products)");
            List<ProductDetails> ListProducts = Products.SearchProducts(CustomString());
            CustomTitle("Search results");
            WriteLine("Item #\t Product name\t Description\t List Price\t Bidder name\t Bidder email\t Bid amt\n");
            for (int i = 0; i < ListProducts.Count; i++)
            {
                WriteLine($"{i + 1}\t {ListProducts[i].ToString()}");
            }
            string yesno;
            WriteLine("\nWould you like to place a bid on any of these items (yes or no)?");
            yesno = CustomString().ToLower();
            while (yesno != "yes" || yesno != "no")
            {
                WriteLine("\nWould you like to place a bid on any of these items (yes or no)?");
                yesno = CustomString().ToLower();
            }
            if (yesno == "yes")
            {
                int index;
                index = CustomInput.CustomInt($"Please select an option between {1} and {ListProducts.Length}", $"Option must be between 1 and {ListProducts.Length + 1}");
                while ((1 > index) || (ListProducts.Length < index))
                {
                    index = CustomInput.CustomInt($"Please select an option between {1} and {ListProducts.Length}", $"Option must be between 1 and {ListProducts.Length + 1}");
                }
                ProductDetails product = ListProducts[index-1];
                decimal price = (product.Price > product.Bids.GetMaxAmount()) ? price.Price : product.Bids.GetMaxAmount();
                WriteLine($"Bidding for {product.Name} (regular price ${product.Price}), current highest bid is ${product.Bids.GetMaxAmount()}");
                decimal bidAmount = CustomCurrency();
                while (bidAmount < price) {
                    WriteLine($"Bid must be greater than {price}");
                }
                BiddingDetails bid = new BiddingDetails(Product.Client.Name, price);
            }
        }
    }
}
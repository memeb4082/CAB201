using Auction.Model;
using static System.Console;
using static Auction.CustomUI;

namespace Auction.View
{
    public class SearchDialog : Dialog
    {
        const string TITLE = "Search for Advertised Products";
        public SearchDialog(
            AuctionHouse auction
        ) : base(
            TITLE,
            auction
        )
        { }
        public override void Display()
        {
            string tableBuyable;
            CustomTitle($"Product Search for {Auction.AuthUser.Name}({Auction.AuthUser.Email})");
            List<ProductDetails> buyable = Auction.ViewBuyableProducts(out tableBuyable);
            WriteLine(tableBuyable);
            string bidYes;
            while (true)
            {
                bidYes = CustomString("Would you like to place a bid on any of these items").ToLower();
                if (bidYes == "yes" || bidYes == "no") { break; }
            }
            if (bidYes == "yes")
            {
                int productIndex = CustomInt($"Please enter a non-negative integer between 1 and {buyable.Count}", "Input must be a valid integer");
                while (productIndex < 1 || productIndex > buyable.Count)
                {
                    productIndex = CustomInt($"Please enter a non-negative integer between 1 and {buyable.Count}", "Input must be a valid integer");
                }
                WriteLine($"Bidding for {buyable[productIndex - 1].Name} (regular price ${buyable[productIndex - 1].Price}), current highest bid ${buyable[productIndex - 1].Bids.GetMaxAmount().ToString()}");
                WriteLine("How much do you bid?");
                decimal bidamt = CustomCurrency("How much do you bid?");
                while (bidamt < buyable[productIndex - 1].Price)
                {
                    WriteLine($"Amount must be greater than ${buyable[productIndex - 1].Price}");
                    bidamt = CustomCurrency("How much do you bid?");
                }
                Menu deliveryInstructions = new DeliveryMenu(Auction);
                deliveryInstructions.Display();
            }
        }
    }
}
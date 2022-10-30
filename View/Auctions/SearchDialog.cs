using Auction.Model;
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
            string searchPhrase = CustomString("Please supply a search phrase (ALL to see all products)");
            CustomTitle($"Product Search for {Auction.AuthUser.Name}({Auction.AuthUser.Email})");
            List<ProductDetails> buyable = Auction.ViewBuyableProducts(out tableBuyable, searchPhrase);
            WriteLine(tableBuyable);
            string bidYes;
            while (true)
            {
                bidYes = CustomString("Would you like to place a bid on any of these items").ToLower().Trim();
                if (bidYes == "yes" || bidYes == "no") { break; }
            }
            if (bidYes == "yes")
            {
                int productIndex = CustomInt($"Please enter a non-negative integer between 1 and {buyable.Count}", "Input must be a valid integer");
                while (productIndex < 1 || productIndex > buyable.Count)
                {
                    productIndex = CustomInt($"Please enter a non-negative integer between 1 and {buyable.Count}", "Input must be a valid integer");
                }
                ProductDetails selected = buyable[productIndex - 1];
                WriteLine($"Bidding for {selected.Name} (regular price ${selected.Price}), current highest bid ${selected.Bids.GetMaxAmount().ToString()}");
                decimal bidamt = CustomCurrency("How much do you bid?");
                while (bidamt < selected.Bids.GetMaxAmount())
                {
                    WriteLine($"Amount must be greater than ${selected.Bids.GetMaxAmount()}");
                    bidamt = CustomCurrency("How much do you bid?");
                }
                Menu deliveryInstructions = new DeliveryMenu(selected, bidamt);
                deliveryInstructions.Display();
                selected.Bids.BidItems.Last().BidderData = Auction.AuthUser;
                Auction.UpdateBids(selected);
             }
        }
    }
}
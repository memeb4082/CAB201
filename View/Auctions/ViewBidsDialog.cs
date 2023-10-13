using Auction.Model;
using static Auction.CustomUI;
namespace Auction.View
{
    public class ViewBidsDialog : Dialog
    {
        const string TITLE = "View Bids on My Products";
        public ViewBidsDialog(
            AuctionHouse auction
        ) : base(
            TITLE,
            auction
        )
        { }
        public override void Display()
        {
            string sellingTable;
            if (Auction.AuthUser.Sellable(out sellingTable).Count() == 0)
            {
                CustomTitle($"List Product Bids for {Auction.AuthUser.Name}({Auction.AuthUser.Email})");
                WriteLine("No bids were found.");
                new AuctionMenu(Auction).Display();
            }
            CustomTitle($"List Product Bids for {Auction.AuthUser.Name}({Auction.AuthUser.Email})");
            List<ProductDetails> selling = Auction.AuthUser.Sellable(out sellingTable);
            WriteLine(sellingTable);
            string sellYes;
            while (true)
            {
                sellYes = CustomString("Would you like to sell something? (yes or no)?").ToLower().Trim();
                if (sellYes == "yes" || sellYes == "no") { break; }
            }
            if (sellYes == "yes")
            {
                int productIndex = CustomInt($"Please enter an integer between 1 and {selling.Count}", "");
                while (productIndex < 1 || productIndex > selling.Count)
                {
                    productIndex = CustomInt($"Please enter an integer between 1 and {selling.Count}", "Input must be a valid integer");
                }
                ProductDetails productSold = selling[productIndex - 1];
                BiddingDetails finalBid = productSold.Bid;
                Auction.SellProduct(productSold);
                Console.WriteLine(Auction.AuthUser.Products.Products.Count());
                Auction.AuthUser.Products.Products.Remove(productSold);
                
                WriteLine($"You have sold {productSold.Name} to {finalBid.BidderData.Name} for {finalBid.BidAmount}");
            }
        }
    }
}
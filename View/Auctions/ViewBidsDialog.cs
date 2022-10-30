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
            CustomTitle($"List Product Bids for {Auction.AuthUser.Name}({Auction.AuthUser.Email})");
            List<ProductDetails> selling = Auction.AuthUser.Products.Sellable(out sellingTable);
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
                ProductDetails productSold = selling[productIndex-1];
                BiddingDetails finalBid = productSold.Bids.BidItems.Last();
                Auction.SellProduct(productSold);
                WriteLine($"You have sold {productSold.Name} to {finalBid.BidderData.Name} for {finalBid.BidAmount}");
            }
        }
    }
}
using Auction.Model;
using static Auction.CustomUI;
namespace Auction.View
{
    public class ViewPurchasedDialog : Dialog
    {
        const string TITLE = "View My Purchased Items";
        public ViewPurchasedDialog(
            AuctionHouse auction
        ) : base(
            TITLE,
            auction
        )
        { }
        public override void Display()
        {
            if (Auction.AuthUser.ProductsOwned.Count == 0)
            {
                CustomTitle($"Purchased items for {Auction.AuthUser.Name}({Auction.AuthUser.Email})");
                WriteLine("You have no purchased products at the moment.");
                new AuctionMenu(Auction).Display();
            }
            string output = "";
            for (int i = 0; i < Auction.AuthUser.ProductsOwned.Count; i++)
            {
                ProductDetails owned = Auction.AuthUser.ProductsOwned[i];
                output = $"{output}{i}\t {owned.Bid.BidderData.Email}\t {owned.Name}\t {owned.Description}\t ${owned.Bid.BidAmount}\t {owned.Bid.ToString()}\n";
            }
            WriteLine($"Item #\t Seller Email\t Product Name\t Description\t List Price\t Amt Paid\t Delivery Option");
            WriteLine(output);
        }
    }
}
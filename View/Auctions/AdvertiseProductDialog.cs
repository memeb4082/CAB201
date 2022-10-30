using Auction.Model;

using static Auction.CustomUI;
namespace Auction.View {
    public class AdvertiseDialog : Dialog {
        const string TITLE = "Advertise Product";
        public AdvertiseDialog(
            AuctionHouse auction
        ) : base(
            TITLE,
            auction
        ) {}
        public override void Display()
        {
            ProductDetails Product = new ProductDetails();
            Auction.AuthUser.NewProduct(Product);
        }
    }
}
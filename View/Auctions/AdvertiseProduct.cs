using Auction.Model;
using static Auction.View.CustomInput;
namespace Auction.View {
    public class AdvertiseProduct : Dialog {
        const string TITLE = "Advertise Product";
        public AdvertiseProduct(
            ProductStorage Products,
            ClientStorage Clients
        ) : base(
            TITLE,
            Products,
            Clients
        ) {}
        public override void Display()
        {
            CustomTitle($"Product list for {Products.Client.Name}({Products.Client.Email})");
            Products.NewProduct(new ProductDetails(Products.Client.Email));
        }
    }
}
using Auction.Model;
using static Auction.View.CustomInput;
namespace Auction.View {
    public class ViewProducts : Dialog {
        const string TITLE = "View My Product List";
        public ViewProducts(
            ProductStorage Products,
            ClientStorage Clients
        ) : base(
            TITLE,
            Products,
            Clients
        ) {}
        public override void Display() {
            CustomTitle($"Product list for {Products.Client.Name}({Products.Client.Email})");
            Console.WriteLine(Products.ToString());
        }
    }
}
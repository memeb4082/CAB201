using Auction.Model;

namespace Auction.View {
    public class SearchProducts : Dialog {
        const string TITLE = "Search for Advertised Products";
        public SearchProducts(
            ProductStorage Products,
            ClientStorage Clients
        ) : base(
            TITLE,
            Products,
            Clients
        ) {}
        public override void Display() {}
    } 
}
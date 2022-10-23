using static System.Console;
using Auction.Model;

namespace Auction.View {
    public class RegisterDialog : Dialog {
        public const string TITLE = "Register";
        public RegisterDialog(ProductStorage Products, ClientStorage Clients) : base(TITLE, Products, Clients) {
        }
        public override void Display()
        {
            Clients.Register();
        }
    }
}
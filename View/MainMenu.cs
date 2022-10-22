using static System.Console;
using Auction.Model;

namespace Auction.View {
    public class MainMenu : Menu {
        private const string TITLE = $"+{new string('-', 30)}+\n| Welcome to the Auction House |\n+{new string('-', 30)}+";
        private ProductStorage products;
        private ClientStorage clients;
        public MainMenu() : base()
    }
}
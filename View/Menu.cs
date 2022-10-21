using static System.Console;
using Auction.Model;

namespace Auction.View {
    public class Menu : Dialog {
        const string HEADING = $"Please select an option between 1 and {opt.Length}";
        // const string TITLE = $"+{new string('-',30)}+ \n| Welcome to the Auction House |\n+{new string('-',30)}+";
        const string PROMPT = "> ";
        private IDisplay[] opt;
        public Menu(string title,ProductStorage products, ClientStorage clients, params IDisplay[] options) : base(title, products, clients) {
            this.options = new IDisplay[options.Length];
        }
        public void Options() {
            WriteLine();
            WriteLine(TITLE);
            WriteLine(new string('-',Title.Length));
            foreach (var (option, index) in options) {
                WriteLine($"({index}) {option.Title}");
            }
            WriteLine();
            WriteLine(HEADING);
        }
    }
}
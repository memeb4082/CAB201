using static System.Console;
using static Auction.CustomUI;
using Auction.Model;

namespace Auction.View
{
    public class Menu : Dialog
    {
        public string Heading;
        private IDisplayable[] options;
        public Menu(
            string Title,
            AuctionHouse Auction,
            params IDisplayable[] options
        ) : base(
            Title,
            Auction
        )
        {
            this.options = options;
            this.Heading = $"Please enter an option between 1 and {options.Length}";
        }
        public Menu(
            string Title,
            ProductDetails Product,
            decimal BidAmt,
            params IDisplayable[] options
        ) : base(
            Title,
            Product,
            BidAmt
        )
        {
            this.options = options;
            this.Heading = $"Please enter an option between 1 and {options.Length}";
        }
        private void WriteOptions()
        {
            CustomTitle(Title);
            for (int i = 0; i < options.Length; i++)
            {
                WriteLine($"({i + 1}) {options[i].Title}");
            }
            WriteLine();
        }
        private int GetOption()
        {
            int index;
            index = CustomInt($"Please select an option between {1} and {options.Length}", $"Option must be between 1 and {options.Length}");
            while ((1 > index) || (options.Length < index))
            {
                index = CustomInt($"Please select an option between {1} and {options.Length}", $"Option must be between 1 and {options.Length}");
            }
            return index - 1;
        }
        public override void Display()
        {
            while (true)
            {
                WriteOptions();
                options[GetOption()].Display();
            }
        }
    }
}
using static System.Console;
using Auction.Model;

namespace Auction.View
{
    public class Menu : Dialog
    {
        public string Heading;
        private IDisplayable[] options;
        public Menu(
            string Title,
            ProductStorage Products,
            ClientStorage Clients,
            params IDisplayable[] options
        ) : base(
            Title, 
            Products, 
            Clients
        )
        {
            this.options = options;
            this.Heading = $"Please enter an option between 1 and {options.Length}";
        }
        private void WriteOptions()
        {
            CustomInput.CustomTitle(Title);
            for (int i = 0; i < options.Length; i++)
            {
                WriteLine($"({i + 1}) {options[i].Title}");
            }
            WriteLine();
        }
        private int GetOption()
        {
            int index;
            index = CustomInput.CustomInt($"Please select an option between {1} and {options.Length}", $"Option must be between 1 and {options.Length + 1}");
            while ((1 > index) || (options.Length < index))
            {
                index = CustomInput.CustomInt($"Please select an option between {1} and {options.Length}", $"Option must be between 1 and {options.Length + 1}");
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
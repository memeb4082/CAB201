using System.Text.RegularExpressions;
using static System.Console;
using System.Globalization;
namespace Auction.View
{
    public class CustomInput
    {
        public static string CustomPassword()
        {
            string password;
            // Regex to validate password with 8 characters, with minimum 1 UPPERCASE, 1 lowercase, 1 d1g1t and 1 $pec!al character
            Regex re = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[$&+,:;=?@#|'<>.-^*()%!]).{8,}$");
            // While loop iterates till valid input is given
            while (true)
            {
                WriteLine(@"Please choose a password
* At least 8 characters
* No white space characters
* At least one upper-case letter
* At least one lower-case letter
* At least one digit
* At least one special character");
                password = ReadLine();
                MatchCollection match = re.Matches(password);
                if (match.Count == 0)
                {
                    WriteLine("BADDDDDDDD Password must be 8 characters long, contain at least 1 uppercase, lowercase, special character and number");
                }
                else
                {
                    // Return breaks while loop
                    return password;
                }
            }
        }
        public static string CustomString(string? prompt = null, string reg = "")
        {
            string input;
            Regex re = new Regex(reg);
            while (true)
            {
                if (prompt != null)
                {
                    WriteLine(prompt);
                }
                input = ReadLine();
                MatchCollection match = re.Matches(input);
                if (match.Count == 0)
                {
                    WriteLine("Invalid input, please try again");
                }
                else
                {
                    return input;
                }
            }
        }
        public static int CustomInt(string prompt, string error)
        {
            string input;
            int output;
            while (true)
            {
                WriteLine(prompt);
                input = ReadLine();
                if (!int.TryParse(input, out output))
                {
                    WriteLine(error);
                    continue;
                }
                return output;
            }
        }
        public static string CustomOption(string prompt, List<string> options)
        {
            string input;
            List<string> options_lower = (from i in options select i.ToLower()).ToList();
            while (true)
            {
                WriteLine(prompt);
                input = ReadLine();
                int i = options_lower.IndexOf(input.ToLower());
                if (i == -1)
                {
                    WriteLine($"Please select an option from the following: {string.Join(",", options)}");
                    continue;
                }
                return options[i];

            }
        }
        public static int CustomOption(string prompt, List<int> options)
        {
            int input;
            while (true)
            {
                WriteLine(prompt);
                if (!int.TryParse(ReadLine(), out input))
                {
                    WriteLine("Input is not a valid integer");
                    continue;
                }
                if (options.IndexOf(input) == -1)
                {
                    WriteLine($"Please select an option from the following: {string.Join(",", options)}");
                    continue;
                }
                return input;
            }
        }
        public static decimal CustomCurrency(string prompt)
        {
            string input;
            decimal output;
            // Regex consisiting of capture groups for currency symbol, amount, and decimals (limited to 2 and only two)
            Regex re = new Regex("([$]){1}\\s*([\\d.,]{0,}\\.[\\d.,]{2}\\b)");
            while (true)
            {
                WriteLine(prompt);
                input = ReadLine();

                Match match = re.Match(input);
                if (match.Success)
                {
                    // First group matches $ sign, skip to value to be parsed
                    Decimal.TryParse(match.Groups[2].Value, out output);
                    return output;
                }
            }
        }
        public static DateTime CustomDateTime(string prompt)
        {

            string[] dateFormat = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
            "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
            "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
            "M/d/yyyy h:mm", "M/d/yyyy h:mm",
            "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm"};
            while (true)
            {
                DateTime output;
                string input;
                WriteLine(prompt);
                input = ReadLine();
                if (DateTime.TryParseExact(input,
                        dateFormat,
                        CultureInfo.CurrentCulture,
                        DateTimeStyles.None,
                        out output))
                {
                    return output;
                }
            }
        }
    }
}
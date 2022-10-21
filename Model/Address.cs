using static System.Console;
using Auction.View;
namespace Auction.Model
{
    public class Address
    {
        // Set static readonly values for variables that aren't updated/are constant
        public static readonly List<string> streetSuffixesList = new List<string> { "Av", "Cct", "Cr", "Ct", "Dr", "Esp", "Gr", "Hts", "Hwy", "Pde", "Pl", "Rd", "St", "Tce" };
        public static readonly List<string> statesList = new List<string> { "QLD", "NSW", "ACT", "SA", "WA", "NT", "ACT", "TAS" };
        // Nullable for optional var
        private int? unitNum;
        private int streetNum;
        private string streetName;
        private string streetSuffix;
        private string city;
        private int postCode;
        private string state;

        public int? UnitNum
        {
            get { return unitNum; }
            set
            {
                if (value == 0)
                {
                    unitNum = null;
                }
                else if (value > 0)
                {
                    unitNum = value;
                }
                else
                {
                    WriteLine("Unit number must be greater than or equal to 0");
                }
            }
        }
        public int StreetNum
        {
            get { return streetNum; }
            set
            {
                if (value > 0)
                {
                    streetNum = value;
                }
                else
                {
                    Console.WriteLine("Street number must be greater than zero");
                }
            }
        }
        public string StreetName
        {
            get { return streetName; }
            set
            {
                if (value.Length > 0)
                {
                    streetName = value;
                }
                else
                {
                    Console.WriteLine("Street name cannot be empty");
                }
            }
        }
        public string StreetSuffix
        {
            get { return streetSuffix; }
            set
            {
                if (streetSuffixesList.Contains(value, StringComparer.OrdinalIgnoreCase))
                {
                    streetSuffix = value;
                }
                else
                {
                    Console.WriteLine($"Street suffix must be one of {streetSuffixesList.ToString()} (non case-sensitive)");
                }
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                if (value.Length > 0)
                {
                    city = value;
                }
                else
                {
                    Console.WriteLine("City name cannot be empty");
                }
            }
        }
        public int PostCode
        {
            get { return postCode; }
            set
            {
                if (1000 <= value && value <= 9999)
                {
                    postCode = value;
                }
                else
                {
                    Console.WriteLine("Postcode must be a 4 digit integer");
                }
            }
        }
        public string State
        {
            get { return state; }
            set
            {
                if (statesList.Contains(value, StringComparer.OrdinalIgnoreCase))
                {
                    state = value.ToUpper();
                }
                else
                {
                    Console.WriteLine($"State must be one of {statesList.ToString()} (non case-sensitive)");
                }
            }
        }
        // Overloads built-in ToString function to return AusPost standard string
        public override string ToString()
        {
            return $"{(unitNum == null ? $"{streetNum}" : $"{unitNum}/{streetNum}")} {streetName} {streetSuffix}, {city} {postCode} {state}";
        }
        internal Address(int unitNum, int streetNum, string streetName, string streetSuffix, string city, int postCode, string state)
        {
            this.unitNum = unitNum;
            this.streetNum = streetNum;
            this.streetName = streetName;
            this.streetSuffix = streetSuffix;
            this.city = city;
            this.postCode = postCode;
            this.state = state;
        }
        public Address()
        {
            this.unitNum = CustomInput.CustomInt("Unit number (0 = none):", 0, null, true);
            this.streetNum = (int)CustomInput.CustomInt("Street number:", 0, null);
            this.streetName = CustomInput.CustomString("Street name", "^(?!\\s*$).+");
            this.streetSuffix = CustomInput.CustomString($"Street suffix:)", "");
            this.city = CustomInput.CustomString("City:", "^(?!\\s*$).+");
            this.state = CustomInput.CustomOption($"State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):", statesList); ;
            this.postCode = (int)CustomInput.CustomInt("Postcode (1000 .. 9999)", 1000, 9999);
        }

        // public address()
        // {
        //     this.unitNum = 5;
        //     this.streetNum = 5;
        //     this.streetName = "Texas";
        //     this.streetSuffix = "Terrace";
        //     this.city = "Sophia Antipolis";
        //     this.state = "Nt";
        //     this.postCode = 1177;
        // }
    }
}
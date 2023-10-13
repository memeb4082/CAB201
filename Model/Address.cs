using static Auction.CustomUI;
using System.Xml.Linq;
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
        // <summary>unit number is nullable int to allow for addressses without unit num</summary>
        // <summary>sets value to negative if failed as null is legal input </summary>
        public int? UnitNum
        {
            get { return unitNum; }
            private set
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
                    unitNum = -1;
                    WriteLine("Unit number must be a non-negative integer");
                }
            }
        }
        // <summary>private set method only accepts non zero positive integer for street number</summary>
        public int StreetNum
        {
            get { return streetNum; }
            private set
            {
                if (value > 0)
                {
                    streetNum = value;
                }
                else if (value < 0)
                {
                    Console.WriteLine("Street number must a positive integer");
                }
                else
                {
                    streetNum = -1;
                    Console.WriteLine("Street number must be greater than zero");
                }
            }
        }
        // <summary></summary>
        public string StreetName
        {
            get { return streetName; }
            private set
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
            private set
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
            private set
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
            private set
            {
                if (1000 <= value && value <= 9999)
                {
                    postCode = value;
                }
                else
                {
                    postCode = -1;
                    Console.WriteLine("Postcode must be a 4 digit integer");
                }
            }
        }
        public string State
        {
            get { return state; }
            private set
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
        public XElement ToXElement()
        {
            
            XElement output = new XElement("Address",
                new XElement("UnitNo", unitNum),
                new XElement("StreetName", streetName),
                new XElement("StreetNo", streetNum),
                new XElement("StreetSuffix", streetSuffix),
                new XElement("City", city),
                new XElement("PostCode", postCode),
                new XElement("State", state)
            );
            return output;
        }
        internal Address(XElement? addressData)
        {
            this.unitNum = int.Parse(addressData.Element("UnitNo").Value);
            this.streetNum = int.Parse(addressData.Element("StreetNo").Value);
            this.streetName = addressData.Element("StreetName").Value;
            this.streetSuffix = addressData.Element("StreetSuffix").Value;
            this.city = addressData.Element("City").Value;
            this.postCode = int.Parse(addressData.Element("PostCode").Value);
            this.state = addressData.Element("State").Value;
        }
        public Address()
        {
            this.unitNum = CustomInt("Unit number (0 = none):", "\tUnit number must be a non-negative integer");
            while (UnitNum == -1)
            {
                this.UnitNum = CustomInt("Unit number (0 = none):", "\tUnit number must be a non-negative integer");
            }
            this.streetNum = CustomInt("Street number:", "\tStreet number must be a positive integer");
            while (StreetNum == -1)
            {
                this.StreetNum = CustomInt("Street number:", "\tStreet number must be a positive integer");
            }

            streetName = CustomString("Street name", "^(?!\\s*$).+");
            streetSuffix = CustomString($"Street suffix:)", "");
            city = CustomString("City:", "^(?!\\s*$).+");
            state = CustomOption($"State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):", statesList);
            this.PostCode = CustomInt("Postcode (1000 .. 9999)", "Postcode must be between 1000 and 9999");
            while (PostCode == -1)
            {
                this.PostCode = CustomInt("Postcode (1000 .. 9999)", "Postcode must be between 1000 and 9999");
            }
        }
    }
}
using static Auction.CustomUI;
using System.Xml.Linq;
namespace Auction.Model
{
    public class ProductDetails
    {
        private int productIndex;
        private string name;
        private string description;
        private decimal price;
        private BiddingStorage bids;
        public int ProductIndex
        {
            get { return productIndex; }
            internal set
            {
                productIndex = value;
            }
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    WriteLine("Product name cannot be empty");
                    name = default;
                }
            }
        }
        public string Description
        {
            get { return description; }
            private set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    description = value;
                }
                else
                {
                    WriteLine("Produt description cannot be empty");
                    description = null;
                }
            }
        }
        public decimal Price
        {
            get { return price; }
            private set
            {
                if (value <= 0)
                {
                    WriteLine("Initial value must be greater than 0");
                    price = 0.0M;
                }
                else
                {
                    price = value;
                }
            }
        }
        public BiddingStorage Bids
        {
            get { return bids; }
            internal set
            {
                bids = value;
            }
        }
        public override string ToString()
        {
            return $"{(name)}\t {description}\t ${price}\t {((Bids.BidItems.Count > 1) ? bids.BidItems[bids.BidItems.Count - 1].ToString() : "-\t -\t -")}";
        }
        internal bool Search(string phrase)
        {
            phrase = phrase.ToLower();
            string searchDescription = description.ToLower();
            string searchName = name.ToLower();
            if (searchDescription.Contains(phrase) || searchName.Contains(phrase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public ProductDetails()
        {
            this.name = CustomString("Product name");
            this.description = CustomString("Product description");
            this.price = CustomCurrency("Product price $d.cc");
            this.bids = new BiddingStorage();
        }
        internal ProductDetails(XElement productData)
        {
            this.name = productData.Element("Name").Value;
            this.description = productData.Element("Description").Value;
            this.price = Convert.ToDecimal(productData.Element("Price").Value);
            this.productIndex = int.Parse(productData.Attribute("ID").Value);
            this.bids = new BiddingStorage();
        }
    }

}
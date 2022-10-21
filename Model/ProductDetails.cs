using static System.Console;
using Auction.View;
namespace Auction.Model
{
    public class ProductDetails
    {
        private string name;
        private string description;
        private decimal price;
        private string sellerEmail;
        private BiddingStorage bids;
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
                    name = null;
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
        public string SellerEmail
        {
            get { return sellerEmail; }
            set { sellerEmail = value; }
        }
        public BiddingStorage Bids
        {
            get { return bids; }
            private set
            {
                bids = value;
            }
        }
        public override string ToString()
        {
            return $"{name}\t {description}\t {price}\n";
        }
        internal bool Search(string phrase) {
            phrase = phrase.ToLower();
            string searchDescription = description.ToLower();
            string searchName = name.ToLower();
            if (searchDescription.Contains(phrase) || searchName.Contains(phrase)) {
                return true;
            } else {
                return false;
            }
        }
        public ProductDetails(string email)
        {
            this.name = CustomInput.CustomString("Product name");
            this.description = CustomInput.CustomString("Product description");
            this.price = CustomInput.CustomCurrency("Product price $d.cc");
            this.sellerEmail = email;
            this.bids = new BiddingStorage();
        }
        internal ProductDetails(string name, string description, decimal price, string sellerEmail)
        {
            this.name = name;
            this.description = description;
            this.price = price;
            this.sellerEmail = sellerEmail;
            this.bids = new BiddingStorage();
        }
    }

}
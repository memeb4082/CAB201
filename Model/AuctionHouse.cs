using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static Auction.CustomUI;
namespace Auction.Model
{
    public class AuctionHouse
    {
        List<Client> clients = new List<Client>();
        private Client authUser;
        private string fileName;
        public Client AuthUser
        {
            get
            {
                return authUser;
            }
            set
            {
                authUser = value;
            }
        }
        public AuctionHouse(string fileName)
        {
            this.fileName = fileName;
            Load();
        }
        public Client? GetAccountMatching(string email)
        {
            foreach (Client client in clients)
            {
                if (email == client.Email)
                {
                    return client;
                }
            }
            return null;
        }
        public void Load()
        {
            clients = new List<Client>();
            if (!File.Exists(fileName))
            {
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XElement("Clients")
                )
                .Save(fileName);
            }
            XDocument doc = XDocument.Load(fileName);
            if (!doc.Descendants("Clients").Any())
            {
                doc.Add(new XElement("Clients"));
            }
            IEnumerable<XElement> list = doc.Descendants("Clients").Elements();
            foreach (XElement el in list)
            {
                LoadData(el);
            }

        }
        public void LoadData(XElement data)
        {

            Client client = new Client(data);
            if (data.Descendants("Address").Any())
            {
                Address address = new Address(data.Element("Address"));
                client.HomeAddress = address;
            }
            if (data.Descendants("Products").Any())
            {
                List<ProductDetails> productsList = new List<ProductDetails>();
                IEnumerable<XElement> productsData = data.Element("Products").Elements();
                foreach (XElement productData in productsData)
                {
                    ProductDetails product = new ProductDetails(productData);
                    if (productData.Descendants("Bids").Any())
                    {
                        BiddingStorage bidStore = new BiddingStorage();
                        IEnumerable<XElement> bidsData = productData.Element("Bids").Elements();
                        foreach (XElement bidData in bidsData)
                        {
                            BiddingDetails bid;
                            if (bidData.Element("Address") == null)
                            {
                                bid = new ClickandCollect(
                                    DateTime.Parse(bidData.Element("StartTime").Value),
                                    DateTime.Parse(bidData.Element("EndTime").Value),
                                    Decimal.Parse(bidData.Element("BidAmount").Value)
                                );
                            }
                            else
                            {
                                bid = new DeliverProduct(
                                    new Address(bidData.Element("Address")),
                                    Decimal.Parse(bidData.Element("BidAmount").Value)
                                );
                            }
                            bid.BidderData = new Client(
                                bidData.Element("Client").Element("Name").Value,
                                bidData.Element("Client").Attribute("Email").Value);
                            bidStore.Add(bid);
                        }
                        product.Bids = bidStore;
                    }
                    productsList.Add(product);
                }
                ProductStorage products = new ProductStorage(productsList);
                client.Products = products;
            }
            if (data.Descendants("Purchased").Any())
            {
                
            }
            clients.Add(client);
        }

        public void Register()
        {
            // TODO: Check video for prompts
            // TODO: Update email regex
            // TODO: Implement if check for duplicate email necessary
            Client client = new Client();
            clients.Add(client);
            if (File.Exists(fileName))
            {
                XDocument doc = XDocument.Load(fileName);
                doc.Element("Clients").Add(
                    client.ToXElement()
                    );
                doc.Save(fileName);
            }
            Load();
            CustomTitle($"Client {client.Name}({client.Email}) has successfully registered at the Auction house.");
        }
        public Client Login()
        {
            // TODO: Check video for prompts
            bool emailVerified = false;
            bool passwordVerified = false;
            string email;
            string password;
            Client loginTarget = default;
            while (emailVerified == false)
            {
                email = CustomString("Please enter email:");
                if (GetAccountMatching(email) != null)
                {
                    emailVerified = true;
                    loginTarget = GetAccountMatching(email);
                }
                if (!emailVerified) { WriteLine("Email not found, please try again"); }
            }
            while (passwordVerified == false)
            {
                password = CustomString("Please enter password:");
                if (string.Equals(password, loginTarget.Password))
                {
                    passwordVerified = true;
                    break;
                }
                else { WriteLine("Password incorrect, please try again"); }
            }
            if (loginTarget.HomeAddress == null)
            {
                Address address = new Address();
                loginTarget.HomeAddress = address;
                XDocument doc = XDocument.Load(fileName);
                XElement account = doc
                    .Descendants("Client")
                    .Where(arg => arg.Attribute("Email").Value == loginTarget.Email)
                    .FirstOrDefault();
                account.Add(address.ToXElement());
                doc.Save(fileName);
            }
            this.authUser = loginTarget;
            return loginTarget;
        }
        public ProductStorage ViewMyProducts()
        {
            // output = null;
            List<ProductDetails> list = new List<ProductDetails>();
            foreach (Client client in clients)
            {
                if (client == authUser)
                {
                    // output = client.Products.ToString();
                    list = client.Products.Products;
                }
            }
            return new ProductStorage(list);
        }
        public List<ProductDetails> ViewBuyableProducts(out string output, string searchPhrase)
        {
            output = null;
            List<ProductDetails> list = new List<ProductDetails>();
            foreach (Client client in clients)
            {
                if (client == authUser) { }
                else
                {
                    foreach (ProductDetails product in client.Products.Products)
                    {
                        if (product.Search(searchPhrase) || searchPhrase == "ALL")
                        {
                            list.Add(product);
                        }
                    }
                }

            }
            list = list.OrderBy(p => p.Name).ToList();
            output = new ProductStorage(list).ToString();
            return list;
        }
        public void UpdateBids(ProductDetails productUpdated)
        {
            XDocument doc = XDocument.Load(fileName);
            XElement bids = doc.Descendants("Client")
                .Descendants("Product")
                .Where(arrg => arrg.Attribute("ID").Value == productUpdated.ProductIndex.ToString())
                .Descendants("Bids")
                .FirstOrDefault();
            bids.Add(productUpdated.Bids.BidItems.Last().ToXElement());
            doc.Save(fileName);
        }
        public void SellProduct(ProductDetails productSelling)
        {
            bool isClickCollect = productSelling.Bids.BidItems.Last().GetType().ToString() == "Auction.Model.ClickandCollect";
            XDocument doc = XDocument.Load("data.xml");
            IEnumerable<XElement> bids = doc.Descendants("Client")
                .Descendants("Product")
                .Where(arrg => arrg.Attribute("ID").Value == productSelling.ProductIndex.ToString());
            XElement finalBid = bids
                .Descendants((isClickCollect) ? "ClickAndCollect" : "Delivery")
                .LastOrDefault();
            // bids.Remove();
            doc
                .Descendants("Client")
                .Where(arg => arg.Attribute("Email").Value == finalBid.Element("Client").Attribute("Email").Value)
                .FirstOrDefault()
                .Element("Purchased")
                .Add(finalBid)
            doc.Save(fileName);

        }
    }
}
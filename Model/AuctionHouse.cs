using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Linq;
using System.Xml.Linq;
// using Auction.View;
namespace Auction.Model
{
    public class AuctionHouse
    {
        List<Client> clients = new List<Client>();

        private string fileName;
        public AuctionHouse(string fileName)
        {
            this.fileName = fileName;
            Load();
        }
        public void Load()
        {
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
            string name = data.Element("Name").Value;
            string email = data.Attribute("Email").Value;
            string password = data.Element("Password").Value;
            Client client = new Client(name, email, password);
            if (data.Descendants("Address").Any())
            {
                XElement addressData = data.Element("Address");
                Address address = new Address(
                    int.Parse(addressData.Element("UnitNo").Value),
                    int.Parse(addressData.Element("StreetNo").Value),
                    addressData.Element("StreetName").Value,
                    addressData.Element("StreetSuffix").Value,
                    addressData.Element("City").Value,
                    int.Parse(addressData.Element("PostCode").Value),
                    addressData.Element("State").Value
                );
                client.HomeAddress = address;
            }
            if (data.Descendants("Products").Any())
            {
                List<ProductDetails> productsList = new List<ProductDetails>();
                IEnumerable<XElement> productsData = data.Element("Products").Elements();
                foreach (XElement productData in productsData)
                {
                    ProductDetails product = new ProductDetails(
                        productData.Element("Name").Value,
                        productData.Element("Description").Value,
                        Convert.ToDecimal(productData.Element("Price").Value)
                    );
                    productsList.Add(product);
                }
                ProductStorage products = new ProductStorage(productsList);
                client.Products = products;
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
                    new XElement("Client", new XAttribute("Email", client.Email),
                        new XElement("Name", client.Name),
                        new XElement("Password", client.Password),
                        new XElement("Products", "")
                    )
                );
                doc.Save(fileName);
            }
            CustomInput.CustomTitle($"Client {client.Name}({client.Email}) has successfully registered at the Auction house.");

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
                email = CustomInput.CustomString("Please enter email:");
                foreach (Client client in clients)
                {
                    if (string.Equals(email, client.Email))
                    {
                        emailVerified = true;
                        loginTarget = client;
                        break;
                    }
                }
                if (!emailVerified) { WriteLine("Email not found, please try again"); }
            }
            while (passwordVerified == false)
            {
                password = CustomInput.CustomString("Please enter password:");
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
                account.Add(new XElement("Address",
                       new XElement("UnitNo", address.UnitNum),
                       new XElement("StreetName", address.StreetName),
                       new XElement("StreetNo", address.StreetNum),
                       new XElement("StreetSuffix", address.StreetSuffix),
                       new XElement("City", address.City),
                       new XElement("PostCode", address.PostCode),
                       new XElement("State", address.State)
                   ));
                doc.Save(fileName);
            }
            return loginTarget;
        }
        public void GetDeliveryOpt(XElement data, decimal bidAmount)
        {
            // TODO: Finish up code
        }
        public void BidOnProduct(string productName, Client client, decimal bidAmount)
        {
            XDocument doc = XDocument.Load(fileName);
            XElement bids = doc
                .Descendants("Client")
                .Where(arg => arg.Attribute("Email").Value == client.Email)
                .Descendants("Product")
                .Where(arrg => arrg.Element("Name").Value == "dfggsdfg")
                .Descendants("Bids")
                .FirstOrDefault();
            if (bids == null)
            {
                WriteLine("Product not found please try again");
            }
            else
            {
                // TODO: Finish up code
            }
        }
    }
}
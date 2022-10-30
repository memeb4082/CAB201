using System;
using System.Collections.Generic;

using static Auction.CustomUI;
using System.IO;
using System.Linq;
using System.Xml.Linq;
// using Auction.View;
namespace Auction.Model
{
    public class Client
    {
        // Fields
        private string name;
        private string email;
        private string password;
        private ProductStorage products;
        private Address homeAddress;
        private List<ProductDetails> productsOwned;
        // Params
        public string Name
        {
            get { return name; }
        }
        public Address HomeAddress
        {
            get
            {
                return homeAddress;
            }
            internal set
            {
                homeAddress = value;
            }
        }
        public string Email
        {
            get { return email.ToString(); }
        }
        public string Password
        {
            get { return password; }
        }
        public ProductStorage Products
        {
            get { return products; }
            set { products = value; }
        }
        public List<ProductDetails> ProductsOwned{
            get { return productsOwned; }
            set { productsOwned = value; }
        }
        internal XElement ToXElementBidding()
        {
            return new XElement(new XElement("Client", new XAttribute("Email", email),
                       new XElement("Name", name)));
        }
        internal XElement ToXElement()
        {
            return new XElement(new XElement("Client", new XAttribute("Email", email),
                        new XElement("Name", name),
                        new XElement("Password", password),
                        new XElement("Products", ""),
                        new XElement("Purchased", "")));
        }
        public void NewProduct(ProductDetails product)
        {
            XDocument doc = XDocument.Load("data.xml");
            XElement account = doc.Descendants("Client")
                .Where(arg => arg.Attribute("Email").Value == email)
                .FirstOrDefault();
            int currID = doc.Descendants("Client")
                .Descendants("Products")
                .Descendants("Product")
                .Count();
            product.ProductIndex = currID + 1;
            products.Add(product);
            account.Element("Products").Add(new XElement("Product",
                new XAttribute("ID", currID + 1),
                new XElement("Name", product.Name),
                new XElement("Description", product.Description),
                new XElement("Price", product.Price),
                new XElement("Bids", "")
            ));
            doc.Save("data.xml");
        }
        public Client()
        {
            this.name = CustomString("Please enter username (must not be empty)", @"^(?!\s*$).+");
            this.email = CustomString("Please enter email", @"^[A-Za-z0-9-_]+([\.]?[A-Za-z0-9-_]+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
            this.password = CustomPassword();
        }
        internal Client(string name, string email) {
            this.name = name;
            this.email = email;
        }
        internal Client(XElement data)
        {
            this.name = data.Element("Name").Value;
            this.email = data.Attribute("Email").Value;
            this.password = data.Element("Password").Value;
        }
    }
}

using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Auction.View;
namespace Auction.Model
{
    public class ProductStorage
    {
        List<ProductDetails> products = new List<ProductDetails>();
        private string fileName;
        public override string ToString()
        {
            string output = "Item #\t Product Name\t Description\t List Price\t Bidder name\n Bidder Email\t Bid amt\n";
            for (int i = 0; i < products.Count; i++)
            {
                // TODO: Add more vars
                output += $"{i + 1}\t {products[i].ToString()}\n";
            }
            return output;
        }
        public ProductStorage(string fileName)
        {
            this.fileName = fileName;
            Load();
        }

        private void Load()
        {
            if (!File.Exists(fileName))
            {
                new XDocument(
                    new XElement("Products")
                )
                .Save(fileName);
            }
            XDocument doc = XDocument.Load(fileName);
            if (!doc.Descendants("Products").Any())
            {
                doc.Add(new XElement("Products"));
            }
            IEnumerable<XElement> list = doc.Descendants("Products").Elements();
            foreach (XElement el in list)
            {
                LoadData(el);
            }
        }
        private void LoadData(XElement data)
        {
            string name = data.Element("Name").Value;
            string description = data.Element("Description").Value;
            decimal price = decimal.Parse(data.Element("Price").Value);
            string sellerEmail = data.Element("Email").Value;
            ProductDetails product = new ProductDetails(name, description, price, sellerEmail);
            products.Add(product);
        }
        public void NewProduct(ProductDetails product)
        {
            products.Add(product);
            XDocument doc = XDocument.Load(fileName);
            doc.Element("Products").Add(
                new XElement("Product", new XAttribute("ID", products.Count),
                    new XElement("Email", product.SellerEmail),
                    new XElement("Name", product.Name),
                    new XElement("Description", product.Description),
                    new XElement("Price", product.Price),
                    new XElement("Bids", "")
                )
            );
            doc.Save(fileName);
        }
        public List<ProductDetails> ShowProducts(string sellerEmail)
        {
            List<ProductDetails> output = new List<ProductDetails>();
            foreach (ProductDetails product in products)
            {
                if (product.SellerEmail == sellerEmail)
                {
                    output.Add(product);
                }
            }
            return output;
        }
        public List<ProductDetails> SearchProducts(string sellerEmail, string searchPhrase)
        {
            List<ProductDetails> output = new List<ProductDetails>();
            foreach (ProductDetails product in products)
            {
                if (!product.Search(searchPhrase) || searchPhrase == "ALL")
                {
                    output.Add(product);
                }
                else { }
            }
            return output;
        }
    }
}
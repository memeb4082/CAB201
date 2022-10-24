using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Linq;
using System.Xml.Linq;
// using Auction.View;
namespace Auction.Model
{
    public class ProductStorage
    {
        private List<ProductDetails> products = new List<ProductDetails>();
        public List<ProductDetails> Products
        {
            get
            {
                return products;
            }
            private set
            {
                products = value;
            }
        }
        public override string ToString()
        {
            string output = "Item #\t Product name\t Description\t List Price\t Bidder name\t Bidder email\t Bid amt\n";
            for (int i = 0; i < products.Count; i++)
            {
                output += $"{i + 1}\t {products[i].ToString()}\n";
            }
            return output;
        }
        public List<ProductDetails> SearchProducts(string searchPhrase)
        {
            List<ProductDetails> output = new List<ProductDetails>();
            foreach (ProductDetails product in products)
            {
                if (searchPhrase == "ALL")
                {
                    output.Add(product);
                }
                else if (product.Search(searchPhrase))
                {
                    output.Add(product);
                }
            }
            return output;
        }
        public ProductStorage()
        {
            this.products = new List<ProductDetails>();
        }
        public ProductStorage(List<ProductDetails> products)
        {
            this.products = products;
        }
        public void Add(ProductDetails product)
        {
            products.Add(product);
        }
    }
}
// public class ProductStorage : Storage
// {
//     public Client client;
//     List<ProductDetails> products = new List<ProductDetails>();
//     private string fileName;
//     public Client Client
//     {
//         get { return client; }
//         set { client = value; }
//     }
//     public ProductStorage(string fileName)
//     {
//         this.fileName = fileName;
//         Load();
//     }
//     public void NewProduct(ProductDetails product)
//     {
//         products.Add(product);
//         XDocument doc = XDocument.Load(fileName);
//         doc.Element("Products").Add(
//             new XElement("Product", new XAttribute("ID", products.Count),
//                 new XElement("Email", product.SellerEmail),
//                 new XElement("Name", product.Name),
//                 new XElement("Description", product.Description),
//                 new XElement("Price", product.Price),
//                 new XElement("Bids", "")
//             )
//         );
//         doc.Save(fileName);
//     }
//     public List<ProductDetails> ShowProducts(string sellerEmail)
//     {
//         List<ProductDetails> output = new List<ProductDetails>();
//         foreach (ProductDetails product in products)
//         {
//             if (product.SellerEmail == sellerEmail)
//             {
//                 output.Add(product);
//             }
//         }
//         return output;
//     }
// public void BidonProduct(ProductDetails product)
// {
//     decimal price = (product.Price > product.Bids.GetMaxAmount()) ? product.Price : product.Bids.GetMaxAmount();
//     WriteLine($"Bidding for {product.Name} (regular price ${product.Price}), current highest bid is ${product.Bids.GetMaxAmount()}");
//     decimal bidAmount = CustomCurrency();
//     while (bidAmount < price)
//     {
//         WriteLine($"Bid must be greater than {price}");
//         bidAmount = CustomCurrency();
//     }
// }
// public bool IsDelivery() 
// {
//     return false;
// }
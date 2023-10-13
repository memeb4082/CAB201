using System;
using System.Collections.Generic;

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
       
        public ProductStorage(List<ProductDetails> products)
        {
            this.products = products;
        }
    }
}
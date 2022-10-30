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
        public List<ProductDetails> Sellable(out string table)
        {
            List<ProductDetails> sellable = new List<ProductDetails>();
            foreach (ProductDetails product in products)
            {
                if (product.Bids.BidItems.Count > 0) {
                    sellable.Add(product);
                }
            }
            sellable = sellable.OrderBy(p => p.Name).ToList();
            table = new ProductStorage(sellable).ToString();
            return sellable;
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
        public int ItemCount()
        {
            return products.Count;
        }
    }
}
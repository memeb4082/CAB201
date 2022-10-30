// using System;
// using System.Xml.Linq;
// using System.Collections.Generic;
// namespace Auction.Model
// {
//     public class BiddingStorage
//     {
//         private List<BiddingDetails> bidItems = new List<BiddingDetails>();
//         public List<BiddingDetails> BidItems
//         {
//             get
//             {
//                 return bidItems;
//             }
//             private set
//             {
//                 bidItems = value;
//             }
//         }
//         public override string ToString()
//         {
//             string output = "";
//             foreach (BiddingDetails bid in bidItems)
//             {
//                 output = $"{output}\n {bid.ToString()}";
//             }
//             return output;
//         }
//         public string GetMax()
//         {
//             if (bidItems.Count > 1)
//             {
//                 string amount = bidItems[bidItems.Count - 1].ToString();
//                 return amount;
//             }
//             else
//             {
//                 return $"\t-\t -\t -";
//             }
//         }
//         public decimal GetMaxAmount()
//         {
//             try
//             {
//                 decimal amount = bidItems[bidItems.Count - 1].BidAmount;
//                 return amount;
//             }
//             catch (ArgumentOutOfRangeException)
//             {
//                 return 0.0M;
//             }
//         }
//         public List<XElement> ToXElement()
//         {
//             List<XElement> bidXElems = new List<XElement>();
//             foreach (BiddingDetails bidItem in bidItems)
//             {
//                 bidXElems.Add(bidItem.ToXElement());
//             }
//             return bidXElems;
//         }
//         public void Add(BiddingDetails bid)
//         {
//             bidItems.Add(bid);
//         }
//         public BiddingStorage()
//         {
//             this.bidItems = new List<BiddingDetails>();
//         }
//     }
// }

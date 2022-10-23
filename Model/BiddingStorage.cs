using System;
using System.Collections.Generic;
using Auction.View;
namespace Auction.Model
{
    public class BiddingStorage
    {
        private List<BiddingDetails> bidItems = new List<BiddingDetails>();
        public List<BiddingDetails> BidItems
        {
            get
            {
                return bidItems;
            }
            private set
            {
                bidItems = value;
            }
        }
        public string GetMax()
        {
            try
            {
                string amount = bidItems[bidItems.Count - 1].ToString();
                return amount;
            }
            catch (ArgumentOutOfRangeException e) {
                return $"-\t -\t -";
            }


        }
        public BiddingStorage()
        {
            this.bidItems = new List<BiddingDetails>();
        }
    }
}

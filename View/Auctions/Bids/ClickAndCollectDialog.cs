using System;
using Auction.Model;

namespace Auction.View
{
	public class ClickAndCollectDialog : Dialog
	{
		const string TITLE = "Click and collect";
		public ClickAndCollectDialog(AuctionHouse auction) : base(TITLE, auction)
		{
		}
		public override void Display()
		{
		}
	}
}

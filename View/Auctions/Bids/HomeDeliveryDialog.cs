using System;
using Auction.Model;

namespace Auction.View
{
	public class HomeDeliveryDialog : Dialog
	{
		const string TITLE = "Home Delivery";
		public HomeDeliveryDialog(AuctionHouse auction) : base(TITLE, auction)
		{
		}
		public override void Display()
		{
		}
	}
}

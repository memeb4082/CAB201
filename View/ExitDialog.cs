using Auction.Model;
using static Auction.CustomUI;

namespace Auction.View {
	internal class ExitDialog : IDisplayable, ITerminator {
		public string Title { get; }
		public ExitDialog (string Title) {
			this.Title = Title;
		}
		public void Display() {
		}
	}
}

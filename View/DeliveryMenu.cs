using Auction.Model;
namespace Auction.View
{
    internal class DeliveryMenu : Menu
    {
        private const string TITLE = "Delivery Instructions";
        public DeliveryMenu(
            ProductDetails product,
            decimal bidamt
        ) : base(
            TITLE,
            product,
            bidamt,
            new ClickAndCollectDialog(product, bidamt),
            new HomeDeliveryDialog(product, bidamt)
        )
        {
        }
        public override void Display()
        {
            WriteOptions();
            IDisplayable opt = GetOption();
            opt.Display();
        }
    }
}

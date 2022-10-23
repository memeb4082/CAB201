using System;
using Auction.Model;

namespace Auction.View
{
    public class MainMenu : Menu
    {
        private const string TITLE = "Main Menu";
        private ProductStorage Products { get; }
        private ClientStorage Clients { get; }
        public MainMenu(
            ProductStorage Products,
            ClientStorage Clients
            ) : base(
            TITLE,
            Products,
            Clients,
            new RegisterDialog(
                Products,
                Clients
            ),
            new LoginDialog(
                Products,
                Clients
            )
            )
        {
            this.Products = Products;
            this.Clients = Clients;
        }
    }
}
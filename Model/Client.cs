using System;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using Auction.View;
namespace Auction.Model
{
    public class Client
    {
        // Fields
        private string name;
        private string email;
        private string password;

        private Address homeAddress;
        // Params
        public string Name
        {
            get { return name; }
        }
        public Address HomeAddress
        {
            get
            {
                return homeAddress;
            }
            internal set
            {
                homeAddress = value;
            }
        }
        public string Email
        {
            get { return email.ToString(); }
        }
        // TODO: Add password hasher, implement as method to use with validation, internal class maybe?
        public string Password
        {
            get { return password; }
        }
        public Client()
        {
            this.name = CustomInput.CustomString("Please enter username (must not be empty)", @"^(?!\s*$).+");
            this.email = CustomInput.CustomString("Please enter email", @"^[A-Za-z0-9]+([\.]?[A-Za-z0-9]+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$");
            this.password = CustomInput.CustomPassword();
        }
        internal Client(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }
    }
}

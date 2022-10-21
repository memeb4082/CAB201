﻿using System;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using Auction.View;
namespace Auction.Model
{
    public class Client
    {
        private string name;
        private string email;
        private string password;

        private Address? homeAddress;
        private ProductStorage products;

        public string Name
        {
            get { return name; }
        }
        public Address HomeAddress { get; internal set; }
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
            // TODO: FIX REGEX EMAIL
            this.name = CustomInput.CustomString("Please enter username (must not be empty)", "^(?!\\s*$).+");
            this.email = CustomInput.CustomString("Please enter email", "");
            // this.email = CustomInput.CustomString("Please enter email", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            this.password = CustomInput.CustomPassword();
            this.products = new ProductStorage(email);
        }
        internal Client(string name, string email, string password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            if (homeAddress != null)
            {
                this.homeAddress = homeAddress;
            }
            this.products = new ProductStorage(email);
        }
    }
}

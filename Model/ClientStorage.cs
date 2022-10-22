
using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Auction.View;
namespace Auction.Model
{
    public class ClientStorage
    {
        List<Client> clients = new List<Client>();

        private string fileName;
        public ClientStorage(string fileName)
        {
            this.fileName = fileName;
            Load();
        }
        private void Load()
        {
            if (!File.Exists(fileName))
            {
                new XDocument(
                    new XElement("Clients")
                )
                .Save(fileName);
            }
            XDocument doc = XDocument.Load(fileName);
            IEnumerable<XElement> list = doc.Descendants("Clients").Elements();
            foreach (XElement el in list)
            {
                LoadData(el);
            }

        }

        private void LoadData(XElement data)
        {
            string name = data.Element("Name").Value;
            string email = data.Attribute("Email").Value;
            string password = data.Element("Password").Value;
            Client client = new Client(name, email, password);
            if (data.Descendants("Address").Any())
            {
                XElement addressData = data.Element("Address");
                client.HomeAddress = new Address(addressData);
            }
            if (data.Descendants("Products").Any())
            {
                ProductStorage products = new ProductStorage();
                IEnumerable<XElement> productsList = data.Descendants("Products").Elements();
                foreach (XElement productEl in productsList)
                {
                    products.Add(productEl);
                }
                client.Products = products;
            }
        }
        public void Register()
        {
            // TODO: Check video for prompts
            // TODO: Update email regex
            // TODO: Implement if check for duplicate email necessary
            Client client = new Client();
            clients.Add(client);
            if (File.Exists(fileName))
            {
                XDocument doc = XDocument.Load(fileName);
                doc.Element("Clients").Add(
                    new XElement("Client", new XAttribute("Email", client.Email),
                        new XElement("Name", client.Name),
                        new XElement("Password", client.Password))
                );
                doc.Save(fileName);
            }
        }
        public Client Login()
        {
            // TODO: Check video for prompts
            bool emailVerified = false;
            bool passwordVerified = false;
            string email;
            string password;
            Client loginTarget = default;
            while (emailVerified == false)
            {
                email = CustomInput.CustomString("Please enter email:");
                foreach (Client client in clients)
                {
                    if (string.Equals(email, client.Email))
                    {
                        emailVerified = true;
                        loginTarget = client;
                        break;
                    }
                }
                if (!emailVerified) { WriteLine("Email not found, please try again"); }
            }
            while (passwordVerified == false)
            {
                password = CustomInput.CustomString("Please enter password:");
                if (string.Equals(password, loginTarget.Password))
                {
                    passwordVerified = true;
                    break;
                }
                else { WriteLine("Password incorrect, please try again"); }
            }
            if (loginTarget.HomeAddress == null)
            {
                Address address = new Address();
                loginTarget.HomeAddress = address;
                if (File.Exists(fileName))
                {
                    XDocument doc = XDocument.Load(fileName);
                    var account = doc
                        .Descendants("Client")
                        .Where(arg => arg.Attribute("Email").Value == loginTarget.Email)
                        .FirstOrDefault();
                    account.Add(address.ToXML());
                    doc.Save(fileName);
                }
            }
            return loginTarget;
        }
    }
}
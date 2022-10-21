// TODO: Implement abstraction for ClientStorage, ProductStorage and others
using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Auction.View;
namespace Auction.Model{
    interface IStorage {
        void Load();
        void LoadData();
        void Save();
    }
}
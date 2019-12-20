using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteamPriceComparison.Models;
using System.Collections.Generic;

namespace SteamPriceComparison.Services
{
    [TestClass]
    public class AppStoreTests
    {
        [TestMethod]
        public void GetTopSellers()
        {
            var store = new AppStore();
            IEnumerable<App> topSellers = store.GetTopSellers();
        }
    }
}
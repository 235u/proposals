using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamePriceComparison.Models;
using System.Collections.Generic;

namespace GamePriceComparison.Services
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
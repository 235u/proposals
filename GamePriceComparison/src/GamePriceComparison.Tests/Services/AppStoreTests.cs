using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamePriceComparison.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamePriceComparison.Services
{
    [TestClass]
    public class AppStoreTests
    {
        [TestMethod]
        public async Task GetTopSellers()
        {
            var store = new AppStore();
            IEnumerable<App> topSellers = await store.GetTopSellersAsync();
        }
    }
}
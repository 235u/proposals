using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SteamPriceComparison.Models
{
    [TestClass]
    public class ExchangeRateCollectionTests
    {
        [TestMethod]
        public void GetExchangeRateCollection()
        {
            var rates = ExchangeRateCollection.GetExchangeRates();
        }
    }
}
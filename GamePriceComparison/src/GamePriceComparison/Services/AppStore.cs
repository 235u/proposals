using RestSharp;
using GamePriceComparison.Helpers;
using GamePriceComparison.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GamePriceComparison.Services
{
    public class AppStore
    {
        private const string DefaultLanguage = "en";

        private RestClient _client = new RestClient(baseUrl: "https://store.steampowered.com/api");
        private ExchangeRateCollection _exchangeRates = ExchangeRateCollection.GetExchangeRates();

        public static Currency ParseCurrency(string code)
        {
            return Enum.GetValues(typeof(Currency))
                .OfType<Currency>()
                .Single(c => c.GetShortName() == code);
        }

        public IEnumerable<App> GetTopSellers(Country country = Country.UnitedKingdom)
        {
            var topSellers = new List<App>();

            var request = new RestRequest("featuredcategories");
            request.AddParameter("cc", country.GetShortName());
            request.AddParameter("l", DefaultLanguage);

            IRestResponse response = _client.Get(request);
            using (var document = JsonDocument.Parse(response.Content))
            {
                JsonElement items = document.RootElement.GetProperty("top_sellers").GetProperty("items");
                foreach (JsonElement item in items.EnumerateArray())
                {
                    var app = new App
                    {
                        Id = item.GetProperty("id").GetInt32(),
                        EnglishName = item.GetProperty("name").GetString()
                    };

                    if (topSellers.Any(a => a.Id == app.Id))
                    {
                        // identic top sellers possible
                        continue;
                    }

                    var currencyCode = item.GetProperty("currency").GetString();
                    var originalPriceCurrency = ParseCurrency(currencyCode);

                    var finalPrice = item.GetProperty("final_price").GetInt32();
                    var originalPriceValue = Convert.ToDecimal(finalPrice) / 100;

                    app.LocalPrice = new Price
                    {
                        Currency = originalPriceCurrency,
                        Value = originalPriceValue
                    };

                    topSellers.Add(app);
                }
            }

            Update(topSellers, country);
            return topSellers;
        }

        public void Update(IEnumerable<App> apps, Country baseCountry)
        {
            IEnumerable<int> appIds = apps.Select(a => a.Id);
            var appIdsString = string.Join(',', appIds);

            var remainingCountries = Enum.GetValues(typeof(Country))
                .OfType<Country>()
                .Where(c => c != baseCountry);

            foreach (Country country in remainingCountries)
            {
                var request = new RestRequest("appdetails");
                request.AddParameter("appids", appIdsString);
                request.AddParameter("filters", "price_overview");
                request.AddParameter("cc", country.GetShortName());
                request.AddParameter("l", "en");

                IRestResponse response = _client.Get(request);
                using (var document = JsonDocument.Parse(response.Content))
                {
                    foreach (var item in document.RootElement.EnumerateObject())
                    {
                        if (item.Value.GetProperty("success").GetBoolean())
                        {
                            int id = int.Parse(item.Name);
                            App app = apps.Single(a => a.Id == id);

                            JsonElement priceOverview = item.Value.GetProperty("data").GetProperty("price_overview");

                            var currencyCode = priceOverview.GetProperty("currency").GetString();
                            var originalPriceCurrency = ParseCurrency(currencyCode);

                            var finalPrice = priceOverview.GetProperty("final").GetInt32();
                            var originalPriceValue = Convert.ToDecimal(finalPrice) / 100;

                            var exchangeRate = _exchangeRates[originalPriceCurrency];
                            var basePriceValue = originalPriceValue / exchangeRate;

                            var price = new LocalizedPrice
                            {
                                OriginalPrice = new Price
                                {
                                    Currency = originalPriceCurrency,
                                    Value = originalPriceValue
                                },
                                BasePrice = new Price
                                {
                                    Currency = Currency.PoundSterling,
                                    Value = basePriceValue
                                }
                            };

                            app.LocalizedPrices.Add(country, price);
                        }
                    }
                }
            }
        }


    }
}

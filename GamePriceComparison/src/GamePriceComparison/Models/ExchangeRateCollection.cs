using RestSharp;
using SteamPriceComparison.Helpers;
using SteamPriceComparison.Models;
using SteamPriceComparison.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace SteamPriceComparison.Models
{
    public class ExchangeRateCollection : Dictionary<Currency, decimal>
    {
        public static readonly Dictionary<Currency, Country> Countries = new Dictionary<Currency, Country>
        {
            [Currency.MexicanPeso] = Country.Mexico,
            [Currency.RussianRouble] = Country.Russia,
            [Currency.PoundSterling] = Country.UnitedKingdom
        };

        // See: https://exchangeratesapi.io
        private static readonly RestClient Client = new RestClient(baseUrl: "https://api.exchangeratesapi.io");

        private ExchangeRateCollection()
        {
        }

        public Currency BaseCurrency { get; set; }
        
        public static ExchangeRateCollection GetExchangeRates(Currency baseCurrency = Currency.PoundSterling)
        {
            var collection = new ExchangeRateCollection
            {
                BaseCurrency = baseCurrency
            };

            var request = new RestRequest(resource: "latest");

            request.AddParameter("base", baseCurrency.GetShortName());
            request.AddParameter("symbols", GetSymbols(baseCurrency));

            IRestResponse response = Client.Get(request);
            using (var document = JsonDocument.Parse(response.Content))
            {
                JsonElement rates = document.RootElement.GetProperty("rates");
                foreach (var bla in rates.EnumerateObject())
                {
                    Currency currency = AppStore.ParseCurrency(bla.Name);
                    decimal exchangeRate = bla.Value.GetDecimal();
                    collection.Add(currency, exchangeRate);
                }
            }

            return collection;
        }

        private static string GetSymbols(Currency baseCurrency)
        {
            IEnumerable<string> shortNames = Enum.GetValues(typeof(Currency))
               .OfType<Currency>()
               .Where(currency => currency != baseCurrency)
               .Select(currency => currency.GetShortName());

            return string.Join(',', shortNames);
        }
    }
}

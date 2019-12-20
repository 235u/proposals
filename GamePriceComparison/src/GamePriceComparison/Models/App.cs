using System.Collections.Generic;

namespace SteamPriceComparison.Models
{
    public class App
    {
        public int Id { get; set; }

        public string EnglishName { get; set; }

        public Price LocalPrice { get; set; }

        public Dictionary<Country, LocalizedPrice> LocalizedPrices { get; set; } = 
            new Dictionary<Country, LocalizedPrice>();
    }
}

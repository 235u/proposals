using System.ComponentModel.DataAnnotations;

namespace YandexTaxiScraper
{
    public sealed class Company
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string WorkingTime { get; set; }
    }
}

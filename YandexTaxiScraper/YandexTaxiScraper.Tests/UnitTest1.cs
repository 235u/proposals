using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Io;
using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YandexTaxiScraper
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            List<Company> companies = await GetCompaniesAsync();
            using (var writer = new StringWriter())
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(companies);
                }

                var content = writer.ToString();
            }
        }

        public static async Task<List<Company>> GetCompaniesAsync()
        {
            var companies = new List<Company>();

            var tasks = new List<Task<List<Company>>>();
            foreach (var city in City.Values)
            {
                var task = GetCompaniesAsync(city);
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);
            foreach (var task in tasks)
            {
                companies.AddRange(task.Result);
            }

            return companies;
        }

        private static async Task<List<Company>> GetCompaniesAsync(City city)
        {
            var companies = new List<Company>();

            var configuration = Configuration.Default
                .WithDefaultLoader()
                .WithDefaultCookies();

            var context = BrowsingContext.New(configuration);

            var address = "https://driver.yandex/ru-ru/base/parks";
            var url = new Url(address);

            var cookieProvider = configuration.Services.OfType<ICookieProvider>().First();
            cookieProvider.SetCookie(url, $"city={city.Id}");

            IDocument document = await context.OpenAsync(url);

            IHtmlCollection<IElement> cellNames = document.QuerySelectorAll("table > thead > tr > th > p");
            var companyFactory = new CompanyFactory(cellNames);

            IHtmlCollection<IElement> rows = document.QuerySelectorAll("table > tbody > tr");
            foreach (IHtmlTableRowElement row in rows)
            {
                var company = companyFactory.Create(row, city.Name);
                companies.Add(company);
            }

            return companies;
        }
    }
}

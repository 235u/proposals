using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WotApi.Models;
using WotApi.Services;

namespace WotApi.Tests
{
    [TestClass]
    public partial class ClanListTests
    {
        private const string Url = 
            "https://api.worldoftanks.eu/wot/clans/list/?application_id=687270730512bd772a412b9e3aa894fa";

        private static readonly JsonSerializerOptions DeserializationOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        static ClanListTests()
        {
            DeserializationOptions.Converters.Add(new JsonStringEnumConverter());
            DeserializationOptions.Converters.Add(new DateTimeOffsetConverter());
        }        

        private static int GetPageCount(Meta meta)
        {
            int pageCount = meta.Total / meta.Count;
            if ((meta.Total % meta.Count) > 0)
            {
                pageCount += 1;
            }

            return pageCount;
        }

        [TestMethod]
        public async Task GetClansSequentially()
        {            
            using (var client = new HttpClient())
            {
                string content = await client.GetStringAsync(Url);
                var clanList = JsonSerializer.Deserialize<ClanList>(content, DeserializationOptions);

                Assert.AreEqual(Status.Ok, clanList.Status);

                int pageCount = GetPageCount(clanList.Meta);                
                for (int page = 2; page <= pageCount; page++)
                {
                    content = await client.GetStringAsync(Url + $"&page_no={page}");
                    clanList = JsonSerializer.Deserialize<ClanList>(content, DeserializationOptions);

                    Assert.AreEqual(Status.Ok, clanList.Status);
                }
            }
        }

        [TestMethod]
        public async Task GetClansConcurrently()
        {
            var tasks = new List<Task<string>>();
            var allClans = new List<Clan>();

            using (var client = new ThrottledHttpClient())
            {
                string content = await client.GetStringAsync(Url);
                var clanList = JsonSerializer.Deserialize<ClanList>(content, DeserializationOptions);
                allClans.AddRange(clanList.Data);                

                int pageCount = GetPageCount(clanList.Meta);
                for (int page = 2; page <= pageCount; page++)
                {
                    Task<string> task = client.GetStringAsync(Url + $"&page_no={page}");
                    tasks.Add(task);
                }

                string[] results = await Task.WhenAll(tasks);
                foreach (string result in results)
                {
                    clanList = JsonSerializer.Deserialize<ClanList>(content, DeserializationOptions);
                    allClans.AddRange(clanList.Data);
                }                                
            }

            using (var stream = File.OpenWrite("eu.clan-list.final.json"))
            using (var writer = new Utf8JsonWriter(stream))
            {
                var serializationOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                
                JsonSerializer.Serialize(writer, allClans, serializationOptions);
            }            
        }
    }
}

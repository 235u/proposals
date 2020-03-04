using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataForSeo.SearchVolume
{
    internal enum InternalStatusCode
    {
        OK = 20000
    }

    internal class Program
    {
        // inclusive upper bounds
        private const int MaxKeywordCountPerRequest = 700;
        private const int MaxKeywordCountPerPhrase = 10;
        private const int MaxKeywordLength = 80;

        private const string InputFileName = "Keywords.txt";
        private const string OutputFileName = "Output.json";

        private static readonly string LocationName = ConfigurationManager.AppSettings.Get("Location");
        private static readonly string LanguageCode = ConfigurationManager.AppSettings.Get("Language");

        private static async Task Main()
        {
            using (var httpClient = CreateHttpClient())
            {
                HttpContent requestContent = CreatePostRequestContent();
                HttpResponseMessage responseMessage = await httpClient.PostAsync(
                    "/v3/keywords_data/google/search_volume/task_post", requestContent);

                Debug.Assert(responseMessage.IsSuccessStatusCode, responseMessage.ReasonPhrase);

                string responseContent = await responseMessage.Content.ReadAsStringAsync();
                var postTasksResult = JsonConvert.DeserializeObject<dynamic>(responseContent);

                if (postTasksResult.status_code == InternalStatusCode.OK)
                {
                    File.WriteAllText(InputFileName, string.Empty);
                    Console.WriteLine($"Total tasks cost: {postTasksResult.cost} USD");

                    // TODO: Implement polling / switch to callbacks.
                    await Task.Delay(10_000);

                    responseMessage = await httpClient.GetAsync(
                    "/v3/keywords_data/google/search_volume/tasks_ready");

                    responseContent = await responseMessage.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<dynamic>(responseContent);

                    if (result.status_code == InternalStatusCode.OK)
                    {
                        var output = string.Empty;

                        foreach (var task in result.tasks)
                        {
                            foreach (var entry in task.result)
                            {
                                responseMessage = await httpClient.GetAsync(
                                    $"/v3/keywords_data/google/search_volume/task_get/{entry.id}");

                                responseContent = await responseMessage.Content.ReadAsStringAsync();
                                output += responseContent;
                            }
                        }

                        File.WriteAllText(OutputFileName, output);
                    }
                }
            }
        }

        private static HttpClient CreateHttpClient()
        {
            string login = ConfigurationManager.AppSettings.Get("Login");
            string password = ConfigurationManager.AppSettings.Get("Password");
            byte[] bytes = Encoding.ASCII.GetBytes($"{login}:{password}");
            string parameter = Convert.ToBase64String(bytes);
            return new HttpClient
            {
                BaseAddress = new Uri("https://api.dataforseo.com/"),
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Basic", parameter)
                }
            };
        }

        private static HttpContent CreatePostRequestContent()
        {
            var postData = new List<object>();

            Queue<string[]> splitKeywordPhrases = GetSplitKeywordPhrases();
            while (splitKeywordPhrases.Count > 0)
            {
                var task = new
                {
                    location_name = LocationName,
                    language_code = LanguageCode,
                    keywords = PullKeywords(splitKeywordPhrases)
                };

                postData.Add(task);
            }

            string json = JsonConvert.SerializeObject(postData);
            return new StringContent(json);
        }

        private static Queue<string[]> GetSplitKeywordPhrases()
        {
            var splitKeywordPhrases = new Queue<string[]>();

            Debug.Assert(File.Exists(InputFileName));

            string text = File.ReadAllText(InputFileName);
            Debug.Assert(!string.IsNullOrWhiteSpace(text));

            string[] keywordPhrases = text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            foreach (string phrase in keywordPhrases)
            {
                char[] separators = new[] { ' ', '+' };
                string[] keywords = phrase.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                Debug.Assert(keywords.Length <= MaxKeywordCountPerPhrase);
                Debug.Assert(!keywords.Any(k => k.Length > MaxKeywordLength));

                splitKeywordPhrases.Enqueue(keywords);
            }

            return splitKeywordPhrases;
        }

        private static string[] PullKeywords(Queue<string[]> splitKeywordPhrases)
        {
            var keywords = new List<string>();
            int keywordCount = 0;

            do
            {
                string[] phraseKeywords = splitKeywordPhrases.Peek();
                if ((keywordCount + phraseKeywords.Length) <= MaxKeywordCountPerRequest)
                {
                    splitKeywordPhrases.Dequeue();

                    string phrase = string.Join(' ', phraseKeywords);
                    keywords.Add(phrase);

                    keywordCount += phraseKeywords.Length;
                }
                else
                {
                    break;
                }

            }
            while (splitKeywordPhrases.Count > 0);

            return keywords.ToArray();
        }
    }
}

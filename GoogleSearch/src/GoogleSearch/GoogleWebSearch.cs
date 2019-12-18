using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GoogleSearch
{
    public sealed class GoogleWebSearch : ILinkSearch
    {
        private const string QueryParameterName = "q";

        // Google Web Search for the current region showing search results in English 
        private const string BaseUrl = "https://www.google.com/search?hl=en";

        private readonly IBrowsingContext _context;

        public GoogleWebSearch()
        {
            IConfiguration configuration = Configuration.Default.WithDefaultLoader();
            _context = BrowsingContext.New(configuration);
        }

        private static Url CreateRequestUrl(string q)
        {
            string value = GetQueryParameterValue(q);
            string address = QueryHelpers.AddQueryString(BaseUrl, QueryParameterName, value);
            return Url.Create(address);
        }

        private static string GetQueryParameterValue(string q)
        {
            string value = q.Trim().CollapseWhiteSpace();
            return WebUtility.UrlEncode(value);
        }

        public async Task<IEnumerable<string>> FindLinksAsync(string q, int count = 2)
        {
            Url requestUrl = CreateRequestUrl(q);
            return await FindLinksAsync(requestUrl, count);
        }

        private async Task<IEnumerable<string>> FindLinksAsync(Url request, int count)
        {
            var links = new HashSet<string>();

            using (IDocument responseDocument = await _context.OpenAsync(request))
            {
                var anchorElements = responseDocument.GetElementsByTagName("a");
                foreach (IHtmlAnchorElement anchor in anchorElements)
                {
                    var hrefUrl = Url.Create(anchor.Href);
                    if (hrefUrl.Path == "url")
                    {
                        var queryDictionary = QueryHelpers.ParseQuery(hrefUrl.Query);
                        if (queryDictionary.ContainsKey(QueryParameterName))
                        {
                            string link = queryDictionary[QueryParameterName];
                            if (!links.Contains(link))
                            {
                                links.Add(link);
                            }
                        }
                    }

                    if (links.Count == count)
                    {
                        break;
                    }
                }
            }

            return links;
        }
    }
}

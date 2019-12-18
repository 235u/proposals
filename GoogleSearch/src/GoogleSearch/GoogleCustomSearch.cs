using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleSearch
{
    public sealed class GoogleCustomSearch : ILinkSearch, IDisposable
    {
        // See: https://developers.google.com/custom-search/v1/overview#search_engine_id
        private const string SearchEngineId = "017541964949974155940:zmnjdmd8a2d";

        private CustomsearchService _service;

        public GoogleCustomSearch()
        {
            var initializer = new BaseClientService.Initializer()
            {
                // See: https://developers.google.com/custom-search/v1/overview#api_key
                ApiKey = "AIzaSyD3dVAr-ufq9GETV7b2Zo1YoIwoTeLNskA",

                // See: https://developers.google.com/custom-search/v1/performance#gzip
                GZipEnabled = true
            };

            _service = new CustomsearchService(initializer);
        }

        public void Dispose()
        {
            if (_service != null)
            {
                _service.Dispose();
                _service = null;
            }
        }

        public async Task<IEnumerable<string>> FindLinksAsync(string query, int count = 2)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException(
                    nameof(query), "Query cannot be null or empty, or consist of white-space characters only.");
            }

            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count cannot be negative.");
            }

            var request = CreateRequest(query, count);
            return await FindLinksAsync(request);
        }

        private async Task<IEnumerable<string>> FindLinksAsync(CseResource.ListRequest request)
        {
            Search response = await request.ExecuteAsync();
            return response.Items.Select(i => i.Link);
        }
        
        private CseResource.ListRequest CreateRequest(string query, int count)
        {
            CseResource.ListRequest request = _service.Cse.List(query);
            request.Cx = SearchEngineId;

            // See: https://developers.google.com/custom-search/v1/performance#partial
            request.Fields = "items/link";

            request.Num = count;
            return request;
        }
    }
}

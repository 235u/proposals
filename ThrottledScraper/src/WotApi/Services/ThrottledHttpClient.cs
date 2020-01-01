using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WotApi.Services
{
    public sealed class ThrottledHttpClient : IDisposable
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly SemaphoreSlim _semaphore;
        private readonly TimeSpan _delay;

        public ThrottledHttpClient(
            uint maxConcurrentRequests = 10, uint maxRequestsPerInterval = 10, uint intervalInMilliseconds = 1000)
        {
            int initialCount = Convert.ToInt32(maxConcurrentRequests);
            _semaphore = new SemaphoreSlim(initialCount);

            double value = (intervalInMilliseconds / maxRequestsPerInterval) * maxConcurrentRequests;
            _delay = TimeSpan.FromMilliseconds(value);
        }

        public void Dispose()
        {
            _semaphore.Dispose();
            _client.Dispose();
        }

        public async Task<string> GetStringAsync(string requestUri)
        {
            await _semaphore.WaitAsync();
            string result = await _client.GetStringAsync(requestUri);
            await Task.Delay(_delay);
            _semaphore.Release();
            return result;
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            throw new NotImplementedException();
        }
    }
}

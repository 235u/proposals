using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace HtmlBanner.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    const int CachePeriodInSeconds = 31_536_000; // 1 year
                    string cacheControlHeaderValue = $"public, max-age={CachePeriodInSeconds}";
                    context.Context.Response.Headers.Append(HeaderNames.CacheControl, cacheControlHeaderValue);
                }
            });
        }
    }
}

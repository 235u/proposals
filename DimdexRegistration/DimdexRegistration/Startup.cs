using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;

namespace DimdexRegistration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {                
                app.UseBrowserLink();
            }
            else
            {
                app.UseHsts();
                app.UseContentTypeOptions();
                app.UseContentSecurityPolicy();
                app.UseReferrerPolicy();
            }

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();

            var options = new StaticFileOptions
            {
                OnPrepareResponse = (context) =>
                {
                    const int CachePeriodInSeconds = 31_536_000; // 1 year
                    string cacheControlHeaderValue = $"public, max-age={CachePeriodInSeconds}";
                    context.Context.Response.Headers.Append(HeaderNames.CacheControl, cacheControlHeaderValue);
                }
            };

            app.UseStaticFiles(options);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Visitors}/{action=Register}/{id?}");
            });
        }
    }
}

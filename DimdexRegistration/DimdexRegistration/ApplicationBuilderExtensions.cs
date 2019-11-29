using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;

namespace DimdexRegistration
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseContentTypeOptions(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });

            return app;
        }

        public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder app)
        {
            var directives = new string[]
            {
                // Fetch directives, controlling locations from which certain resource types may be loaded:
                "connect-src 'self'",
                "default-src 'none'",
                "font-src 'self' https://*.typekit.net",
                "img-src 'self'",
                "media-src 'self'",
                "script-src 'self'",
                "style-src 'self' https://*.typekit.net",

                // Restricts the URLs which can be used in a document's <base> element.
                "base-uri 'none'",

                // Restricts the URLs which can be used as the target of a form submissions.
                "form-action 'self'",

                // Specifies valid parents that may embed a page using <frame>, <iframe>, <object>, <embed> or <applet>.
                "frame-ancestors 'none'"
            };

            const string Separator = "; ";
            string headerValue = string.Join(Separator, directives);

            app.Use(async (context, next) =>
            {

                context.Response.Headers.Add(HeaderNames.ContentSecurityPolicy, headerValue);
                await next();
            });

            return app;
        }

        public static IApplicationBuilder UseReferrerPolicy(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Referrer-Policy", "same-origin");
                await next();
            });

            return app;
        }
    }
}

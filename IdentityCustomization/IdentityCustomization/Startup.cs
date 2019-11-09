using IdentityCustomization.Data;
using IdentityCustomization.Models;
using IdentityCustomization.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace IdentityCustomization
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddControllersWithViews(config =>
            {
                var builder = new AuthorizationPolicyBuilder();
                AuthorizationPolicy policy = builder.RequireAuthenticatedUser()
                    .Build();

                var filter = new AuthorizeFilter(policy);
                config.Filters.Add(filter);
            });

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<EmailSenderOptions>(Configuration.GetSection(nameof(EmailSenderOptions)));

            services.AddTransient<SmsSender>();
            services.Configure<SmsSenderOptions>(Configuration.GetSection(nameof(SmsSenderOptions)));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            UseApplicationRoles(app).Wait();
        }

        private static async Task UseApplicationRoles(IApplicationBuilder app)
        {
            var serviceType = typeof(IServiceScopeFactory);
            var serviceScopeFactory = app.ApplicationServices.GetService(serviceType) as IServiceScopeFactory;
            using (IServiceScope serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                foreach (var roleName in ApplicationRoleName.All)
                {
                    if (!await roleManager.RoleExistsAsync(roleName))
                    {
                        var role = new IdentityRole(roleName);
                        IdentityResult result = await roleManager.CreateAsync(role);
                    }
                }
            }
        }
    }
}

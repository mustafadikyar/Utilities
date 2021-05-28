using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smidge;
using Smidge.Cache;
using Smidge.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmidgeApp
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
            services.AddSmidge(Configuration.GetSection("smidge"));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSmidge(bundle =>
            {
                //bundle.CreateJs("xjs", "~/js/"); //all-files
                //bundle.CreateJs("xjs", "~/js/site.js", "~/js/site2.js");
                bundle.CreateCss("xcss", "~/css/site.css", "~/lib/bootstrap/dist/css/bootstrap.css");

                bundle.CreateJs("xjs", "~/js/").WithEnvironmentOptions(BundleEnvironmentOptions.Create().ForDebug(builder =>
                    builder.EnableCompositeProcessing()
                           .EnableFileWatcher() //klasörü izliyor.
                           .SetCacheBusterType<AppDomainLifetimeCacheBuster>() 
                           .CacheControlOptions(enableEtag: false, cacheControlMaxAge: 0))  //deðiþiklik durumunda cache yeniden oluþturuluyor.
                           .Build());
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

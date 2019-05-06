using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DateLocalization
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<RequestLocalizationOptions>(requestLocalizationOptions =>
            //{
            //    var supportedCultures = new System.Collections.Generic.List<CultureInfo>
            //    {
            //        new CultureInfo("en-US"),
            //        new CultureInfo("es-MX")
            //    };


            //    requestLocalizationOptions.SupportedCultures = supportedCultures;
            //    requestLocalizationOptions.SupportedUICultures = supportedCultures;

            //    //requestLocalizationOptions.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
            //    requestLocalizationOptions.RequestCultureProviders.Insert(0, new JsonRequestCultureProvider());
            //});
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var supportedCultures = new System.Collections.Generic.List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-MX")
            };

            var requestLocalizationOptions = new RequestLocalizationOptions
            {
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            };
            //requestLocalizationOptions.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
            requestLocalizationOptions.RequestCultureProviders.Insert(0, new JsonRequestCultureProvider());
            app.UseRequestLocalization(requestLocalizationOptions);
            //app.UseRequestLocalization();

            app.UseMvc();
        }
    }
}

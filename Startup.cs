using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using DotNETCoreIdentityPractice.Models.Core;

namespace DotNETCoreIdentityPractice
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
            // Configuration Initialize
            var config = new AppConfiguration();
            config.ProviderName = Configuration.GetValue<string>("APPSETTING_DBPROVIDERNAME");
            config.ConnectionString = Configuration.GetValue<string>("APPSETTING_DBCONNECTION");
            config.RedisConnectionString = Configuration.GetValue<string>("APPSETTING_REDISCONNECTION");
            services.AddSingleton(config);

            services.AddControllersWithViews();

            // Register the Swagger generator, defining 1 or more Swagger documents
            // Use Swagger Setting, see https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/getting-started-with-swashbuckle .
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "DotNETCoreIdentityPractice",
                    Description = ".NET Core Identity Practice",
                    Contact = new OpenApiContact
                    {
                        Name = "JUNKI555",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com/JUNKI555")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under WTFPL License",
                        Url = new Uri("https://github.com/JUNKI555/DotNETCoreIdentityPractice/blob/master/LICENSE")
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotNETCoreIdentityPractice V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

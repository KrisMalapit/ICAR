using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICAR.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ICAR
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ICARContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ICARContextTest")
            , builder => builder.UseRowNumberForPaging() //add this for Incorrect syntax near 'OFFSET'. Invalid usage of the option NEXT in the FETCH statement
            ));

            services.AddCors(opt =>
               opt.AddPolicy("CorsPolicy", policy => {
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://192.168.70.231");
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://sodium2");
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://192.168.30.182");
                   policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:44366");

               })

           );



            services
               .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options => {
                   options.AccessDeniedPath = "/you-are-not-allowed-page";
                   options.LoginPath = "/Accounts/Login";
               }
            );
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

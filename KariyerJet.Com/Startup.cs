using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using KariyerJet.Com.Data.Context;
using KariyerJet.Com.Models.Poco;
using KariyerJet.Com.Models.Settings;
using KariyerJet.Com.Requirements;
using KariyerJet.Com.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KariyerJet.Com
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                //opt.UseInMemoryDatabase("InMemoryDatabase");
                opt.UseSqlServer(connectionString);

                opt.UseLazyLoadingProxies(true);
            }, ServiceLifetime.Transient);

            services.AddDefaultIdentity<ApplicationUser>(opt =>
             {
                 opt.Password.RequireDigit = false;
                 opt.Password.RequireLowercase = false;
                 opt.Password.RequiredLength = 2;
                 opt.Password.RequireUppercase = false;
                 opt.User.RequireUniqueEmail = true;
                 opt.SignIn.RequireConfirmedAccount = false;
                 opt.SignIn.RequireConfirmedEmail = false;
                 opt.SignIn.RequireConfirmedPhoneNumber = false;


             }).AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddHttpContextAccessor();

            //services
            //    .AddDefaultIdentity<ApplicationUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddScoped<Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, EmailSender>();

            services.AddAuthorization(cfg =>
            {
                cfg.AddPolicy("YolunYarisi", p => p.Requirements.Add(new MinimumAgeRequirement(36)));
                cfg.AddPolicy("RegisteredUsersOnly", p => p.Requirements.Add(new UserRequirement("admin", "user")));
            });

            services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
            services.AddSingleton<IAuthorizationHandler, UserRoleHandler>();

            services.AddControllersWithViews();
            services.AddRazorPages();

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

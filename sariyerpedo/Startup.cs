using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using sariyerpedo.Areas.admin.Data.AuthorizationHandler;
using sariyerpedo.BUSSINES.Mapper;
using sariyerpedo.CORE.EmailConfig;
using sariyerpedo.Helpers;
using sariyerpedo.Resource;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace sariyerpedo
{
    public class Startup
    {
        private IConfiguration _configuration;
        private IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, false)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Injection

            services.AddRazorPages().AddRazorPagesOptions(options => { options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()); });

            services.AddDbContextDI(_configuration, Environment);
            services.AddInjections();

            //services.Configure<EmailConfiguration>(_configuration.GetSection("EmailConfiguration"));
            services.AddDistributedMemoryCache();

            #endregion

            #region Language Options

            services.AddLocalization(options => options.ResourcesPath = "Resource");
            services.AddSingleton<LocalizationService>();

            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        var assemblyName = new AssemblyName(typeof(ApplicationResource).GetTypeInfo().Assembly.FullName);
                        return factory.Create("ApplicationResource", assemblyName.Name);
                    };
                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("tr")
                };
                options.DefaultRequestCulture = new RequestCulture("tr");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new UrlRequestCultureProvider()
                {
                    Options = options
                });
            });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("lang", typeof(LocalizationService));
            });

            #endregion

            #region Mappers

            services.AddControllersWithViews();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new GeneralMapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            #region Cookie Authentication

            services.AddAuthentication("FormAuthenticationWithCookie")
                   .AddCookie("FormAuthenticationWithCookie", config =>
                   {
                       config.Cookie.Name = "form-authentication-with-cookie";
                       config.LoginPath = "/admin/editor/login";
                       config.AccessDeniedPath = "/admin/editor/useraccessdenied";
                   });

            services.AddAuthorization(config =>
            {
                config.AddPolicy("UserPolicy", policyBuilder =>
                {
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.Name);
                    policyBuilder.UserRequireCustomClaim(ClaimTypes.NameIdentifier);
                });

            });

            #endregion
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/anasayfa/hata/{0}");
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = context =>
                {
                    var headers = context.Context.Response.GetTypedHeaders();
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        Public = true,
                        MaxAge = TimeSpan.FromDays(30),
                    };

                    headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));
                }
            });
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            var requestLocalizationOptions = app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(requestLocalizationOptions.Value);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=anasayfa}/{action=sayfa}/{id?}");

                endpoints.MapControllerRoute(
                name: "culture",
                pattern: "{culture}/{controller=anasayfa}/{action=sayfa}/{id?}");

                endpoints.MapControllerRoute(
                name: "islem",
                pattern: "/islem/{Id}/{title}", new { controller = "anasayfa", action = "islem" });

                endpoints.MapControllerRoute(
                name: "treatmentdetail",
                pattern: "/treatmentdetail/{Id}/{title}", new { controller = "home", action = "treatmentdetail" });

                endpoints.MapControllerRoute(
                name: "gonderi",
                pattern: "/gonderi/{Id}/{title}", new { controller = "anasayfa", action = "gonderi" });

                endpoints.MapControllerRoute(
                name: "postdetail",
                pattern: "/postdetail/{Id}/{title}", new { controller = "home", action = "postdetail" });

                endpoints.MapAreaControllerRoute(
                 name: "admin",
                 areaName: "admin",
                 pattern: "admin/{controller=editor}/{action=home}/{id?}"
               );

            });

        }
    }
}

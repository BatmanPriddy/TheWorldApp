using AutoMapper;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder().SetBasePath(appEnv.ApplicationBasePath).AddJsonFile("config.json").AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<WorldUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == (int)HttpStatusCode.OK)
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        else
                            ctx.Response.Redirect(ctx.RedirectUri);

                        return Task.FromResult(0);
                    }
                };
            }).AddEntityFrameworkStores<WorldContext>();

            services.AddMvc(config =>
            {
#if !DEBUG
                config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
            .AddJsonOptions(options => { options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });
            
            services.AddLogging();
            services.AddEntityFramework().AddSqlServer().AddDbContext<WorldContext>();
            services.AddScoped<CoordService>();
            services.AddTransient<WorldContextSeedData>();
            services.AddScoped<IWorldRepository, WorldRepository>();

//#if DEBUG
            services.AddScoped<IMailService, DebugMailService>();
//#else
//            services.AddScoped<IMailService, RealMailService>();
//#endif

            services.AddScoped<IMapper>(map =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Trip, TripViewModel>().ReverseMap();
                    cfg.CreateMap<Stop, StopViewModel>().ReverseMap();
                });

                return config.CreateMapper();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, WorldContextSeedData seeder, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddDebug(LogLevel.Information);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                loggerFactory.AddDebug(LogLevel.Error);
                app.UseExceptionHandler("/App/Error"); //just for demo purposes, no route or physical pages created
            }
            
            //app.Run(async (context) =>
            //{
            //    var html = @"<!DOCTYPE html><html><head></head><body><h2>The World</h2></body></html>";

            //    await context.Response.WriteAsync(html);
            //});
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseIdentity();

            app.UseMvc(config => 
            {
                config.MapRoute(
                    name: "Default", 
                    template: "{controller}/{action}/{id?}", 
                    defaults: new { controller = "App", action = "Index" });
            });

            await seeder.EnsureSeedDataAsync();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
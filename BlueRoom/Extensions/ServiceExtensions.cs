using Contracts;
using Entities.Context;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Okta.AspNetCore;
using Repository;

namespace BlueRoom.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("VueCorsPolicy", builder =>
                {
                    builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:3333");
                });
            });
        }

        public static void ConfigureAuthenticationService(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
                options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
            })
                .AddOktaWebApi(new OktaWebApiOptions
                {
                    OktaDomain = "https://dev-3414129.okta.com"
                });
        }
        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<BlueRoomContext>(options =>
                options.UseSqlServer(
                    config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BlueRoom")));
        }
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

    }
}
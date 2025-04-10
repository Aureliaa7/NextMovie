using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NextMovie.Application;
using NextMovie.Application.Interfaces;
using NextMovie.Application.Services;
using NextMovie.Infrastructure.Data;
using NextMovie.Infrastructure.Repositories;
using NextMovie.Infrastructure.Tmdb.Handlers;
using NextMovie.Infrastructure.Tmdb.Interfaces;
using NextMovie.Infrastructure.Tmdb.Services;
using NextMovie.Models.Options;
using System.Text;

namespace NextMovie.WebAPI.Extensions
{
    static class ServiceCollectionExtensions
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;

                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITmdbGenreService, TmdbGenreService>();
            services.AddScoped<IApiService, ApiService>();
            services.AddScoped<ITmdbMovieService, TmdbMovieService>();
            services.AddScoped<ITmdbConfigurationService, TmdbConfigurationService>();
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; // Set to false only in development
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),

                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void ConfigureTmdbHttpClient(this IServiceCollection services, string baseAddress)
        {
            services.AddTransient<TmdbApiKeyHandler>();

            services.AddHttpClient(Constants.TmdbHttpClient, client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            })
            .AddHttpMessageHandler<TmdbApiKeyHandler>();
        }
    }
}

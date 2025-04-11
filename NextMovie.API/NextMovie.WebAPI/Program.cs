using NextMovie.Application;
using NextMovie.Infrastructure.Tmdb.BackgroundTasks;
using NextMovie.Infrastructure.Tmdb.Services;
using NextMovie.Models.Options;
using NextMovie.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(Constants.ReactAppPolicyName, policy =>
    {
        policy.WithOrigins(builder.Configuration["ReactAppUrl"] ?? string.Empty)
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

JwtSettings jwtSettings = builder.Configuration.GetSection(JwtSettings.Jwt).Get<JwtSettings>()!;
builder.Services.AddSingleton(jwtSettings);
TmdbSettings tmdbSettings = builder.Configuration.GetSection(TmdbSettings.Tmdb).Get<TmdbSettings>()!;
builder.Services.AddSingleton(tmdbSettings);

builder.Services.ConfigureTmdbHttpClient(tmdbSettings.BaseUrl);

builder.Services.AddSingleton<TmdbStore>();
builder.Services.AddHostedService<TmdbInitializer>();

builder.Services.RegisterDatabase(builder.Configuration);
builder.Services.RegisterServices();
builder.Services.AddVersioning();

builder.Services.ConfigureJwtAuthentication(jwtSettings);

builder.ConfigureSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(Constants.ReactAppPolicyName);

app.MapControllers();

app.Run();


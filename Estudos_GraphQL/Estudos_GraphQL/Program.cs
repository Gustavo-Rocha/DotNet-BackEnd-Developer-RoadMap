using Estudos_GraphQL.IoC;
namespace Estudos_GraphQL;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();
        var services = builder.Services;
        var configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        services.ConfigureAppDependencies(configuration);
        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapAppEndpoints();
        app.MapGraphQL();
        ////var summaries = new[]
        ////{
        ////    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ////};

        ////app.MapGet("/weatherforecast", (HttpContext httpContext) =>
        ////{
        ////    var forecast =  Enumerable.Range(1, 5).Select(index =>
        ////        new WeatherForecast
        ////        {
        ////            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        ////            TemperatureC = Random.Shared.Next(-20, 55),
        ////            Summary = summaries[Random.Shared.Next(summaries.Length)]
        ////        })
        ////        .ToArray();
        ////    return forecast;
        ////})
        ////.WithName("GetWeatherForecast");

        app.Run();
    }
}

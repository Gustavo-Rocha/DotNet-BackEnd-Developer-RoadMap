
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Shared_message_lib;

namespace Estudos_Teste_RabbitMQ_Worker_MassTransit_Publish
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("AppUser");
                        h.Password("AppUser");
                    });
                });
            });

            //  builder.Services.AddMassTransitHostedService();




            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            app.MapPost("/cadastraClienteRabbit", async (HttpContext httpContext, IPublishEndpoint _publisher, [FromBody] ClienteRequestBody RequestBody) =>
            {
                await _publisher.Publish<ClienteRequestBody>(RequestBody);

                //var forecast = Enumerable.Range(1, 5).Select(index =>
                //    new WeatherForecast
                //    {
                //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                //        TemperatureC = Random.Shared.Next(-20, 55),
                //        Summary = summaries[Random.Shared.Next(summaries.Length)]
                //    })
                //    .ToArray();
                //return forecast;
            })
            .WithName("cadastraClienteRabbit");

            app.Run();
        }
    }
}

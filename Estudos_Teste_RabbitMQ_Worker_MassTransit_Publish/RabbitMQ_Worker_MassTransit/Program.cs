using MassTransit;

namespace RabbitMQ_Worker_MassTransit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<Worker>();
                x.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("localhost", "/", h =>
                    {
                        h.Username("AppUser");
                        h.Password("AppUser");
                    });

                    cfg.ReceiveEndpoint("ClienteQueue", e =>
                    {
                        e.ConfigureConsumer<Worker>(ctx);
                    });

                });
            });
            
            var host = builder.Build();
            host.Run();
        }
    }
}
using MassTransit;
using Shared_message_lib;
using System.Text.Json;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace RabbitMQ_Worker_MassTransit
{
    public class Worker : IConsumer<ClienteRequestBody>
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
            
        public Task Consume(ConsumeContext<ClienteRequestBody> context)
        {
            Console.WriteLine($"📩 Mensagem recebida: {JsonSerializer.Serialize<ClienteRequestBody>(context.Message)}");
            return Task.CompletedTask;
        }

    }
}

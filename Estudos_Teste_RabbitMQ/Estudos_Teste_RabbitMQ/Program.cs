using RabbitMQ.Client;
using Serilog;
using System.Text;
using System.Threading.Channels;

namespace Estudos_Teste_RabbitMQ_Envio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var logger = new LoggerConfiguration().CreateLogger();
            Console.WriteLine("Hello, World!");

            var connectionString = "amqp://AppUser:AppUser@localhost:5672/";
            var queueName = "FilaMilGrau";
            var exchangeName = "teste";
            var DLQExchangeName = "teste.DLQ";

            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(connectionString)
                };

                using var connection = factory.CreateConnectionAsync().Result;
                using var channel =  connection.CreateChannelAsync().Result;

                channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);


                channel.QueueDeclareAsync(queue: queueName,
                                          durable: false,
                                          exclusive: false,
                                          autoDelete: false,
                                          arguments: new Dictionary<string, object>
                                          {
                                            { "x-dead-letter-exchange", DLQExchangeName },                      // exchange padrão
                                            { "x-dead-letter-routing-key", "FilaMilGrau.DLQ" }          // para onde vão as mensagens rejeitadas
                                          });

                channel.QueueDeclareAsync(queue: "FilaMilGrau.DLQ", durable: true, exclusive: false, autoDelete: false);

                channel.QueueBindAsync(queueName, exchangeName, queueName, null);

                var mensagem = Encoding.UTF8.GetBytes("Mensagem enviada do publicador");
                channel.BasicPublishAsync(exchange: exchangeName,
                                         routingKey: queueName,
                                         mandatory: true,
                                         basicProperties: new BasicProperties(),
                                         body: mensagem);
            }
            catch (Exception ex)
            {
                logger.Error($"Exceção: {ex.GetType().FullName} | " +
                             $"Mensagem: {ex.Message}");
            }


        }
    }
}

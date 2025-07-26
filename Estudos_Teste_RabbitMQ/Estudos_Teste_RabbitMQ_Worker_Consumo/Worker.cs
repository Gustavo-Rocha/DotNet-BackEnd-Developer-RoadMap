using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace Estudos_Teste_RabbitMQ_Worker_Consumo
{
        public class Worker : BackgroundService
        {
            private IConnection _connection;
            private IChannel _channel;
       
            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                var connectionString = "amqp://AppUser:AppUser@localhost:5672/";
                var queueName = "FilaMilGrau";
                var DLQQueue = "FilaMilGrau.DLQ";
                var exchangeName = "teste";
                var DLQExchangeName = "teste.DLQ";

                var factory = new ConnectionFactory()
                {
                    Uri = new Uri(connectionString)
                };
                _connection = await factory.CreateConnectionAsync();
                _channel = await _connection.CreateChannelAsync();

                await _channel.ExchangeDeclareAsync(DLQExchangeName, ExchangeType.Direct);

                await _channel.QueueDeclareAsync(queue: DLQQueue, durable: true, exclusive: false, autoDelete: false);
            await _channel.QueueBindAsync(queue: DLQQueue,exchange: DLQExchangeName, routingKey: DLQQueue);

            await _channel.QueueDeclareAsync(queue: queueName,
                                              durable: false,
                                              exclusive: false,
                                              autoDelete: false,
                                              arguments: new Dictionary<string, object>
                                              {
                                                { "x-dead-letter-exchange", DLQExchangeName },                      // exchange padrão
                                                { "x-dead-letter-routing-key", DLQQueue }          // para onde vão as mensagens rejeitadas
                                              });


                var consumer = new AsyncEventingBasicConsumer(_channel);
                consumer.ReceivedAsync += Consumer_Received;
                await _channel.BasicConsumeAsync(queue: queueName,
                                                autoAck: false,
                                                consumer: consumer);

                var data = DateTime.Now.AddMilliseconds(40);
                while (DateTime.Now < data)
                {
                    Console.WriteLine(
                        $"Worker ativo em: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                }
            }

            private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                //await _channel.BasicAckAsync(e.DeliveryTag, multiple: false);
                await _channel.BasicRejectAsync(e.DeliveryTag, false); // Vai para a DLQ

                Console.WriteLine($"Mensagem Recebida: {message}");

                // Simula processamento
                await Task.Delay(100);
            }
    
        }
}

using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Service.Processamento.Domain;
using Service.Processamento.Services.Contracts;
using System.Text;
using System.Text.Json;

namespace Service.Processamento.Services
{
    public class MessageBusService : IMessageBusService
    {
        private const string QUEUE_PROCESSAMENTO = "fila-processamento";
        private readonly ConnectionFactory _factory;

        public MessageBusService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };
        }

        public async Task ProcessQueue(CancellationToken cancellationToken)
        {
            using (var connection = _factory.CreateConnection())
            {
                var channel = connection.CreateModel();
                var consumer = new EventingBasicConsumer(channel);

                channel.QueueDeclare(
                                    queue: QUEUE_PROCESSAMENTO,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null
                                    );

                consumer.Received += async (sender, eventArgs) =>
                {
                    try
                    {
                        var paymentApprovedBytes = eventArgs.Body.ToArray();
                        var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);

                        var messageNotification = JsonSerializer.Deserialize<CreateContactRequest>(paymentApprovedJson);

                        Console.WriteLine(messageNotification.Name + " " + messageNotification.Email);
                        
                        //Salva no banco em lote
                        channel.BasicAck(eventArgs.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing message: {ex.Message}");
                        channel.BasicNack(eventArgs.DeliveryTag, false, true);
                    }
                };

                channel.BasicConsume(QUEUE_PROCESSAMENTO, false, consumer);

                try
                {
                    await Task.Delay(-1, cancellationToken);
                }
                catch (OperationCanceledException ex)
                {
                    Console.WriteLine("Consumer stopping gracefully.");
                    Console.WriteLine($"Error processing message: {ex.Message}");
                    channel.Close();
                }
                finally
                {
                    channel.Close();
                }
            }
        }
    }
}

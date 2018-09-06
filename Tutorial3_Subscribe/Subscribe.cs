using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Tutorial3_Subscribe
{
    class Subscribe
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Subscriber Online!");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "logs", type: "fanout");

                    //each subscriber should have a randomly genereated queue name
                    var queueName = channel.QueueDeclare().QueueName;

                    //bind the queue so the exchange knows about all the subscribers
                    channel.QueueBind(
                        queue: queueName,
                        exchange: "logs",
                        routingKey: ""
                        );

                    Console.WriteLine(" [*] Waiting for logs.");

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] {0}", message);
                    };
                    channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        }
    }
}

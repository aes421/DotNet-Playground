using RabbitMQ.Client;
using System;
using System.Text;

namespace Tutorial3_Publish
{
    class Publish
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Publisher online!");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //RabbitMQ Messaging Model:
                    //Producer never interacts with queue.  It interacts with
                    //exchange.  Exchange handles accepting messages from producer
                    //and pushing it to the correct queues (multiples, just one, etc.)

                    //options are direct, topic, headers, fanout
                    channel.ExchangeDeclare(exchange: "direct_logs", type: "direct");

                    var severity = (args.Length > 0) ? args[0] : "info";

                    string message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(
                         exchange: "direct_logs",
                         routingKey: severity,
                         basicProperties: null,
                         body: body
                    );

                    Console.WriteLine(" [x] Sent {0}", message);
                }


                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}

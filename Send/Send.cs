using System;
using System.Text;
using RabbitMQ.Client;

namespace Send
{
    class Send
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ready to send!");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {

                    //durable true will ensure we don't lose messages even if the RabitMQ server dies
                    channel.QueueDeclare(queue: "task_queue",
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                    string message = GetMessage(args);
                    var body = Encoding.UTF8.GetBytes(message);

                    var props = channel.CreateBasicProperties();
                    //ensure we don't lose messages even if the RabitMQ server dies; not 100% accurate
                    props.Persistent = true;

                    channel.BasicPublish(exchange: "",
                                         routingKey: "hello",
                                         basicProperties: props,
                                         body: body);
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


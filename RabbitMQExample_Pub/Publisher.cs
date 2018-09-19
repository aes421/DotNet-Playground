using System;
using System.Linq;
using System.Text;
using RabbitMQ.Client;

//Topic exchange example:
//run three times with cmd args:
//all Hello all!
//astronaut1 Hello astronaut1!
//astronaut2 Hello astronaut2!
namespace RabbitMQExample_Pub
{
    class Publisher
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: "commandcenter", type: "topic");
                    var routingKey = args[0];
                    var message = string.Join(" ", args.Skip(1).ToArray());
                    Console.WriteLine($"Pubishing {message} to {routingKey}");

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(exchange: "commandcenter",
                                         routingKey: routingKey,
                                         basicProperties: null,
                                         body: body);

                }

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}

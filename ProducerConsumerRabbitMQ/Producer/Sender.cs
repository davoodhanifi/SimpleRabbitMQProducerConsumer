using RabbitMQ.Client;
using System;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("BasicTest", false, false, false, null);

                    var message = "Getting started with .NET 6 RabbitMQ.";
                    var body = System.Text.Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish("", "BasicTest", null, body);

                    Console.WriteLine($"The message '{message}' has been sent.");
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
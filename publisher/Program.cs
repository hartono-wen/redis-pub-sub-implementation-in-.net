using System;
using StackExchange.Redis;

namespace RedisPublisherIn.NET
{
    class Program
    {
        const string redisConnectionString = "localhost:6379";
        static ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
        static string redisChannelToPublish = "Sample-Channel";

        static void Main(string[] args)
        {
            Console.WriteLine("This is the application to publish message to Redis. By pressing 'Enter' button, this application will send message to Redis.");
            Console.WriteLine($"Redis Channel to publish: {redisChannelToPublish}");
            Console.WriteLine(string.Empty);

            ISubscriber redisPubSub = redisConnection.GetSubscriber();
            while (true)
            {
                string inputtedMessage = Console.ReadLine();
                redisPubSub.Publish(redisChannelToPublish, inputtedMessage);
                Console.WriteLine(string.Empty);
            }
        }
    }
}

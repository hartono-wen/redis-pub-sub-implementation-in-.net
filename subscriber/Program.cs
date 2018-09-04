using System;
using StackExchange.Redis;

namespace RedisSubscriberIn.NET
{
    class Program
    {
        const string redisConnectionString = "localhost:6379";
        static ConnectionMultiplexer redisConnection = ConnectionMultiplexer.Connect(redisConnectionString);
        static string redisChannelToSubscribe = "Sample-Channel";

        static void Main(string[] args)
        {
            Console.WriteLine("This is the application to subscribe to Redis. The console will print out any message sent by the Redis Publisher application.");
            Console.WriteLine($"Subscribed Redis Channel: {redisChannelToSubscribe}");
            Console.WriteLine(string.Empty);

            ISubscriber redisPubSub = redisConnection.GetSubscriber();

            redisPubSub.Subscribe(redisChannelToSubscribe, (channel, message) =>
            {
                Console.WriteLine(message);
                Console.WriteLine(string.Empty);
            });

            while (true)
            {
            }
        }
    }
}

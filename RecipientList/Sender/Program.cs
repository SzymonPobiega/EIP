using System;
using Messages;
using NServiceBus;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            var busConfig = new BusConfiguration();
            busConfig.UsePersistence<InMemoryPersistence>();

            using (var bus = Bus.Create(busConfig).Start())
            {
                while (true)
                {
                    Console.WriteLine("Press <enter> to send a message");
                    Console.ReadLine();
                    bus.Publish(new TestMessage());
                }
            }
        }
    }
}

using System;
using Messages;
using NServiceBus;

namespace Receiver2
{
    class Program
    {
        static void Main(string[] args)
        {
            var busConfig = new BusConfiguration();
            busConfig.UsePersistence<InMemoryPersistence>();

            using (var bus = Bus.Create(busConfig).Start())
            {
                bus.Subscribe<TestMessage>();
                Console.WriteLine("Press <enter> to exit");
                Console.ReadLine();
            }
        }
    }

    public class TestMessageHandler : IHandleMessages<TestMessage>
    {
        public void Handle(TestMessage message)
        {
            Console.WriteLine("Got message!");
        }
    }
}

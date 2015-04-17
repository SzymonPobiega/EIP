using System;
using Messages;
using NServiceBus;

namespace Process1
{
    class Program
    {
        static void Main(string[] args)
        {
            var busConfig = new BusConfiguration();
            busConfig.UsePersistence<InMemoryPersistence>();

            var counter = 1;
            using (var bus = Bus.Create(busConfig).Start())
            {
                while (true)
                {
                    Console.WriteLine("Press <enter> to publish an event");
                    Console.ReadLine();
                    bus.Publish(new EventA
                    {
                        Data = counter.ToString()
                    });
                    counter++;
                }
            }
        }
    }

    public class EventDHandler : IHandleMessages<EventD>
    {
        public IBus Bus { get; set; }

        public void Handle(EventD message)
        {
            Console.WriteLine("Got message {0}", message.Data);
        }
    }
}

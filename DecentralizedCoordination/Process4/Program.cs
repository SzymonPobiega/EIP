using System;
using System.Threading;
using Messages;
using NServiceBus;

namespace Process4
{
    class Program
    {
        static void Main(string[] args)
        {
            var busConfig = new BusConfiguration();
            busConfig.UsePersistence<InMemoryPersistence>();

            using (Bus.Create(busConfig).Start())
            {
                Console.WriteLine("Press <enter> to exit");
                Console.ReadLine();
            }
        }
    }

    public class EventCHandler : IHandleMessages<EventC>
    {
        public IBus Bus { get; set; }

        public void Handle(EventC message)
        {
            Console.WriteLine("Got message {0}", message.Data);
            Thread.Sleep(1500);
            Bus.Publish(new EventD
            {
                Data = message.Data
            });
        }
    }
}

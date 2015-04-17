using System;
using System.Collections.Generic;
using Messages;
using NServiceBus;

namespace Router
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

    public class RoutingHandler : IHandleMessages<DocumentMessage>
    {
        static readonly List<string>[] Routes =
        {
            new List<string> {"ProcessA","ProcessC"}, 
            new List<string> {"ProcessA","ProcessB"}, 
            new List<string> {"ProcessB","ProcessC"}, 
        };

        static readonly Random Random = new Random();

        public IBus Bus { get; set; }

        public void Handle(DocumentMessage message)
        {
            var route = Routes[Random.Next(Routes.Length)];
            message.RoutingSlip = route;
            Console.WriteLine("Routing message {0} to ({1})", message.Data, string.Join(",",route));
            message.Forward(Bus);
        }
    }
}

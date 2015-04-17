using System;
using Messages;
using NServiceBus;

namespace ProcessB
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
        public IBus Bus { get; set; }

        public void Handle(DocumentMessage message)
        {
            Console.WriteLine("Got message {0}", message.Data);
            message.Forward(Bus);
        }
    }
}

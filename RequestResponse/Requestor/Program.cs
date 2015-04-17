using System;
using Messages;
using NServiceBus;

namespace Requestor
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
                    Console.WriteLine("Press <enter> to send a request");
                    Console.ReadLine();

                    bus.Send(new Request
                    {
                        Data = counter.ToString()
                    });
                    counter++;
                }
            }
        }

        public class ResponseHandler : IHandleMessages<Response>
        {
            public void Handle(Response message)
            {
                Console.WriteLine("Got response {0}", message.Data);
            }
        }
    }
}

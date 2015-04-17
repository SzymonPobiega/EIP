using System;
using System.Threading;
using Messages;
using NServiceBus;

namespace Responder
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

        public class RequestHandler : IHandleMessages<Request>
        {
            public IBus Bus { get; set; }

            public void Handle(Request message)
            {
                Console.WriteLine("Got request {0}", message.Data);
                Thread.Sleep(1500);
                Bus.Reply(new Response
                {
                    Data = message.Data
                });
            }
        }
    }
}

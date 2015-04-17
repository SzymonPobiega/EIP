using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Console.WriteLine("Press <enter> to send a command");
                    Console.ReadLine();
                    bus.Send(new CommandA
                    {
                        Data = counter.ToString()
                    });
                    counter++;
                }
            }
        }

        public class ResponseHandler : IHandleMessages<ResponseA>
        {
            public void Handle(ResponseA message)
            {
                Console.WriteLine("Got response {0}", message.Result);
            }
        }
    }
}

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

    public class CommandDHandler : IHandleMessages<CommandD>
    {
        public IBus Bus { get; set; }

        public void Handle(CommandD message)
        {
            Console.WriteLine("Got message {0}", message.Data);
            Thread.Sleep(1500);
            Bus.Reply(new ResponseD
            {
                Result = "D"
            });
        }
    }
}

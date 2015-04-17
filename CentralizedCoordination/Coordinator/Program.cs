using System;
using System.ComponentModel.Design;
using Messages;
using NServiceBus;
using NServiceBus.Saga;

namespace Coordinator
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

    public class CoordinatorSaga : Saga<CoordinatorSagaData>, 
        IAmStartedByMessages<CommandA>,
        IHandleMessages<ResponseB>,
        IHandleMessages<ResponseC>,
        IHandleMessages<ResponseD>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<CoordinatorSagaData> mapper)
        {
            mapper.ConfigureMapping<CommandA>(m => m.Data).ToSaga(s => s.Data);
        }

        public void Handle(CommandA message)
        {
            Data.ReplyAddress = Bus.CurrentMessageContext.ReplyToAddress;
            Data.Data = message.Data;
            Bus.Send("Process2", new CommandB
            {
                Data = Data.Data
            });
        }

        public void Handle(ResponseB message)
        {
            Data.ResultB = message.Result;
            Bus.Send("Process3", new CommandC
            {
                Data = Data.Data
            });
        }

        public void Handle(ResponseC message)
        {
            Data.ResultC = message.Result;
            Bus.Send("Process4", new CommandD
            {
                Data = Data.Data
            });
        }

        public void Handle(ResponseD message)
        {
            Bus.Send(Data.ReplyAddress, new ResponseA
            {
                Result = Data.ResultB + Data.ResultC + message.Result 
            });
        }
    }

    public class CoordinatorSagaData : ContainSagaData
    {
        public string Data { get; set; }
        public Address ReplyAddress { get; set; }
        public string ResultB { get; set; }
        public string ResultC { get; set; }
    }
}

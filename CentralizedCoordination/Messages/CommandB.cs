using NServiceBus;

namespace Messages
{
    public class CommandB : ICommand
    {
        public string Data { get; set; }
    }
}
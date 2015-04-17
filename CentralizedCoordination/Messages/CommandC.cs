using NServiceBus;

namespace Messages
{
    public class CommandC : ICommand
    {
        public string Data { get; set; }
    }
}
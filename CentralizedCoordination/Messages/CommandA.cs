using NServiceBus;

namespace Messages
{
    public class CommandA : ICommand
    {
        public string Data { get; set; }
    }
}
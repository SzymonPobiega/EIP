using NServiceBus;

namespace Messages
{
    public class CommandD : ICommand
    {
        public string Data { get; set; }
    }
}
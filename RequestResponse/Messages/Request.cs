using NServiceBus;

namespace Messages
{
    public class Request : IMessage
    {
        public string Data { get; set; }
    }
}

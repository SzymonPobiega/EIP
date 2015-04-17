using NServiceBus;

namespace Messages
{
    public class Response : IMessage
    {
        public string Data { get; set; }
    }
}
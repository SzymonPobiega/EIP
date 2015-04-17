using NServiceBus;

namespace Messages
{
    public class ResponseB : IMessage
    {
        public string Result { get; set; }
    }
}
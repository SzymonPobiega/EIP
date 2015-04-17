using NServiceBus;

namespace Messages
{
    public class ResponseA : IMessage
    {
        public string Result { get; set; }
    }
}
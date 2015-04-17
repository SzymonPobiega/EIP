using NServiceBus;

namespace Messages
{
    public class ResponseD : IMessage
    {
        public string Result { get; set; }
    }
}
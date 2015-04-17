using NServiceBus;

namespace Messages
{
    public class EventD : IEvent
    {
        public string Data { get; set; }
    }
}
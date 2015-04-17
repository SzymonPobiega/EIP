using NServiceBus;

namespace Messages
{
    public class EventB : IEvent
    {
        public string Data { get; set; }
    }
}
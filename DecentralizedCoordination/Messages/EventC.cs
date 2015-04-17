using NServiceBus;

namespace Messages
{
    public class EventC : IEvent
    {
        public string Data { get; set; }
    }
}
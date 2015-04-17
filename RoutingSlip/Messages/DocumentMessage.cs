using System.Collections.Generic;
using System.Linq;
using NServiceBus;

namespace Messages
{
    public class DocumentMessage : IMessage
    {
        public string Data { get; set; }
        public List<string> RoutingSlip { get; set; }

        public void Forward(IBus bus)
        {
            if (RoutingSlip == null || !RoutingSlip.Any())
            {
                return;
            }
            var next = RoutingSlip.First();
            RoutingSlip = RoutingSlip.Skip(1).ToList();
            bus.Send(next, this);
        }
    }
}

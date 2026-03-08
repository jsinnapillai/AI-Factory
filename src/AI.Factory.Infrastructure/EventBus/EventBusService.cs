using AI.Factory.Core.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.EventBus
{
        public class EventBusService
    {
        private readonly IBus _bus;

        public EventBusService(IBus bus)
        {
            _bus = bus;
        }

        public async Task PublishEventAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent
        {
            await _bus.Publish(@event, cancellationToken);
        }
    }
}

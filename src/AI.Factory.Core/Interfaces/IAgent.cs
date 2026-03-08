using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Interfaces
{
    public interface IAgent
    {
        string Id { get; }
        string Name { get; }
        List<string> EventSubscriptions { get; }
        List<string> EventOutputs { get; }
        List<string> Capabilities { get; }
        Task ProcessEventAsync(IEvent @event, CancellationToken cancellationToken = default);
    }
}

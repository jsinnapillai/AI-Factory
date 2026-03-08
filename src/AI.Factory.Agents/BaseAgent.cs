using AI.Factory.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Agents
{
    public abstract class BaseAgent : IAgent
    {
        public string Id { get; protected set; } = string.Empty;
        public string Name { get; protected set; } = string.Empty;
        public List<string> EventSubscriptions { get; protected set; } = new();
        public List<string> EventOutputs { get; protected set; } = new();
        public List<string> Capabilities { get; protected set; } = new();

        protected BaseAgent(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract Task ProcessEventAsync(IEvent @event, CancellationToken cancellationToken = default);

        protected virtual Task PublishEventAsync(IEvent @event, CancellationToken cancellationToken = default)
        {
            // This will be implemented in the concrete agent classes
            return Task.CompletedTask;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events.Contracts
{
    public record TaskCreatedEvent
    {
        public Guid ProjectId { get; init; }

        public Guid TaskId { get; init; }

        public string TaskType { get; init; } = string.Empty;

        public string Payload { get; init; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events.Contracts
{
    public record TaskCompletedEvent
    {
        public Guid ProjectId { get; init; }

        public Guid TaskId { get; init; }

        public string Result { get; init; } = string.Empty;

        public DateTime CompletedAt { get; init; } = DateTime.UtcNow;
    }
}

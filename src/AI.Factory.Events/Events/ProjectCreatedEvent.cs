using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events.Contracts
{
    public record ProjectCreatedEvent
    {
        public Guid UserId { get; init; }

        public Guid ProjectId { get; init; }

        public string ProjectName { get; init; } = string.Empty;

        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}

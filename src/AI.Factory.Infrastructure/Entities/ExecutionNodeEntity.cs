using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Entities
{
    public class ExecutionNodeEntity
    {
        public Guid Id { get; set; }

        public Guid GraphId { get; set; }

        public string AgentType { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public int RetryCount { get; set; }

        public string Dependencies { get; set; } = "";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ExecutionGraphEntity Graph { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Orchestrator.Execution
{
    public class ExecutionNode
    {
        public Guid NodeId { get; set; }

        public string AgentType { get; set; } = string.Empty;

        public List<Guid> Dependencies { get; set; } = new();

        public ExecutionStatus Status { get; set; } = ExecutionStatus.Pending;

        public int RetryCount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

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

        public bool IsCompleted { get; set; }
    }
}

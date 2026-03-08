using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Orchestrator.Execution
{
    public class ExecutionState
    {
        public Guid ProjectId { get; set; }

        public List<ExecutionNode> Nodes { get; set; } = new();
    }
}

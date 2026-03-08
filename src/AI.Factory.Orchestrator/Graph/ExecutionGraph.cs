using AI.Factory.Orchestrator.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AI.Factory.Orchestrator.Graph
{
    public class ExecutionGraph
    {
        public List<ExecutionNode> Nodes { get; set; } = new();

        public IEnumerable<ExecutionNode> GetExecutableNodes()
        {
            return Nodes.Where(n =>
                n.Status == ExecutionStatus.Pending &&
                n.Dependencies.All(d =>
                    Nodes.First(x => x.NodeId == d).Status == ExecutionStatus.Completed));
        }

        public ExecutionNode? GetNode(Guid nodeId)
        {
            return Nodes.FirstOrDefault(x => x.NodeId == nodeId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.Factory.Orchestrator.Execution;

namespace AI.Factory.Orchestrator.Graph
{
    public class GraphBuilder
    {
        public ExecutionGraph BuildInitialGraph()
        {
            var ba = new ExecutionNode
            {
                NodeId = Guid.NewGuid(),
                AgentType = "BA_ANALYSIS"
            };

            var planner = new ExecutionNode
            {
                NodeId = Guid.NewGuid(),
                AgentType = "PLANNER",
                Dependencies = new List<Guid> { ba.NodeId }
            };

            var coder = new ExecutionNode
            {
                NodeId = Guid.NewGuid(),
                AgentType = "CODE_GENERATION",
                Dependencies = new List<Guid> { planner.NodeId }
            };

            return new ExecutionGraph
            {
                Nodes = new List<ExecutionNode>
            {
                ba,
                planner,
                coder
            }
            };
        }
    }
}

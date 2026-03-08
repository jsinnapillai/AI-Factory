using AI.Factory.Core.Messaging;
using AI.Factory.Events.Contracts;
using AI.Factory.Orchestrator.Execution;
using AI.Factory.Orchestrator.Graph;
using AI.Factory.Orchestrator.Lifecycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AI.Factory.Orchestrator.Services
{
    public class OrchestratorEngine
    {
        private readonly IEventPublisher _publisher;
        private readonly AgentLifecycleManager _lifecycle;

        public OrchestratorEngine(
            IEventPublisher publisher,
            AgentLifecycleManager lifecycle)
        {
            _publisher = publisher;
            _lifecycle = lifecycle;
        }

        public async Task ExecuteGraph(Guid projectId, ExecutionGraph graph)
        {
            var nodes = graph.GetExecutableNodes();

            foreach (var node in nodes)
            {
                _lifecycle.MarkRunning(node);

                var taskEvent = new TaskCreatedEvent
                {
                    ProjectId = projectId,
                    TaskId = node.NodeId,
                    TaskType = node.AgentType
                };

                await _publisher.PublishAsync(taskEvent);
            }
        }
    }
}

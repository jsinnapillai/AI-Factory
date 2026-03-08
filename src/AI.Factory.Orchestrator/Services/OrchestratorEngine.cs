using AI.Factory.Core.Messaging;
using AI.Factory.Events.Contracts;
using AI.Factory.Orchestrator.Execution;
using AI.Factory.Orchestrator.Graph;
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

        public OrchestratorEngine(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task ExecuteGraph(Guid projectId, ExecutionGraph graph)
        {
            var executableNodes = graph.GetExecutableNodes();

            foreach (var node in executableNodes)
            {
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

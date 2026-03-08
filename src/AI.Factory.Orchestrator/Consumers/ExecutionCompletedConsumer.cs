using AI.Factory.Events.Contracts;
using AI.Factory.Orchestrator.Graph;
using AI.Factory.Orchestrator.Lifecycle;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Orchestrator.Consumers
{

    public class ExecutionCompletedConsumer : IConsumer<TaskCompletedEvent>
    {
        private readonly ExecutionGraph _graph;
        private readonly AgentLifecycleManager _lifecycle;

        public ExecutionCompletedConsumer(
            ExecutionGraph graph,
            AgentLifecycleManager lifecycle)
        {
            _graph = graph;
            _lifecycle = lifecycle;
        }

        public Task Consume(ConsumeContext<TaskCompletedEvent> context)
        {
            var node = _graph.GetNode(context.Message.TaskId);

            if (node != null)
            {
                _lifecycle.MarkCompleted(node);
            }

            return Task.CompletedTask;
        }
    }
}

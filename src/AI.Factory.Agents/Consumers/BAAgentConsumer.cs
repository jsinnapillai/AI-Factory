using AI.Factory.Events.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Agents.Consumers
{

    public class BAAgentConsumer : IConsumer<TaskCreatedEvent>
    {
        public async Task Consume(ConsumeContext<TaskCreatedEvent> context)
        {
            var message = context.Message;

            if (message.TaskType != "BA_ANALYSIS")
                return;

            Console.WriteLine($"BA Agent processing project {message.ProjectId}");

            await Task.Delay(1000);

            var result = new TaskCompletedEvent
            {
                ProjectId = message.ProjectId,
                TaskId = message.TaskId,
                Result = "Business analysis completed"
            };

            await context.Publish(result);
        }
    }
}

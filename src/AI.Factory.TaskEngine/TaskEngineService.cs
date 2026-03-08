using AI.Factory.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.Factory.Core.Messaging;
using AI.Factory.Events.Contracts;





namespace AI.Factory.TaskEngine
{
    public class TaskEngineService
    {
        private readonly IEventPublisher _publisher;

        public TaskEngineService(IEventPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task StartProjectAnalysis(Guid projectId)
        {
            var taskEvent = new TaskCreatedEvent
            {
                ProjectId = projectId,
                TaskId = Guid.NewGuid(),
                TaskType = "BA_ANALYSIS",
                Payload = "Analyze project"
            };

            await _publisher.PublishAsync(taskEvent);
        }
    }
}

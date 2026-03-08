using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class TaskGraphBuilt : BaseEvent
    {
        public new TaskGraphPayload Payload { get; set; } = new();
    }

    public class TaskGraphPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string PlanId { get; set; } = string.Empty;
        public List<TaskDefinition> Tasks { get; set; } = new();
    }

    public class TaskDefinition
    {
        public string TaskId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Dependencies { get; set; } = new();
        public string AssignedAgentId { get; set; } = string.Empty;
    }
}

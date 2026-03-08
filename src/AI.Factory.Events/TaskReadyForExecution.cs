using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class TaskReadyForExecution : BaseEvent
    {
        public new TaskReadyPayload Payload { get; set; } = new();
    }

    public class TaskReadyPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string TaskId { get; set; } = string.Empty;
        public string AssignedAgentId { get; set; } = string.Empty;
        public Dictionary<string, string> Context { get; set; } = new();
    }
}

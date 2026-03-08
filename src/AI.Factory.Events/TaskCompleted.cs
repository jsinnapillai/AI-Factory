using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class TaskCompleted : BaseEvent
    {
        public new TaskCompletedPayload Payload { get; set; } = new();
    }

    public class TaskCompletedPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string TaskId { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public Dictionary<string, string> Artifacts { get; set; } = new();
    }
}

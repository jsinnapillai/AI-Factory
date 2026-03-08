using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class TaskFailed : BaseEvent
    {
        public new TaskFailedPayload Payload { get; set; } = new();
    }

    public class TaskFailedPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string TaskId { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string ErrorDetails { get; set; } = string.Empty;
    }
}

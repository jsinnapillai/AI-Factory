using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Models
{
    public class ExecutionLog
    {
        public string Id { get; set; } = string.Empty;
        public string AgentId { get; set; } = string.Empty;
        public string TaskId { get; set; } = string.Empty;
        public string EventId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}

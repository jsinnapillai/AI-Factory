using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Logging
{

    public class LoggingConfig
    {
        public string Level { get; set; } = "Information";
        public string FilePath { get; set; } = "system-nodes/logs/system.log";
        public string EventStreamFilePath { get; set; } = "system-nodes/logs/event-stream.log";
        public string AgentExecutionFilePath { get; set; } = "system-nodes/logs/agent-execution.log";
    }
}

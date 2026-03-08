using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Models.Execution
{
    public class ExecutionNodeDto
    {
        public Guid Id { get; set; }

        public string AgentType { get; set; } = "";

        public string Status { get; set; } = "Pending";

        public int RetryCount { get; set; }

        public List<Guid> Dependencies { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Orchestrator.Execution
{
    public enum ExecutionStatus
    {
        Pending,
        Running,
        Completed,
        Failed,
        Dead
    }
}

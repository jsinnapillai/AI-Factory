using AI.Factory.Orchestrator.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Orchestrator.Lifecycle
{
    public class AgentLifecycleManager
    {
        private const int MAX_RETRY = 3;

        public bool CanRetry(ExecutionNode node)
        {
            return node.RetryCount < MAX_RETRY;
        }

        public void MarkRunning(ExecutionNode node)
        {
            node.Status = ExecutionStatus.Running;
        }

        public void MarkCompleted(ExecutionNode node)
        {
            node.Status = ExecutionStatus.Completed;
        }

        public void MarkFailed(ExecutionNode node)
        {
            node.RetryCount++;

            if (node.RetryCount >= MAX_RETRY)
            {
                node.Status = ExecutionStatus.Dead;
            }
            else
            {
                node.Status = ExecutionStatus.Failed;
            }
        }
    }
}

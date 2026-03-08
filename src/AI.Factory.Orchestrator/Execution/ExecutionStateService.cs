using AI.Factory.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Orchestrator.Execution
{
    public class ExecutionStateService
    {
        private readonly IExecutionRepository _repository;

        public ExecutionStateService(IExecutionRepository repository)
        {
            _repository = repository;
        }

        public async Task MarkCompleted(Guid nodeId)
        {
            await _repository.UpdateNodeStatus(nodeId, "Completed");
        }
    }
}

using AI.Factory.Core.Models.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Interfaces
{
    public interface IExecutionRepository
    {
        Task SaveGraphAsync(Guid projectId, List<ExecutionNodeDto> nodes);

        Task UpdateNodeStatus(Guid nodeId, string status);

        Task<List<ExecutionNodeDto>> GetNodesByProject(Guid projectId);
    }
}

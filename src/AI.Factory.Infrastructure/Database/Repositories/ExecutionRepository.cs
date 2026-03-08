using AI.Factory.Core.Interfaces;
using AI.Factory.Core.Models.Execution;
using AI.Factory.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Database.Repositories
{
    public class ExecutionRepository : IExecutionRepository
    {
        private readonly AppDbContext _db;

        public ExecutionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task SaveGraphAsync(Guid projectId, List<ExecutionNodeDto> nodes)
        {
            var graph = new ExecutionGraphEntity
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Nodes = nodes.Select(n => new ExecutionNodeEntity
                {
                    Id = n.Id,
                    AgentType = n.AgentType,
                    Status = n.Status,
                    RetryCount = n.RetryCount,
                    Dependencies = string.Join(",", n.Dependencies)
                }).ToList()
            };

            _db.ExecutionGraphs.Add(graph);

            await _db.SaveChangesAsync();
        }

        public async Task UpdateNodeStatus(Guid nodeId, string status)
        {
            var node = await _db.ExecutionNodes.FirstOrDefaultAsync(x => x.Id == nodeId);

            if (node != null)
            {
                node.Status = status;
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<ExecutionNodeDto>> GetNodesByProject(Guid projectId)
        {
            return await _db.ExecutionNodes
                .Where(x => x.Graph.ProjectId == projectId)
                .Select(x => new ExecutionNodeDto
                {
                    Id = x.Id,
                    AgentType = x.AgentType,
                    Status = x.Status,
                    RetryCount = x.RetryCount
                }).ToListAsync();
        }
    }
}

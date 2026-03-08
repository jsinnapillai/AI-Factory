using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Entities
{
    public class ExecutionGraphEntity
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<ExecutionNodeEntity> Nodes { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Models
{
    public class TaskItem
    {
        public string Id { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string Technology { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string PlanVersion { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Dependencies { get; set; } = new();
        public string AssignedAgentId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

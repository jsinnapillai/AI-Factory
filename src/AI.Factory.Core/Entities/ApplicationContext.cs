using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Core.Entities
{
    public class ApplicationContext
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string ArchitecturePlan { get; set; } = string.Empty;

        public string TechStack { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

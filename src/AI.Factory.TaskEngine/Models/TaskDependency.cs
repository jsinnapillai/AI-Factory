using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.TaskEngine.Models
{
    public class TaskDependency
    {
        public string TaskId { get; set; } = string.Empty;
        public string DependsOnTaskId { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

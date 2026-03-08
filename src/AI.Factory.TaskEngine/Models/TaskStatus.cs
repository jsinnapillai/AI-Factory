using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.TaskEngine.Models
{
    public static class TaskStatus
    {
        public const string Pending = "Pending";
        public const string Ready = "Ready";
        public const string InProgress = "InProgress";
        public const string Completed = "Completed";
        public const string Failed = "Failed";
    }
}

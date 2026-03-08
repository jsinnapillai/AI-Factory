using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class RequirementAnalysisPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public List<string> Requirements { get; set; } = new();
        public List<string> Constraints { get; set; } = new();
        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class TechnicalPlanCreated : BaseEvent
    {
        public new TechnicalPlanPayload Payload { get; set; } = new();
    }

    public class TechnicalPlanPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string PlanId { get; set; } = string.Empty;
        public List<string> Technologies { get; set; } = new();
        public List<string> Modules { get; set; } = new();
        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}

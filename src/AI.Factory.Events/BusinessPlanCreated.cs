using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class BusinessPlanCreated : BaseEvent
    {
        public new BusinessPlanPayload Payload { get; set; } = new();
    }

    public class BusinessPlanPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string PlanId { get; set; } = string.Empty;
        public List<string> BusinessRequirements { get; set; } = new();
        public List<string> Stakeholders { get; set; } = new();
        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}

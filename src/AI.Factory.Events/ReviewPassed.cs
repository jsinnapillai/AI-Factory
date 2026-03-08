using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class ReviewPassed : BaseEvent
    {
        public new ReviewPassedPayload Payload { get; set; } = new();
    }

    public class ReviewPassedPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string TaskId { get; set; } = string.Empty;
        public string ArtifactId { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
    }
}

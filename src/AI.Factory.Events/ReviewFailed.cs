using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class ReviewFailed : BaseEvent
    {
        public new ReviewFailedPayload Payload { get; set; } = new();
    }

    public class ReviewFailedPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string TaskId { get; set; } = string.Empty;
        public string ArtifactId { get; set; } = string.Empty;
        public List<string> Issues { get; set; } = new();
        public string Comments { get; set; } = string.Empty;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class ReviewRequested : BaseEvent
    {
        public new ReviewRequestPayload Payload { get; set; } = new();
    }

    public class ReviewRequestPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string TaskId { get; set; } = string.Empty;
        public string ArtifactId { get; set; } = string.Empty;
        public string ArtifactType { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}

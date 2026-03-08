using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Events
{
    public class UserRequestPayload
    {
        public string RequestId { get; set; } = string.Empty;
        public string UserMessage { get; set; } = string.Empty;
        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}

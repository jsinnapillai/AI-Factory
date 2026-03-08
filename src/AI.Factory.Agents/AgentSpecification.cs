using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Agents
{
    public class AgentSpecification
    {
        public string AgentId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<string> EventSubscriptions { get; set; } = new();
        public List<string> EventOutputs { get; set; } = new();
        public List<string> Capabilities { get; set; } = new();
    }
}

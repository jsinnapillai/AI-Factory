using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AI.Factory.Agents
{

    public class AgentRegistryService
    {
        private readonly Dictionary<string, AgentSpecification> _agentSpecifications = new();
        private readonly string _specsDirectory;
        private readonly IDeserializer _deserializer;

        public AgentRegistryService(string specsDirectory = "agents/specs")
        {
            _specsDirectory = specsDirectory;
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();
        }

        public async Task LoadAgentSpecificationsAsync()
        {
            if (!Directory.Exists(_specsDirectory))
            {
                Directory.CreateDirectory(_specsDirectory);
                return;
            }

            var files = Directory.GetFiles(_specsDirectory, "*.yaml");
            foreach (var file in files)
            {
                var yaml = await File.ReadAllTextAsync(file, Encoding.UTF8);
                var spec = _deserializer.Deserialize<AgentSpecification>(yaml);

                if (!string.IsNullOrEmpty(spec.AgentId))
                {
                    _agentSpecifications[spec.AgentId] = spec;
                }
            }
        }

        public IEnumerable<AgentSpecification> GetAllAgentSpecifications()
        {
            return _agentSpecifications.Values;
        }

        public AgentSpecification? GetAgentSpecification(string agentId)
        {
            return _agentSpecifications.TryGetValue(agentId, out var spec) ? spec : null;
        }
    }
}

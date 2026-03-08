using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.ModelManager.Models
{
    public class ModelMetrics
    {
        public string Id { get; set; } = string.Empty;
        public string ModelId { get; set; } = string.Empty;
        public string ProviderId { get; set; } = string.Empty;
        public double LatencyMs { get; set; }
        public double CostPerToken { get; set; }
        public int MaxTokens { get; set; }
        public double SuccessRate { get; set; }
        public Dictionary<string, double> TaskSpecificScores { get; set; } = new();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}

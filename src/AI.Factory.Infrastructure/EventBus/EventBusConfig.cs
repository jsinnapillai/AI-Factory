using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.EventBus
{
    public class EventBusConfig
    {
        public string Provider { get; set; } = "Redis";
        public string Host { get; set; } = "localhost";
        public int Port { get; set; } = 6379;
        public string ConnectionString => $"{Host}:{Port}";
    }
}

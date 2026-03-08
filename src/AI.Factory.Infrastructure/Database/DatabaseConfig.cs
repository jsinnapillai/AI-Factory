using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Database
{
    public class DatabaseConfig
    {
        public string Provider { get; set; } = "PostgreSQL";
        public string ConnectionString { get; set; } = "Host=localhost;Database=ai_factory;Username=postgres;Password=postgres";
    }
}

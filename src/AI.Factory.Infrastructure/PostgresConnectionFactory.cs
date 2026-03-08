using AI.Factory.Infrastructure.Database;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure
{
    public class PostgresConnectionFactory
    {
        private readonly string _connectionString;

        public PostgresConnectionFactory(DatabaseConfig config)
        {
            _connectionString = config.ConnectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}

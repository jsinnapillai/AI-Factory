using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Database.Repositories
{

    public class InitialMigration
    {
        private readonly IDbConnection _connection;

        public InitialMigration(PostgresConnectionFactory connectionFactory)
        {
            _connection = connectionFactory.CreateConnection();
        }

        public async Task MigrateAsync()
        {
            await CreateAgentsTableAsync();
            await CreateAgentCapabilitiesTableAsync();
            await CreateEventsTableAsync();
            await CreateTasksTableAsync();
            await CreateTaskDependenciesTableAsync();
            await CreatePlansTableAsync();
            await CreateModulesTableAsync();
            await CreateModelMetricsTableAsync();
            await CreateExecutionsTableAsync();
        }

        private async Task CreateAgentsTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS agents (
                id TEXT PRIMARY KEY,
                name TEXT NOT NULL,
                description TEXT,
                created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreateAgentCapabilitiesTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS agent_capabilities (
                id TEXT PRIMARY KEY,
                agent_id TEXT NOT NULL,
                capability TEXT NOT NULL,
                created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                FOREIGN KEY (agent_id) REFERENCES agents (id)
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreateEventsTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS events (
                id TEXT PRIMARY KEY,
                event_type TEXT NOT NULL,
                source TEXT NOT NULL,
                payload JSONB NOT NULL,
                timestamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreateTasksTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS tasks (
                id TEXT PRIMARY KEY,
                module TEXT NOT NULL,
                technology TEXT NOT NULL,
                status TEXT NOT NULL,
                plan_version TEXT NOT NULL,
                description TEXT,
                assigned_agent_id TEXT,
                created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreateTaskDependenciesTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS task_dependencies (
                id TEXT PRIMARY KEY,
                task_id TEXT NOT NULL,
                depends_on_task_id TEXT NOT NULL,
                created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                FOREIGN KEY (task_id) REFERENCES tasks (id),
                FOREIGN KEY (depends_on_task_id) REFERENCES tasks (id)
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreatePlansTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS plans (
                id TEXT PRIMARY KEY,
                name TEXT NOT NULL,
                description TEXT,
                version TEXT NOT NULL,
                type TEXT NOT NULL,
                created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreateModulesTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS modules (
                id TEXT PRIMARY KEY,
                name TEXT NOT NULL,
                description TEXT,
                technology TEXT NOT NULL,
                created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreateModelMetricsTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS model_metrics (
                id TEXT PRIMARY KEY,
                model_id TEXT NOT NULL,
                provider_id TEXT NOT NULL,
                latency_ms DOUBLE PRECISION NOT NULL,
                cost_per_token DOUBLE PRECISION NOT NULL,
                max_tokens INTEGER NOT NULL,
                success_rate DOUBLE PRECISION NOT NULL,
                task_specific_scores JSONB NOT NULL,
                created_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
                updated_at TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";

            await _connection.ExecuteAsync(sql);
        }

        private async Task CreateExecutionsTableAsync()
        {
            var sql = @"
            CREATE TABLE IF NOT EXISTS executions (
                id TEXT PRIMARY KEY,
                agent_id TEXT NOT NULL,
                task_id TEXT NOT NULL,
                event_id TEXT,
                status TEXT NOT NULL,
                message TEXT,
                timestamp TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
            );";

            await _connection.ExecuteAsync(sql);
        }
    }
}

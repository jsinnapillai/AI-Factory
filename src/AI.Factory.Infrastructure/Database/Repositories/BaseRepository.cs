using AI.Factory.Core.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.Infrastructure.Database.Repositories
{

    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly PostgresConnectionFactory ConnectionFactory;
        protected readonly string TableName;

        protected BaseRepository(PostgresConnectionFactory connectionFactory, string tableName)
        {
            ConnectionFactory = connectionFactory;
            TableName = tableName;
        }

        public virtual async Task<T?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            using var connection = ConnectionFactory.CreateConnection();
            var sql = $"SELECT * FROM {TableName} WHERE id = @id";
            return await connection.QueryFirstOrDefaultAsync<T>(sql, new { id });
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = ConnectionFactory.CreateConnection();
            var sql = $"SELECT * FROM {TableName}";
            return await connection.QueryAsync<T>(sql);
        }

        public abstract Task<string> AddAsync(T entity, CancellationToken cancellationToken = default);
        public abstract Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        public virtual async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            using var connection = ConnectionFactory.CreateConnection();
            var sql = $"DELETE FROM {TableName} WHERE id = @id";
            await connection.ExecuteAsync(sql, new { id });
        }
    }
}

using AI.Factory.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.TaskEngine.Models
{
    public interface ITaskGraphService
    {
        Task<string> CreateTaskAsync(TaskItem task, CancellationToken cancellationToken = default);
        Task<TaskItem?> GetTaskAsync(string taskId, CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TaskItem>> GetReadyTasksAsync(CancellationToken cancellationToken = default);
        Task AddDependencyAsync(string taskId, string dependsOnTaskId, CancellationToken cancellationToken = default);
        Task UpdateTaskStatusAsync(string taskId, string status, CancellationToken cancellationToken = default);
        Task<bool> AreAllDependenciesCompletedAsync(string taskId, CancellationToken cancellationToken = default);
    }
}

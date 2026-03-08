using AI.Factory.Core.Interfaces;
using AI.Factory.Core.Models;
using AI.Factory.TaskEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI.Factory.TaskEngine.Services
{

    public class TaskGraphService : ITaskGraphService
    {
        private readonly IRepository<TaskItem> _taskRepository;
        private readonly IRepository<TaskDependency> _dependencyRepository;

        public TaskGraphService(
            IRepository<TaskItem> taskRepository,
            IRepository<TaskDependency> dependencyRepository)
        {
            _taskRepository = taskRepository;
            _dependencyRepository = dependencyRepository;
        }

        public async Task<string> CreateTaskAsync(TaskItem task, CancellationToken cancellationToken = default)
        {
            return await _taskRepository.AddAsync(task, cancellationToken);
        }

        public async Task<TaskItem?> GetTaskAsync(string taskId, CancellationToken cancellationToken = default)
        {
            return await _taskRepository.GetByIdAsync(taskId, cancellationToken);
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(CancellationToken cancellationToken = default)
        {
            return await _taskRepository.GetAllAsync(cancellationToken);
        }

        public async Task<IEnumerable<TaskItem>> GetReadyTasksAsync(CancellationToken cancellationToken = default)
        {
            // This is a placeholder. In a real implementation, we would query the database
            // to find tasks with status "Ready"
            var allTasks = await _taskRepository.GetAllAsync(cancellationToken);
            return allTasks.Where(t => t.Status == Models.TaskStatus.Ready);
        }

        public async Task AddDependencyAsync(string taskId, string dependsOnTaskId, CancellationToken cancellationToken = default)
        {
            var dependency = new TaskDependency
            {
                TaskId = taskId,
                DependsOnTaskId = dependsOnTaskId
            };

            // This is a placeholder. In a real implementation, we would add the dependency to the database
            await Task.CompletedTask;
        }

        public async Task UpdateTaskStatusAsync(string taskId, string status, CancellationToken cancellationToken = default)
        {
            var task = await _taskRepository.GetByIdAsync(taskId, cancellationToken);
            if (task != null)
            {
                task.Status = status;
                task.UpdatedAt = DateTime.UtcNow;
                await _taskRepository.UpdateAsync(task, cancellationToken);
            }
        }

        public async Task<bool> AreAllDependenciesCompletedAsync(string taskId, CancellationToken cancellationToken = default)
        {
            // This is a placeholder. In a real implementation, we would check if all dependencies are completed
            return await Task.FromResult(true);
        }
    }
}

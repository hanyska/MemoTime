using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskDto> GetAsync(Guid id);
        Task CreateAsync(Guid id, string name, Guid userId, Guid projectId, DateTime dueDate);
        Task<ProjectDto> BrowseAsync(Guid userId, Guid projectId);
        Task<IEnumerable<ProjectDto>> BrowseTasksAsync(Guid userId, TaskFilter filter = null);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Guid taskId, Guid projectId, string name, DateTime dueDate);
        Task FinishAsync(Guid taskId);
    }
}
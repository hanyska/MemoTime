using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Core.Domain;

namespace MemoTime.Core.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TodoTask>> BrowseExpired(Guid userId);
        Task<IEnumerable<TodoTask>> BrowseCurrentDay(Guid userId);
        Task<IEnumerable<TodoTask>> BrowseFinished(Guid userId);
        Task<IEnumerable<TodoTask>> BrowseNextSevenDays(Guid userId);
        Task<IEnumerable<TodoTask>> BrowseProjectTasks(Guid projectId);
        Task<TodoTask> GetAsync(Guid id);
        Task UpdateAsync(TodoTask task);
        Task RemoveAsync(TodoTask task);
    }
}
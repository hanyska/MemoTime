using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Core.Domain;

namespace MemoTime.Core.Repositories
{
    public interface ITaskRepository
    {
        Task AddAsync(TodoTask task);
        Task<TodoTask> GetAsync(Guid id);
        Task<IEnumerable<TodoTask>> BrowseAsync(Guid projectId);
        Task UpdateAsync();
        Task RemoveAsync(TodoTask task);
    }
}
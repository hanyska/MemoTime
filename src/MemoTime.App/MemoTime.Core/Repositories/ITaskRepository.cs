using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MemoTime.Core.Domain;

namespace MemoTime.Core.Repositories
{
    public interface ITaskRepository
    {
        Task<TodoTask> GetAsync(Guid id);
        Task UpdateAsync(TodoTask task);
        Task RemoveAsync(TodoTask task);
    }
}
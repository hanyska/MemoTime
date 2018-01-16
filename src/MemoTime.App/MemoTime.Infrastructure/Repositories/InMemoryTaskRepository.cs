using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;

namespace MemoTime.Infrastructure.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private static IList<TodoTask> _tasks = new List<TodoTask>();
        
        public async Task AddAsync(TodoTask task)
        {
            _tasks.Add(task);

            await Task.CompletedTask;
        }

        public Task<IEnumerable<TodoTask>> BrowseExpired(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoTask>> BrowseCurrentDay(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoTask>> BrowseFinished(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoTask>> BrowseNextSevenDays(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoTask>> BrowseProjectTasks(Guid projectId)
        {
            throw new NotImplementedException();
        }

        public async Task<TodoTask> GetAsync(Guid id)
            => await Task.FromResult(_tasks.FirstOrDefault(x => x.Id == id));

        public Task UpdateAsync(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoTask>> BrowseAsync(Guid projectId)
            => await Task.FromResult(_tasks.Where(x => x.Project.Id == projectId));

        public async Task UpdateAsync()
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(TodoTask task)
        {
            _tasks.Remove(task);

            await Task.CompletedTask;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MemoTime.Infrastructure.Repositories
{
    public class MongoTaskRepository : ITaskRepository
    {
        private readonly IMongoDatabase _database;

        public MongoTaskRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task AddAsync(TodoTask task)
            => await Tasks.InsertOneAsync(task);

        public async Task<TodoTask> GetAsync(Guid id)
            => await Tasks.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<TodoTask>> BrowseAsync(Guid projectId)
            => await Task.FromResult(Tasks.AsQueryable().Where(x => x.ProjectId == projectId));

        public async Task UpdateAsync()
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(TodoTask task)
            => await Tasks.DeleteOneAsync(x => x.Id == task.Id);
                
        private IMongoCollection<TodoTask> Tasks => _database.GetCollection<TodoTask>("task");
    }
}
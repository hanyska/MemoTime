﻿using System;
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
            => await Tasks.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public Task UpdateAsync(TodoTask task)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TodoTask>> BrowseAsync(Guid projectId)
            => await Task.FromResult(Tasks.AsQueryable().Where(x => x.Project.Id == projectId));

        public async Task UpdateAsync()
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(TodoTask task)
            => await Tasks.DeleteOneAsync(x => x.Id == task.Id);
                
        private IMongoCollection<TodoTask> Tasks => _database.GetCollection<TodoTask>("task");
    }
}
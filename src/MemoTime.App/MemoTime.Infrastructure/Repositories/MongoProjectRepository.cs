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
    public class MongoProjectRepository : IProjectRepository
    {
        private readonly IMongoDatabase _database;

        public MongoProjectRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Project> GetAsync(Guid id)
            => await Projects.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Project>> BrowseAsync(Guid userId)
            => await Projects.AsQueryable().Where(x => x.UserId == userId).ToListAsync();

        public async Task AddAsync(Project project)
            => await Projects.InsertOneAsync(project);

        public async Task RemoveAsync(Project project)
            => await Projects.DeleteOneAsync(x => x.Id == project.Id);

        public async Task UpdateAsync(Project project)
            => await Projects.ReplaceOneAsync(x => x.Id == project.Id, project);
        
        private IMongoCollection<Project> Projects => _database.GetCollection<Project>("project");
    }
}
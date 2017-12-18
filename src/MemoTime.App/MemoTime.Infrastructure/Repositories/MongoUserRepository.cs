using System;
using Thread = System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MemoTime.Infrastructure.Repositories
{
    public class MongoUserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;
        
        public MongoUserRepository(IMongoDatabase mongoDatabase)
        {
            _database = mongoDatabase;
        }

        public async Thread.Task<User> GetAsync(Guid id)
            => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Thread.Task<User> GetAsync(string email)
            => await Users.AsQueryable()
                .FirstOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());

        public async Thread.Task<User> GetByUsernameAsync(string username)
            => await Users.AsQueryable()
                .FirstOrDefaultAsync(x => x.Username.ToLowerInvariant() == username.ToLowerInvariant());

        public async Thread.Task AddAsync(User user)
            => await Users.InsertOneAsync(user);

        public async Thread.Task UpdateAsync(User user)
            => await Users.ReplaceOneAsync(x => x.Id == user.Id, user);

        public async Thread.Task RemoveAsync(User user)
            => await Users.DeleteOneAsync(x => x.Id == user.Id);

        private IMongoCollection<User> Users => _database.GetCollection<User>("user");
    }
}
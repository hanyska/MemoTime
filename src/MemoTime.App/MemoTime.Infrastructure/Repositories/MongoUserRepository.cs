using System;
using System.Threading.Tasks;
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

        public async Task<User> GetAsync(Guid id)
            => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
            => await Users.AsQueryable()
                .FirstOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());

        public async Task<User> GetByUsernameAsync(string username)
            => await Users.AsQueryable()
                .FirstOrDefaultAsync(x => x.Username.ToLowerInvariant() == username.ToLowerInvariant());

        public async Task AddAsync(User user)
            => await Users.InsertOneAsync(user);

        public async Task UpdateAsync(User user)
            => await Users.ReplaceOneAsync(x => x.Id == user.Id, user);

        public async Task RemoveAsync(User user)
            => await Users.DeleteOneAsync(x => x.Id == user.Id);

        private IMongoCollection<User> Users => _database.GetCollection<User>("user");
    }
}
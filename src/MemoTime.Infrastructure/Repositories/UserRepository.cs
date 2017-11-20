using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;

namespace MemoTime.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static IList<User> _users = new List<User>();

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.FirstOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(_users.FirstOrDefault(x =>
                string.Equals(x.Email, email, StringComparison.InvariantCultureIgnoreCase)));

        public async Task<User> GetByUsernameAsync(string username)
            => await Task.FromResult(_users.FirstOrDefault(x =>
                string.Equals(x.Username, username, StringComparison.InvariantCultureIgnoreCase)));

        public async Task AddAsync(User user)
        {
            _users.Add(user);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(User user)
        {
            _users.Remove(user);

            await Task.CompletedTask;
        }
    }
}
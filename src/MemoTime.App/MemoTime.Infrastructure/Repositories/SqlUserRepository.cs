using System;
using System.Threading.Tasks;
using MemoTime.Core.Domain;
using MemoTime.Core.Repositories;
using MemoTime.Infrastructure.Ef;
using Microsoft.EntityFrameworkCore;

namespace MemoTime.Infrastructure.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly TodoContext _context;
        
        public SqlUserRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task<User> GetAsync(Guid id)
            => await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());

        public async Task<User> GetByUsernameAsync(string username)
            => await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLowerInvariant() == username.ToLowerInvariant());

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
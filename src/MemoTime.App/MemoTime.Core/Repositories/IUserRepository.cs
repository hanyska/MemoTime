using System;
using System.Data;
using System.Threading.Tasks;
using MemoTime.Core.Domain;

namespace MemoTime.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);
    }
} 
using System;
using System.Threading.Tasks;

namespace MemoTime.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(Guid id, string username, string email, string password);
    }
}
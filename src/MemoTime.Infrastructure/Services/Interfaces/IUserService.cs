using System;
using System.Threading.Tasks;
using MemoTime.Infrastructure.DTO;

namespace MemoTime.Infrastructure.Services.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(Guid id, string username, string email, string password);
        Task<TokenDto> LoginAsync(string username, string password);
    }
}
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Users;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace MemoTime.Infrastructure.Handlers.Users
{
    public class LoginHandler: ICommandHandler<Login>
    {
        private readonly IUserService _service;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }
        
        public async Task HandleAsync(Login command)
        {
            var token = await _service.LoginAsync(command.Username, command.Password);
            
            _cache.SetToken(command.TokenId, token);
        }
    }
}
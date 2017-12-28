using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Users;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Users
{
    public class RegisterHandler: ICommandHandler<Register>
    {
        private readonly IUserService _service;

        public RegisterHandler(IUserService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(Register command)
        {
            await _service.RegisterAsync(command.Id, command.Username, command.Email, command.Password);
        }
    }
}
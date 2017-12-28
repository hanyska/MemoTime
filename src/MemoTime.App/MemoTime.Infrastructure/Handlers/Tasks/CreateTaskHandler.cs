using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Ef;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Tasks
{
    public class CreateTaskHandler: ICommandHandler<Create>
    {
        private readonly ITaskService _service;
        private readonly TodoContext _context;
        
        public CreateTaskHandler(ITaskService service, TodoContext ctx)
        {
            _service = service;
            _context = ctx;
        }
        public async Task HandleAsync(Create command)
        {
            await _service.CreateAsync(command.Id, command.Name, command.UserId, command.ProjectId);
        }
    }
}
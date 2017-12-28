using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Tasks
{
    public class DeleteTaskHandler: ICommandHandler<Delete>
    {
        private readonly ITaskService _service;

        public DeleteTaskHandler(ITaskService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(Delete command)
        {
            await _service.RemoveAsync(command.Id);
        }
    }
}
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Tasks
{
    public class FinishTaskHandler: ICommandHandler<FinishTask>
    {
        private readonly ITaskService _service;

        public FinishTaskHandler(ITaskService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(FinishTask command)
        {
            await _service.FinishAsync(command.TaskId);
        }
    }
}
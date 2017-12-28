using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Tasks
{
    public class UpdateTaskHandler: ICommandHandler<Update>
    {
        private readonly ITaskService _service;
        
        public UpdateTaskHandler(ITaskService service)
        {
            _service = service;
        }
        public async Task HandleAsync(Update command)
        {
            await _service.UpdateAsync(command.TaskId, command.ProjectId, command.Name, command.DueDate);
        }
    }
}
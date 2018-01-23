using System;
using System.Reflection.Emit;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Tasks
{
    public class UpdateTaskHandler: ICommandHandler<Update>
    {
        private readonly ITaskService _service;
        private readonly ILabelService _labelService;
        
        public UpdateTaskHandler(ITaskService service, ILabelService labelService)
        {
            _service = service;
            _labelService = labelService;
        }
        public async Task HandleAsync(Update command)
        {   
            await _service.UpdateAsync
            (
                command.TaskId, 
                command.ProjectId, 
                command.Name, 
                command.DueDate
            );

            await _service.UpdateLabelAsync(command.TaskId, command.Label?.Id ?? Guid.Empty);
        }
    }
}
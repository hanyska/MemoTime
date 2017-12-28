using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Projects;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Projects
{
    public class UpdateProjectHandler: ICommandHandler<Update>
    {
        private readonly IProjectService _service;

        public UpdateProjectHandler(IProjectService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(Update command)
        {
            await _service.UpdateAsync(command.Id, command.Name);
        }
    }
}
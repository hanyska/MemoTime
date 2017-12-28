using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Projects;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Projects
{
    public class CreateProjectHandler: ICommandHandler<Create>
    {
        private readonly IProjectService _service;

        public CreateProjectHandler(IProjectService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(Create command)
        {
            await _service.CreateAsync(command.Id, command.UserId, command.Name);
        }
    }
}
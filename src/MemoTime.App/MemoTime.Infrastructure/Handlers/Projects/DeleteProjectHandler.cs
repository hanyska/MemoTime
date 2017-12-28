using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Projects;
using MemoTime.Infrastructure.Services.Interfaces;

namespace MemoTime.Infrastructure.Handlers.Projects
{
    public class DeleteProjectHandler: ICommandHandler<Delete>
    {
        private readonly IProjectService _service;

        public DeleteProjectHandler(IProjectService service)
        {
            _service = service;
        }
        
        public async Task HandleAsync(Delete command)
        {
            await _service.RemoveAsync(command.Id);
        }
    }
}
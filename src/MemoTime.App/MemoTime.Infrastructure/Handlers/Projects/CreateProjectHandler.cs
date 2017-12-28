using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Projects;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace MemoTime.Infrastructure.Handlers.Projects
{
    public class CreateProjectHandler: ICommandHandler<Create>
    {
        private readonly IProjectService _service;
        private readonly IMemoryCache _cache;
        
        public CreateProjectHandler(IProjectService service, IMemoryCache cache)
        {
            _service = service;
            _cache = cache;
        }
        
        public async Task HandleAsync(Create command)
        {
            await _service.CreateAsync(command.Id, command.UserId, command.Name);

            var project = await _service.GetAsync(command.Id);
            
            _cache.SetProject(project);
        }
    }
}
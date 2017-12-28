using System;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Ef;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace MemoTime.Infrastructure.Handlers.Tasks
{
    public class CreateTaskHandler: ICommandHandler<Create>
    {
        private readonly ITaskService _service;
        private readonly IMemoryCache _cache;
        private readonly TodoContext _context;
        
        public CreateTaskHandler(ITaskService service, IMemoryCache cache, 
            TodoContext ctx)
        {
            _service = service;
            _cache = cache;
            _context = ctx;
        }
        public async Task HandleAsync(Create command)
        {
            await _service.CreateAsync(command.Id, command.Name, command.UserId, command.ProjectId);
            
            var task = await _service.GetAsync(command.Id);

            _cache.SetTask(task);
        }
    }
}
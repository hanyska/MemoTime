using System;
using System.Net;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Handlers;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    [Authorize]
    public class TaskController : ApiBaseController
    {
        private readonly ITaskService _taskService;
        
        public TaskController(ITaskService taskService, ICommandDispatcher dispatcher) : base(dispatcher)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create command)
        {
            var id = Guid.NewGuid();
            command.Id = id;
            command.UserId = UserId;

            await CommandDispatcher.DispatchAsync(command);
            
            return Created("task/", new {});
        }
        
        [HttpPut("{taskId}")]
        public async Task<IActionResult> Put([FromRoute] Guid taskId, [FromBody] Update command)
        {
            command.TaskId = taskId;

            await CommandDispatcher.DispatchAsync(command);
            
            return NoContent();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(Guid taskId)
        {
            await CommandDispatcher.DispatchAsync(new Delete{Id = taskId});

            return NoContent();
        }
    }
}
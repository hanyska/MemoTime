using System;
using System.Net;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    [Authorize]
    public class TaskController : ApiBaseController
    {
        private readonly ITaskService _taskService;
        
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create command)
        {
            await _taskService.CreateAsync(command.Name, UserId, command.ProjectId);

            return Created("task/", new {});
        }
        
        [HttpPut("{taskId}")]
        public async Task<IActionResult> Put([FromRoute] Guid taskId, [FromBody] Update command)
        {
            await _taskService.UpdateAsync(taskId, command.ProjectId, command.Name, command.DueDate);

            return NoContent();
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(Guid taskId)
        {
            await _taskService.RemoveAsync(taskId);

            return NoContent();
        }
    }
}
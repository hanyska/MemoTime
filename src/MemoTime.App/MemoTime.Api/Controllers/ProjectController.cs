using System;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Projects;
using MemoTime.Infrastructure.Handlers;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    [Authorize]
    public class ProjectController : ApiBaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService, 
            ICommandDispatcher dispatcher): base(dispatcher)
        {
            _projectService = projectService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectService.BrowseAsync(UserId);

            return Json(projects);
        }
        
        [HttpGet("{projectId}")]
        public async Task<IActionResult> Get(Guid projectId)
        {
            var project = await _projectService.GetAsync(projectId);

            return Json(project);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create command)
        {
            await _projectService.CreateAsync(UserId, command.Name);

            return Created("/project", new {});
        }
        
        [HttpPut("{projectId}")] 
        public async Task<IActionResult> Put([FromRoute]Guid projectId, [FromBody] Update command)
        {
            await _projectService.UpdateAsync(projectId, command.Name);

            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(Guid projectId)
        {
            await _projectService.RemoveAsync(projectId);

            return NoContent();
        }
    }
}
using System;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Projects;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    public class ProjectController : ApiBaseController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create command)
        {
            await _projectService.CreateAsync(UserId, command.Name);

            return Created("/project", null);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectService.BrowseAsync(UserId);

            return Json(projects);
        }
    }
}
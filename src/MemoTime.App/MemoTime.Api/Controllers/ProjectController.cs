﻿using System;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Projects;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Handlers;
using MemoTime.Infrastructure.Handlers.Projects;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoTime.Api.Controllers
{
    [Authorize]
    public class ProjectController : ApiBaseController
    {
        private readonly IProjectService _projectService;
        private readonly IMemoryCache _cache;
        
        public ProjectController(IProjectService projectService, 
            ICommandDispatcher dispatcher, IMemoryCache cache): base(dispatcher)
        {
            _projectService = projectService;
            _cache = cache;
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
            var id = Guid.NewGuid();
            command.Id = id;
            command.UserId = UserId;
            
            await CommandDispatcher.DispatchAsync(command);

            var project = _cache.GetProject(command.Id);

            return Created("/project", project);
        }
        
        [HttpPut("{projectId}")] 
        public async Task<IActionResult> Put([FromRoute]Guid projectId, [FromBody] Update command)
        {
            command.Id = projectId;
            
            await CommandDispatcher.DispatchAsync(command);

            return NoContent();
        }

        [HttpDelete("{projectId}")]
        public async Task<IActionResult> Delete(Guid projectId)
        {
            await CommandDispatcher.DispatchAsync(new Delete {Id = projectId});

            return NoContent();
        }
    }
}
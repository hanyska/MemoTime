using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Tasks;
using MemoTime.Infrastructure.Extensions;
using MemoTime.Infrastructure.Handlers;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Create = MemoTime.Infrastructure.Commands.Labels.Create;

namespace MemoTime.Api.Controllers
{
    public class LabelController: ApiBaseController
    {
        private readonly ILabelService _labelService;
        private readonly IMemoryCache _cache;
        
        public LabelController
        (
            ICommandDispatcher commandDispatcher, 
            ILabelService labelService,
            IMemoryCache cache
        ) 
            : base(commandDispatcher)
        {
            _labelService = labelService;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var labels = await _labelService.BrowseAsync(UserId);

            return Json(labels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var label = await _labelService.GetAsync(id, UserId);

            return Json(label);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create command)
        {
            var labelId = Guid.NewGuid();
            command.Id = labelId;
            command.UserId = UserId;
            
            await CommandDispatcher.DispatchAsync(command);

            var label = _cache.GetLabel(labelId);

            return Created($"label/{labelId}", label);
        }
    }
}
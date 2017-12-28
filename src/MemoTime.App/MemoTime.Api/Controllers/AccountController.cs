using System;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Users;
using MemoTime.Infrastructure.Handlers;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class AccountController : ApiBaseController
    {
        private readonly IUserService _userService;

        public AccountController(ICommandDispatcher dispatcher): base(dispatcher)
        {
        }
        
	[HttpPost]
        public async Task<IActionResult> Post([FromBody] Register command)
        {
            command.Id = Guid.NewGuid();

            await CommandDispatcher.DispatchAsync(command);
            
            return Created($"/account/{command.Id}", new {});
        }
    }
}

using System;
using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Users;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<IActionResult> Post([FromBody] Register command)
        {
            command.Id = Guid.NewGuid();

            await _userService.RegisterAsync(command.Id, command.Username, 
                command.Email, command.Password);

            return Created($"/account/{command.Id}", null);
        }
    }
}
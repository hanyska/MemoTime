using System.Threading.Tasks;
using MemoTime.Infrastructure.Commands.Users;
using MemoTime.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    public class LoginController : ApiBaseController
    {
        private readonly IUserService _userService;
        
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<IActionResult> Post([FromBody] Login command)
        {
            var token = await _userService.LoginAsync(command.Username, command.Password);

            return Json(token);
        }   
    }
}
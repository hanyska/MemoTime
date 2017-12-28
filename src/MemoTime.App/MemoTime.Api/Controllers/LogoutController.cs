using System.Threading.Tasks;
using MemoTime.Infrastructure.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    public class LogoutController : ApiBaseController
    {
        public LogoutController(ICommandDispatcher dispatcher): base(dispatcher)
        {
            
        }
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok(new {});
        }
    }
}
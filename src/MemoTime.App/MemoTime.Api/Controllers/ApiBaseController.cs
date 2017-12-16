using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MemoTime.Api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public abstract class ApiBaseController : Controller
    {
        protected Guid UserId => User?.Identity?.IsAuthenticated == true
            ? Guid.Parse(User.Identity.Name)
            : Guid.Empty;
    }
}
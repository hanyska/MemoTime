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

//        protected Guid UserId => Guid.Parse("44CC2A4D-4010-4066-A0F9-E34AF55D79DB");
    }
}
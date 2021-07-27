using System;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BaseApiController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public BadRequestObjectResult BadRequestError(string message)
        {
            if (ModelState == null) throw new ArgumentNullException(nameof(ModelState));
            ModelState.AddModelError("message", message);
            return new BadRequestObjectResult(ModelState);
        }
    }
}
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? ex = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(
                title: ex?.Message,
                statusCode: StatusCodes.Status500InternalServerError
                );
        }
    }
}

using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Foodie.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    public IActionResult Problem(List<Error> error)
    {
        return Problem(error);
    }
}

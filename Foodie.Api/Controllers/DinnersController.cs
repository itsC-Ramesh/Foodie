using Microsoft.AspNetCore.Mvc;

namespace Foodie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DinnersController : BaseController
    {
        public DinnersController()
        {
        }


        [HttpGet]
        public IActionResult GetDinners()
        {
            return Ok(Array.Empty<string>());
        }
    }
}

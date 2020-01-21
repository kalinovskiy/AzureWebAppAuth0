using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : ControllerBase
    {
        [Authorize]
        public IActionResult GetValues()
        {
            return Ok("Bla-bla-bla...");
        }
    }
}
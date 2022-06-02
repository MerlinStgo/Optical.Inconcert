using Microsoft.AspNetCore.Mvc;

namespace Optical.Inconcert.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet(Name = "Ping")]
        public ActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}

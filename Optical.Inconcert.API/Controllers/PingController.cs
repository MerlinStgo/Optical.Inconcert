using Microsoft.AspNetCore.Mvc;

namespace Optical.Inconcert.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        /// <summary>
        /// Sirve para validar si el servicio está activo
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Ping")]
        public ActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace BrasGreen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [Route ("/HealthCheck/")]
        public string HealthCheck()
        {
            return "ok";
        }
    }
}

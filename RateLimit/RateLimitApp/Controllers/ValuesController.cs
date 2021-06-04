using Microsoft.AspNetCore.Mvc;

namespace RateLimitApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet] public IActionResult Get() => Ok("This is a message.");
        [HttpPost("{id}")] public IActionResult Post(int id) => Ok(id);
    }
}
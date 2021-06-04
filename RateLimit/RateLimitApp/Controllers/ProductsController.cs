using Microsoft.AspNetCore.Mvc;

namespace RateLimitApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet] public IActionResult Get() => Ok("This is a product.");
        [HttpPut] public IActionResult Put() => Ok("Edited is ok.");
    }
}

using Microsoft.AspNetCore.Mvc;

namespace RateLimitApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet] public IActionResult Get() => Ok("This is a category.");
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediumBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This secures the entire controller
    public class ArticleController : ControllerBase
    {
        [HttpGet("article")]
        public IActionResult GetArticle()
        {
            return Ok(new { message = "This is secured data!" });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Entity;
using Services.Interface;
using Services.ServiceClass;
using Utility;

namespace MediumBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This secures the entire controller
    public class LikeController : ControllerBase
    {
        private readonly ILikeService likeService;
        public LikeController(ILikeService likeService)
        {
            this.likeService= likeService;
        }

        [HttpPost("addLike")]
        public async Task<IActionResult> AddLike([FromBody] LikeDTO likeDTO)
        {
            await this.likeService.PostLike(likeDTO);
            return Ok(ApiResponse<string>.Success("like added"));
        }

        [HttpPost("removeLike")]
        public async Task<IActionResult> RemoveLike([FromBody] LikeDTO likeDTO)
        {
            await this.likeService.RemoveLike(likeDTO);
            return Ok(ApiResponse<string>.Success("like removed successfully"));
        }
    }
}

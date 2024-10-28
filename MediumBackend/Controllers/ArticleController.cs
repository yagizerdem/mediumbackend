using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Entity;
using Services.Interface;
using System.Security.Claims;
using Utility;

namespace MediumBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // This secures the entire controller
    public class ArticleController : ControllerBase
    {

        private readonly IArticleService articleService;
        public ArticleController(IArticleService articleService)
        {   
            this.articleService = articleService;
        }


        [HttpGet("article")]
        public async Task<IActionResult> GetArticle([FromQuery(Name = "page")] string page)
        {
            int limit = 10; // default limit 
            IEnumerable<ArticleDTO> articles = await this.articleService.GetArticles(Convert.ToInt32(page),limit);
            return Ok(new ApiResponse<IEnumerable<ArticleDTO>>() { Succeeded = true, Data = articles });
        }

        [HttpPost("postArticle")]
        public  async Task<IActionResult> PostArticle([FromBody] ArticleDTO articleDto)
        {
            var userId = User.FindFirst("uid")?.Value;
            await articleService.PostArticle(articleDto , userId);
            return Ok(new ApiResponse<string>() { Succeeded = true , Data="article added successfully ..."});
        }


        [HttpPost("deleteArticle")]
        public async Task<IActionResult> DeleteArticle([FromQuery(Name = "Id")] string Id)
        {
            var userId = User.FindFirst("uid")?.Value;
            await this.articleService.DeleteArticle(Convert.ToInt32(Id) , userId);
            return Ok(new ApiResponse<string>() { Succeeded = true, Data = "article deleted successfully ..." });
        }

    }
}

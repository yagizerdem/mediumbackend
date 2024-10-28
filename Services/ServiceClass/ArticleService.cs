
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Models.DTO;
using Models.Entity;
using Repository.UnitOfWork;
using Services.Interface;
using System.Runtime.CompilerServices;

namespace Services.ServiceClass
{
    public class ArticleService : IArticleService
    {
        private readonly IMapper _autoMapper;
        private readonly IUnitOfWork _unitOfWork;
        public ArticleService(IUnitOfWork unitOfWork , IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            this._autoMapper = autoMapper;
        }

        public async Task DeleteArticle(int articleId, string authorId)
        {
            Article article = await this._unitOfWork.Articles.GetByIdAsync(articleId);
            if(article.AuthorId != authorId)
            {
                throw new Exception("article is not owned by author");
            }
            this._unitOfWork.Articles.Delete(article);
            await this._unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticles(int page , int limit)
        {
            try
            {
                IEnumerable<Article> articles = await this._unitOfWork.Articles.getArticleWithPagination(limit , page);
                List<ArticleDTO> result = new List<ArticleDTO>();
                foreach (var article in articles)
                {
                    ArticleDTO articleDTO = this._autoMapper.Map<ArticleDTO>(article);
                    result.Add(articleDTO);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task PostArticle(ArticleDTO articleDTO ,string authorId)
        {
            try
            {
                Article newArticle = this._autoMapper.Map<Article>(articleDTO);
                newArticle.AuthorId = authorId;
                await this._unitOfWork.Articles.AddAsync(newArticle);
                await this._unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

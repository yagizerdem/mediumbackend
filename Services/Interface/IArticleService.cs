using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IArticleService
    {
        Task PostArticle(ArticleDTO articleDTO , string authorId);
        Task<IEnumerable<ArticleDTO>> GetArticles(int page, int limit);

        Task DeleteArticle(int articleId , string authorId); 
    }
}

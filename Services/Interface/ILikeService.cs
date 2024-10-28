using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ILikeService
    {
        Task PostLike(ArticleDTO articleDTO, string authorId);
        Task<IEnumerable<ArticleDTO>> GetLikes(int page, int limit);
        Task DeleteLike(int articleId, string authorId);
    }
}

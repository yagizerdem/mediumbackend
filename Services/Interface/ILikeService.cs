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
        Task PostLike(LikeDTO likeDto);
        Task<IEnumerable<ArticleDTO>> GetLikes();
        public Task RemoveLike(LikeDTO likeDto);
    }
}

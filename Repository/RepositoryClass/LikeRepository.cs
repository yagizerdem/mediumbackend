using DataAccess;
using Models.DTO;
using Models.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryClass
{
    public class LikeRepository : Repository<Like>, ILikeRepostiory
    {
        public LikeRepository(AppDbContext context) : base(context)
        {
        }

        public Like? getByUserIdAndArticleId(LikeDTO likeDTO)
        {
            Like? data = this._dbSet.Where<Like>(x => x.ArticleId == likeDTO.ArticleId && x.AppUserId == likeDTO.AppUserId).SingleOrDefault<Like>();
            return data;
        }
    }
}

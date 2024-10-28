using Models.DTO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ILikeRepostiory : IRepository<Like>
    {
        public Like? getByUserIdAndArticleId(LikeDTO likeDTO);
    }
}

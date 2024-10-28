using AutoMapper;
using Models.DTO;
using Models.Entity;
using Repository.UnitOfWork;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceClass
{
    public class LikeService : ILikeService
    {
        private readonly IMapper _autoMapper;
        private readonly IUnitOfWork _unitOfWork;
        public LikeService(IUnitOfWork unitOfWork, IMapper autoMapper)
        {
            _unitOfWork = unitOfWork;
            this._autoMapper = autoMapper;
        }
        public Task DeleteLike(int likeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleDTO>> GetLikes()
        {
            throw new NotImplementedException();
        }

        public Task PostLike(LikeDTO likeDto)
        {
            Like like =  this._autoMapper.Map<Like>(likeDto);
            Like? isExist = this._unitOfWork.Likes.getByUserIdAndArticleId(likeDto);
            


            throw new NotImplementedException();
        }
    }
}

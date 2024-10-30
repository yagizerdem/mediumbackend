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
using Utility.CustomExceptions;

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

        public Task<IEnumerable<ArticleDTO>> GetLikes()
        {
            throw new NotImplementedException();
        }

        public async Task PostLike(LikeDTO likeDto)
        {
            Like like =  this._autoMapper.Map<Like>(likeDto);
            Like? isExist = this._unitOfWork.Likes.getByUserIdAndArticleId(likeDto);
            if(isExist != null)
            {
                throw new LikeExceptions("user alredy liked this post");
            }
            await this._unitOfWork.Likes.AddAsync(like);
            await this._unitOfWork.SaveAsync();

        }
    
        public async Task RemoveLike(LikeDTO likeDto)
        {
            Like? like = this._unitOfWork.Likes.getByUserIdAndArticleId(likeDto);
            if (like == null)
            {
                throw new LikeExceptions("like does not exist");
            }
            this._unitOfWork.Likes.Delete(like);
            await this._unitOfWork.SaveAsync();
        }
    }
}

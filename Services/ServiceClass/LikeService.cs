using AutoMapper;
using Models.DTO;
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
        public Task DeleteLike(int articleId, string authorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleDTO>> GetLikes(int page, int limit)
        {
            throw new NotImplementedException();
        }

        public Task PostLike(ArticleDTO articleDTO, string authorId)
        {
            throw new NotImplementedException();
        }
    }
}

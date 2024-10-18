using AutoMapper;
using Models.DTO;
using Models.Entity;

namespace MediumBackend
{
    public class AutoMapperConfiguration
    {
        public static IMapper Config()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ArticleDTO, Article>(MemberList.Destination);
                cfg.CreateMap<Article, ArticleDTO>(MemberList.Destination);
            });

//#if DEBUG
//            configuration.AssertConfigurationIsValid();
//#endif

            IMapper mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}

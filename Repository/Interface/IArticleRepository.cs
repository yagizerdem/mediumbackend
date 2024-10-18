using DataAccess;
using Models.Entity;
using Repository.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repository.Interface.IArticleRepository;

namespace Repository.Interface
{
    public interface IArticleRepository : IRepository<Article>
    {
   
    }
}

using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoryClass
{
    public class ArticleRepository : Repository<Article> , IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Article>> getArticleWithPagination(int limit , int page)
        {
            int offset = limit * page;
            IEnumerable<Article> result = await this._dbSet.AsNoTracking().OrderByDescending(x => x.CreatedAt).Skip(offset).Take(limit).ToListAsync<Article>();
            return result;
        } 
    }
}

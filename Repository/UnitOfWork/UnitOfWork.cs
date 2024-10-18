using DataAccess;
using Repository.Interface;
using Repository.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IArticleRepository _articles;


        public UnitOfWork(AppDbContext context , IArticleRepository _articles)
        {
            _context = context;
            this._articles = _articles;
        }

        public IArticleRepository Articles => _articles;


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

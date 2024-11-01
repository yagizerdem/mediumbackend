﻿using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface  IUnitOfWork : IDisposable
    {
        IArticleRepository Articles { get; }
        ILikeRepostiory Likes { get; }
        Task SaveAsync();
    }
}

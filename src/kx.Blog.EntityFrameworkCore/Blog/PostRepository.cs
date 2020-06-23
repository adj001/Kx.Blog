using kx.Blog.Domain.Entities;
using kx.Blog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace kx.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class PostRepository : EfCoreRepository<KxBlogDbContext, Post, int>, IPostRepository
    {
        public PostRepository(IDbContextProvider<KxBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

using kx.Blog.Domain.Entities;
using kx.Blog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace kx.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class CategoryRepository : EfCoreRepository<KxBlogDbContext, Category, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContextProvider<KxBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}

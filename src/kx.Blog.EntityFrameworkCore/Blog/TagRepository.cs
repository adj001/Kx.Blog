using kx.Blog.Domain.Entities;
using kx.Blog.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace kx.Blog.EntityFrameworkCore.Repositories.Blog
{
    public class TagRepository : EfCoreRepository<KxBlogDbContext, Tag, int>, ITagRepository
    {
        public TagRepository(IDbContextProvider<KxBlogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task BulkInsertAsync(IEnumerable<Tag> tags)
        {
            await DbContext.Set<Tag>().AddRangeAsync(tags);
            await DbContext.SaveChangesAsync();
        }
    }
}

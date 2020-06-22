using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;

namespace kx.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class KxBlogMigrationsDbContext : AbpDbContext<KxBlogMigrationsDbContext>
    {
        public KxBlogMigrationsDbContext(DbContextOptions<KxBlogMigrationsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Configure();
        }
    }
}

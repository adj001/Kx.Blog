using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace kx.Blog.EntityFrameworkCore.DbMigrations.EntityFrameworkCore
{
    public class KxBlogMigrationsDbContextFactory : IDesignTimeDbContextFactory<KxBlogMigrationsDbContext>
    {
        public KxBlogMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();
            var builder = new DbContextOptionsBuilder<KxBlogMigrationsDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"));
            return new KxBlogMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}

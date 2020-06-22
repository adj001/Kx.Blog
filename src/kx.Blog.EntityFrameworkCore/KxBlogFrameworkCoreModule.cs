using kx.Blog.Domain;
using kx.Blog.Domain.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace kx.Blog.EntityFrameworkCore
{
    [DependsOn(
        typeof(KxBlogDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreMySQLModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpEntityFrameworkCorePostgreSqlModule),
        typeof(AbpEntityFrameworkCoreSqliteModule)
        )]
    public class KxBlogFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<KxBlogDbContext>(opt =>
            {
                opt.AddDefaultRepositories(includeAllEntities: true);
            });
            Configure<AbpDbContextOptions>(opt =>
            {
                switch (AppSettings.EnableDb)
                {
                    case "MySql":
                        opt.UseMySQL();
                        break;
                    case "SqlServer":
                        opt.UseSqlServer();
                        break;
                    case "PostgreSql":
                        opt.UseNpgsql();
                        break;
                    case "Sqlite":
                        opt.UseSqlite();
                        break;
                    default:
                        opt.UseMySQL();
                        break;
                }
            });
        }
    }
}

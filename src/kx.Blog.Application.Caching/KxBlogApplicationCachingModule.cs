using kx.Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace kx.Blog.Application.Caching
{
    [DependsOn(
        typeof(AbpCachingModule),
        typeof(KxBlogDomainModule)
        )]
    public class KxBlogApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}

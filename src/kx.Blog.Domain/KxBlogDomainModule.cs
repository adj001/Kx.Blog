using kx.Blog.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace kx.Blog.Domain
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(KxBlogDomainSharedModule)
        )]
    public class KxBlogDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
        }
    }
}

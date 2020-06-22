using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace kx.Blog.Domain.Shared
{
    [DependsOn(
        typeof(AbpIdentityDomainSharedModule)
        )]
    public class KxBlogDomainSharedModule : AbpModule
    {
    }
}

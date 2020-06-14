using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace kx.Blog.Application
{
    [DependsOn(
        typeof(AbpIdentityApplicationModule)
        )]
    public class KxBlogApplicationModule : AbpModule
    {
    }
}

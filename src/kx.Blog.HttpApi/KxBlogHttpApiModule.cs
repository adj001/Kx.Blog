using kx.Blog.Application;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace kx.Blog.HttpApi
{
    [DependsOn(
        typeof(AbpIdentityHttpApiModule),
        typeof(KxBlogApplicationModule)
        )]
    public class KxBlogHttpApiModule : AbpModule
    {

    }
}

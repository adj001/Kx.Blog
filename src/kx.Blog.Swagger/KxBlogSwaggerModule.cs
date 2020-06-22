using kx.Blog.Domain;
using Microsoft.AspNetCore.Builder;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace kx.Blog.Swagger
{
    [DependsOn(
        typeof(KxBlogDomainModule)
        )]
    public class KxBlogSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //base.ConfigureServices(context);
            context.Services.AddSwagger();
        }
        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            //base.OnApplicationInitialization(context);
            context.GetApplicationBuilder().UseSwagger().UseSwaggerUI();
        }
    }
}

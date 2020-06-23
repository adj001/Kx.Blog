using kx.Blog.Domain.Configurations;
using kx.Blog.EntityFrameworkCore;
using kx.Blog.HttpApi.Hosting.Filters;
using kx.Blog.HttpApi.Hosting.Middleware;
using kx.Blog.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace kx.Blog.HttpApi.Hosting
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpAutofacModule),
        typeof(KxBlogHttpApiModule),
        typeof(KxBlogSwaggerModule),
        typeof(KxBlogFrameworkCoreModule)
        )]
    public class KxBlogHttpApiHostingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            base.ConfigureServices(context);
            context.Services.Configure<MvcOptions>(opt =>
            {
                var filterMetadata = opt.Filters.FirstOrDefault(p => p is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

                //移除AbpExceptionFilter
                opt.Filters.Remove(filterMetadata);
                //添加自己实现的异常过滤器
                opt.Filters.Add(typeof(KxBlogExceptionFilter));
            });

            ////身份验证
            //context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(opt =>
            //    {
            //        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //        {
            //            ValidateIssuer = true,//是否验证颁发者
            //            ValidateAudience = true,//是否验证访问群体
            //            ValidateLifetime = true,//是否验证生存期
            //            ClockSkew = TimeSpan.FromSeconds(30),//验证Token的时间偏移量
            //            ValidateIssuerSigningKey = true,//是否验证安全密钥
            //            ValidAudience = AppSettings.JWT.Domain,//访问群体
            //            ValidIssuer = AppSettings.JWT.Domain,//颁发者
            //            IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())//安全密钥
            //        };
            //    });
            //// 认证授权
            //context.Services.AddAuthorization();
            ////Http请求
            //context.Services.AddHttpClient();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //自定义异常处理中间件
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();

            ////身份验证
            //app.UseAuthentication();
            ////认证授权
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

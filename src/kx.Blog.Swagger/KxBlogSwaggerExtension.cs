using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using static kx.Blog.Domain.Shared.KxBlogConsts;
using kx.Blog.Domain.Configurations;
using Swashbuckle.AspNetCore.Filters;

namespace kx.Blog.Swagger
{
    public static class KxBlogSwaggerExtension
    {

        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>
        {
            new SwaggerApiInfo
            {
                UrlPrefix=ApiGrouping.GroupNameV1,
                Name="博客前台接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="阿明 - 博客前台接口",
                    Description=""
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix=ApiGrouping.GroupNameV2,
                Name="博客后台接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="阿明 - 博客后台接口",
                    Description=""
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix=ApiGrouping.GroupNameV3,
                Name="通用公共接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="阿明 - 通用公共接口",
                    Description=""
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix=ApiGrouping.GroupNameV4,
                Name="JWT授权接口",
                OpenApiInfo=new OpenApiInfo
                {
                    Version=AppSettings.ApiVersion,
                    Title="阿明 - JWT授权接口",
                    Description=""
                }
            }
        };
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                //options.SwaggerDoc("v1", new OpenApiInfo
                //{
                //    Version = "1.0.0",
                //    Title = "我的接口啊",
                //    Description = "这是接口描述"
                //});

                ApiInfos.ForEach(p =>
                {
                    options.SwaggerDoc(p.UrlPrefix, p.OpenApiInfo);
                });

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "kx.Blog.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "kx.Blog.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "kx.Blog.Application.Contracts.xml"));


                var security = new OpenApiSecurityScheme
                {
                    Description = "JWT模式授权，请输入 Bearer {Token} 进行身份验证",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("JWT", security);
                options.AddSecurityRequirement(new OpenApiSecurityRequirement { { security, new List<string>() } });
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            //app.UseSwaggerUI(Options =>
            //{
            //    Options.SwaggerEndpoint($"/swagger/v1/swagger.json", "默认接口");
            //});

            app.UseSwaggerUI(options =>
            {
                ApiInfos.ForEach(p =>
                {
                    options.SwaggerEndpoint($"/swagger/{p.UrlPrefix}/swagger.json", p.Name);
                });

                //模型的默认扩展深度，设置为 -1 完全隐藏模型
                options.DefaultModelExpandDepth(-1);
                // API文档仅展开标记
                options.DocExpansion(DocExpansion.List);
                // API前缀设置为空
                options.RoutePrefix = string.Empty;
                // API页面Title
                options.DocumentTitle = "接口文档 - 阿明";
            });
        }
    }
    internal class SwaggerApiInfo
    {
        /// <summary>
        /// URL前缀
        /// </summary>
        public string UrlPrefix { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OpenApiInfo OpenApiInfo { get; set; }
    }
}

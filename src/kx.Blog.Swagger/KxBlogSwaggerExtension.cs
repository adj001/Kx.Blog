using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace kx.Blog.Swagger
{
    public static class KxBlogSwaggerExtension
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version="1.0.0",
                    Title="我的接口啊",
                    Description="这是接口描述"
                });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "kx.Blog.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "kx.Blog.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "kx.Blog.Application.Contracts.xml"));
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(Options =>
            {
                Options.SwaggerEndpoint($"/swagger/v1/swagger.json","默认接口");
            });
        }
    }
}

using System;
using System.Threading.Tasks;
using kx.Blog.Application.HelloWorld;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
using static kx.Blog.Domain.Shared.KxBlogConsts;

namespace kx.Blog.HttpApi.Controllers
{
    [ApiExplorerSettings(GroupName =ApiGrouping.GroupNameV3)]
    [ApiController]
    [Route("[controller]")]
    public class HelloWorldController : AbpController
    {
        private readonly IHelloWorldService _helloWorldService;
        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        [HttpGet]
        public string HelloWorld()
        {
            return _helloWorldService.HelloWorld();
        }
    }
}